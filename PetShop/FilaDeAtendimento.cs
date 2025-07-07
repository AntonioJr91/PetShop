namespace PetShop
{
    internal class FilaDeAtendimento
    {
        private static readonly Queue<Atendimento> fila = new();

        public static void AdicionarAnimalAFila(Animal animal, string servico)
        {
            fila.Enqueue(new Atendimento(animal, servico));
        }

        public static Queue<Atendimento> ObterFilaAtual() => fila;

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
    }
}
