namespace PetShop
{
    internal class Atendimento
    {
        private readonly int proximoId = 1;
        public int Id {get; private set;}
        public Animal Animal { get; set; }
        public string? Servico { get; set; }

        public Atendimento(Animal animal, string servico)
        {
            Id = proximoId++;
            Animal = animal;
            Servico = servico;
        }
    }
}
