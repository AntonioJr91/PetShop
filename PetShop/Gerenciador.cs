using PetShop;

namespace PetShop
{
    internal class Gerenciador
    {
        private static List<Tutor> tutores = new();
        internal static List<Animal> animais = new();
        public static void CadastrarTutor()
        {
            Console.WriteLine("----- Cadastro do tutor -----\n");
            string nome = Utils.LerEntrada<string>("Nome");
            string telefone = Utils.LerEntrada<string>("Telefone");

            Tutor novoTutor = new(nome, telefone);
            tutores.Add(novoTutor);
            Console.WriteLine("\nTutor adicionado com sucesso!");
        }

        public static void CadastrarPet()
        {
            Console.WriteLine("----- Cadastro do pet -----\n");
            string nome = Utils.LerEntrada<string>("Nome");
            string especie = Utils.LerEntrada<string>("Especie");
            string telefoneDoTutor = Utils.LerEntrada<string>("Telefone do tutor");

            Tutor? tutorEncontrado = tutores.FirstOrDefault(t => t.Telefone!.Equals(telefoneDoTutor));

            if (tutorEncontrado == null)
            {
                Console.WriteLine("Tutor não encontrado. Cadastre o tutor antes.");
                return;
            }

            Animal novoAnimal = new(nome, especie, tutorEncontrado);
            animais.Add(novoAnimal);
            Console.WriteLine($"\nPet {nome} foi cadastrado para o tutor {tutorEncontrado.Nome}.");
        }

        public static void ListaDePets()
        {
            Console.WriteLine("----- Lista de pets -----\n");

            if (animais.Count == 0)
            {
                Console.WriteLine("Não há pets cadastrados.");
                return;
            }

            Console.WriteLine("{0, -2} | {1, -16} | {2, -20} | {3, -20} | {4, -20}", "ID", "Nome do Pet", "Espécie", "Tutor", "Telefone");
            Console.WriteLine(new string('-', 80));

            foreach (IExibir item in animais)
            {
                item.ExibirDetalhes();
            }
        }

        public static void AdicionarAnimalAFilaAtendimento()
        {
            Console.WriteLine("----- Cadastro da fila de atendimento -----\n");

            if (animais.Count == 0)
            {
                Console.WriteLine("Não há pets para serem cadastrados.");
                return;
            }

            ExibeAnimaisDisponiveisParaFila();

            int id = Utils.LerEntrada<int>("\nInsira o ID do pet que deseja cadastrar na fila de atendimento");
            Animal? animalEncontrado = animais.FirstOrDefault(a => a.Id == id);

            if (animalEncontrado == null)
            {
                Console.WriteLine("ID inválido!");
                return;
            }

            if (FilaDeAtendimento.EstaNaFila(animalEncontrado))
            {
                Console.WriteLine("Este pet já está na fila de atendimento");
                return;
            }

            FilaDeAtendimento.AdicionarAnimalAFila(animalEncontrado, AdicionarTipoDeServico());
        }

        private static string AdicionarTipoDeServico()
        {
            Console.WriteLine("\nQual o tipo de serviço?");
            Console.WriteLine("\nID".PadRight(5) + "Serviço".PadRight(73));
            Console.WriteLine(new string('-', 80));

            foreach (var servico in Servicos.ServicosPetShop)
            {
                Console.WriteLine(
                    $"{servico.Key.ToString().PadRight(5)}{servico.Value.PadRight(73)}"
                );
            }

            int idServico = Utils.LerEntrada<int>("\nDigite o ID do serviço: ");

            Servicos.ServicosPetShop.TryGetValue(idServico, out string? nomeDoServico);

            return nomeDoServico!;
        }

        public static void ListaDaFilaDeAtendimento()
        {
            Console.WriteLine("----- Fila de Atendimento -----\n");

            Queue<Atendimento> fila = FilaDeAtendimento.ObterFilaAtual()!;

            if (fila.Count == 0)
            {
                Console.WriteLine("Fila de atendimento está vazia.");
                return;
            }

            Console.WriteLine("\n{0,-4} | {1,-16} | {2,-16} | {3,-38}",
              "#", "Nome do Animal", "Nome do Tutor", "Serviço");
            Console.WriteLine(new string('-', 80));

            foreach (var atendimento in fila)
            {
                Console.WriteLine("{0,-4} | {1,-16} | {2,-16} | {3,-38}",
                    atendimento.Id,
                    atendimento.Animal.Nome,
                    atendimento.Animal.Tutor.Nome,
                    atendimento.Servico
                );
            }
        }

        public static void ExibeAnimaisDisponiveisParaFila()
        {
            List<Animal> animaisDisponiveis = FilaDeAtendimento.ObterDisponiveis(animais);

            Console.WriteLine(
                "ID".PadRight(5) +
                "Nome".PadRight(22) +
                "Tutor".PadRight(25) +
                "Espécie".PadRight(24)
            );
            Console.WriteLine(new string('-', 80));

            foreach (var animal in animaisDisponiveis)
            {
                Console.WriteLine(
                    animal.Id.ToString().PadRight(5) +
                    animal.Nome.PadRight(22) +
                    animal.Tutor.Nome.PadRight(25) +
                    animal.Especie.PadRight(24)
                );
            }
        }

        public static void AtenderProximoPet()
        {
            Console.WriteLine("----- Próximo Atendimento -----\n");

            var atendimento = FilaDeAtendimento.AtenderProximo();

            if (atendimento == null)
            {
                Console.WriteLine("\nNão há pets na fila de atendimento.");
                return;
            }

            Animal animal = atendimento.Animal;

            Console.WriteLine("{0,-20} | {1,-20} | {2,-20} | {3,-15}",
                "Nome do Pet", "Nome do Tutor", "Telefone", "Serviço");
            Console.WriteLine(new string('-', 80));

            Console.WriteLine("{0,-20} | {1,-20} | {2,-20} | {3,-15}",
                animal.Nome,
                animal.Tutor.Nome,
                animal.Tutor.Telefone,
                atendimento.Servico
            );

            Console.Write("\nPressione qualquer tecla para atualizar a lista de atendimento . . . ");
            Console.ReadKey();

            Console.Clear();
            ListaDaFilaDeAtendimento();
        }
    }
}