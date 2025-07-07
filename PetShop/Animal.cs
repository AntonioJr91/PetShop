namespace PetShop
{
    internal class Animal : IExibir
    {
        public string Nome { get; set; }
        public string Especie { get; set; }
        public Tutor Tutor { get; set; }
        public int Id { get; private set; }

        private static int proximoId = 1;

        public Animal(string nome, string especie, Tutor tutor)
        {
            Id = proximoId++;
            Nome = nome;
            Especie = especie;
            Tutor = tutor;
        }

        public void ExibirDetalhes()
        {
            Console.WriteLine($"{Id,-2} | {Nome,-16} | {Especie,-20} | {Tutor.Nome,-20} | {Tutor.Telefone, -20}");
        }

    }
}
