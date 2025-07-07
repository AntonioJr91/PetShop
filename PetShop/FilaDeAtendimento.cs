namespace PetShop
{
    internal class FilaDeAtendimento
    {
        private static readonly Queue<Atendimento> fila = new();

        public static void AdicionarAnimalAFila(Animal animal, string servico)
        {
            if (animal == null)
            {
                Console.WriteLine("Pet não encontrado ou inexistente.");
                return;
            }

            fila.Enqueue(new Atendimento(animal!, servico));
            Console.WriteLine($"\nO pet {animal!.Nome} adicionado a fila de atendimento para o serviço {servico}.");
        }

        public static void ListarFila()
        {
            Console.WriteLine("----- Fila de atendimento -----\n");

            if (fila.Count == 0)
            {
                Console.WriteLine("Não há pets na fila de atendimento.");
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
                    atendimento.Servico);
            }
        }

        public static Atendimento? AtenderProximo()
        {

            if (fila.Count == 0)
            {
                return null;
            }
            return fila.Dequeue();

        }

        public static bool EstaNaFila(Animal animal)
        {
            return fila.Any(f => f.Animal.Id == animal.Id);
        }

        public static List<Animal> ObterDisponiveis(List<Animal> todosOsAnimais)
        {
            var animaisNaFila = fila.Select(f => f.Animal.Id).ToHashSet();
            return todosOsAnimais.Where(a => !animaisNaFila.Contains(a.Id)).ToList();
        }

        public static bool FilaEstaVazia()
        {
            return fila.Count == 0;
        }
    }
}
