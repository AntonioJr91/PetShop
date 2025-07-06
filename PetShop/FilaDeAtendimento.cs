namespace PetShop
{
    internal class FilaDeAtendimento
    {
        internal static readonly Queue<Atendimento> fila = new();

        public static void AdicionarAnimalAFila(Animal animal, string servico)
        {
            if (animal == null)
            {
                Console.WriteLine("Pet não encontrado ou inexistente.");
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

        private static void AtenderProximo()
        {
            Atendimento proximoAtendimento = fila.Dequeue();
            Animal animal = proximoAtendimento.Animal;
            Console.WriteLine($"Próximo atendimento {animal.Nome}\tTutor: {animal.Tutor.Nome}");
        }
    }
}
