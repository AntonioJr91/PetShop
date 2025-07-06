namespace PetShop
{
    internal class Animal
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

    }
}
