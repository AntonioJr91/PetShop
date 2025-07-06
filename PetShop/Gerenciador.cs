namespace PetShop
{
    internal class Gerenciador
    {
        private static List<Tutor> tutores = new();
        private static List<Animal> animais = new();
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
            Console.WriteLine("----- Lista de pets cadastrados -----\n");
            if (animais.Count > 0)
            {
                Console.WriteLine("{0,-5} | {1,-15} | {2,-12} | {3,-15} | {4,-10}",
                    "ID", "Tutor", "Telefone", "Nome do Pet", "Espécie");
                Console.WriteLine(new string('-', 70));

                foreach (var animal in animais)
                {
                    Console.WriteLine("{0,-5} | {1,-15} | {2,-12} | {3,-15} | {4,-10}",
                        animal.Id,
                        animal.Tutor.Nome,
                        animal.Tutor.Telefone,
                        animal.Nome,
                        animal.Especie);
                }
            }
            else
            {
                Console.WriteLine("Não há pets cadastrados.");
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

            ListaDePets();

            int id = Utils.LerEntrada<int>("\nInsira o ID do pet que deseja cadastrar na fila de atendimento: ");
            Animal? animalEncontrado = animais.FirstOrDefault(a => a.Id == id);

            if (animalEncontrado == null)
            {
                Console.WriteLine("ID inválido!");
                return;
            }

            ListaDeAtendimento.AdicionarAnimalAFila(animalEncontrado, AdicionarTipoDeServico());
        }

        private static string AdicionarTipoDeServico()
        {
            Console.WriteLine("\nQual o tipo de serviço?");
            Console.WriteLine("\nID\tServiço");
            foreach (var servico in Servicos.ServicosPetShop)
            {
                Console.WriteLine($"{servico.Key}\t{servico.Value}");
            }

            int idServico = Utils.LerEntrada<int>("\nDigite o ID do serviço: ");

            Servicos.ServicosPetShop.TryGetValue(idServico, out string? nomeDoServico);

            return nomeDoServico!;
        }

        public static void ListaDaFilaDeAtendimento()
        {
            ListaDeAtendimento.ListarFila();
        }
    }
}
