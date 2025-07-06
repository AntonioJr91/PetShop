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

            Console.WriteLine("{0,-4} | {1,-18} | {2,-16} | {3,-22} | {4,-16}",
         "ID", "Tutor", "Telefone", "Nome do Pet", "Espécie");
            Console.WriteLine(new string('-', 80));

            foreach (var animal in animais)
            {
                Console.WriteLine("{0,-4} | {1,-18} | {2,-16} | {3,-22} | {4,-16}",
                    animal.Id,
                    animal.Tutor.Nome,
                    animal.Tutor.Telefone,
                    animal.Nome,
                    animal.Especie);
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

            ObterAnimaisDisponiveisParaFila();

            int id = Utils.LerEntrada<int>("\nInsira o ID do pet que deseja cadastrar na fila de atendimento: ");
            Animal? animalEncontrado = animais.FirstOrDefault(a => a.Id == id);

            if (animalEncontrado == null)
            {
                Console.WriteLine("ID inválido!");
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
            FilaDeAtendimento.ListarFila();
        }

        public static void ObterAnimaisDisponiveisParaFila()
        {
            var animaisNaFila = new HashSet<int>(FilaDeAtendimento.fila.Select(f => f.Animal.Id));
            var animaisDisponiveis = animais.Where(a => !animaisNaFila.Contains(a.Id)).ToList();

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
    }
}

