namespace PetShop
{
    internal class ListaDeAtendimento
    {
        private static Queue<Animal> fila = new();

        public static void AdicionarAnimalAFila(Animal animal)
        {
            fila.Enqueue(animal);
            Console.WriteLine($"\nO animal {animal.Nome} adicionado a fila de atendimento.");
        }

        public static void AtenderProximo()
        {
            if (fila.Count == 0)
            {
                Console.WriteLine("Nenhum animal na fila de atendimento.");
                return;
            }
            Animal proximo = fila.Dequeue();
            Console.WriteLine($"Próximo atendimento {proximo.Nome} Tutor: {proximo.Tutor.Nome}");
        }

        public static void ListarFila()
        {
            if (fila.Count == 0)
            {
                Console.WriteLine("Fila está vazia.");
            }

            Console.WriteLine("----- Fila de atendimento -----");
            foreach (Animal animal in fila)
            {
                Console.WriteLine($"Animal: {animal.Nome}\tTutor: {animal.Tutor.Nome}");
            }
        }
    }
}
