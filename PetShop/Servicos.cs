namespace PetShop
{
    internal class Servicos
    {
        public static Dictionary<int, string> ServicosPetShop { get; } = new()
        {
            { 1, "Banho Simples" },
            { 2, "Tosa Completa" },
            { 3, "Vacinação (V8, V10, Antirrábica)" },
            { 4, "Consulta Veterinária" },
            { 5, "Corte de Unhas" },
            { 6, "Limpeza de Ouvidos" }
        };
    }
}
