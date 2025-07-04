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
                for (int i = 0; i < animais.Count; i++)
                {
                    var animal = animais[i];
                    Console.WriteLine("Id\tNome do Tutor\tTelefone\tNome do pet\tEspecie");
                    Console.WriteLine($"{i + 1}" + animal.Tutor.Nome + animal.Tutor.Telefone + animal.Nome + animal.Especie);

                }
            }
            else
            {
                Console.WriteLine("Não há pets cadastrados.");
            }
        }

        // Resolver o problema do indice. Iniciando em 0 mas alteramos para 1 e quando vamos inserir o animal no atendimento o indice é 0
        // Procurar uma solução adequeada para isso. Adicionar um ID ao pet ao adicionar ou alguma outra forma.
        public static void AdicionarAnimalAFilaAtendimento()
        {
            Console.WriteLine("----- Cadastro da fila de atendimento -----\n");

            if (animais.Count == 0)
            {
                Console.WriteLine("Não há pets para serem cadastrados.");
                return;
            }

            ListaDePets();

            int indice = Utils.LerEntrada<int>("\nInsira o ID do pet que deseja cadastrar na fila de atendimento: ");

            if (indice < 0 || indice >= animais.Count)
            {
                Console.WriteLine("Inidice inválido!");
                return;
            }

            Animal petSelecionado = animais[indice];
            ListaDeAtendimento.AdicionarAnimalAFila(petSelecionado);
        }
    }
}
