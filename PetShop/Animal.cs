namespace PetShop
{
    internal class Animal
    {
        public string Nome { get; set; }
        public string Especie {  get; set;}
        public Tutor Tutor {  get; set; }

        public Animal(string nome, string especie, Tutor tutor)
        {
            Nome = nome;
            Especie = especie;
            Tutor = tutor;
        }

    }
}
