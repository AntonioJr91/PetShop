namespace PetShop
{
    internal class ListaDeAtendimento
    {
        private static readonly Queue<Atendimento> fila = new();

        public static void AdicionarAnimalAFila(Animal animal, string servico)
        {
            if (animal == null)
            {
                Console.WriteLine("Pet não encontrado ou inexistente.");
            }

            fila.Enqueue(new Atendimento(animal!, servico));
            Console.WriteLine($"\nO pet {animal!.Nome} adicionado a fila de atendimento para o serviço {servico}.");
        }

        public static void AtenderProximo()
        {
            if (fila.Count == 0)
            {
                Console.WriteLine("Nenhum animal na fila de atendimento.");
                return;
            }
            Atendimento proximoAtendimento = fila.Dequeue();
            Animal animal = proximoAtendimento.Animal;
            Console.WriteLine($"Próximo atendimento {animal.Nome} Tutor: {animal.Tutor.Nome}");
        }

        public static void ListarFila()
        {
            Console.WriteLine("----- Fila de atendimento -----");

            if (fila.Count == 0)
            {
                Console.WriteLine("Fila está vazia.");
            }

            Console.WriteLine("#\tNome do animal\tNome do tutor\tServiço");
            foreach (var atendimento in fila)
            {
                Console.WriteLine($"{atendimento.Id}\tAnimal: {atendimento.Animal.Nome}\tTutor: {atendimento.Animal.Tutor.Nome}\t Serviço: {atendimento.Servico}");
            }
        }
    }
}
