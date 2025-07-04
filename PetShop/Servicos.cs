namespace PetShop
{
    internal class Servicos
    {
        public static Dictionary<int, string> ServicosPetShop { get; } = new()
        {
            { 1, "Banho Simples" },
            { 2, "Tosa Higiênica" },
            { 3, "Tosa Completa" },
            { 4, "Vacinação (V8, V10, Antirrábica)" },
            { 5, "Consulta Veterinária" },
            { 6, "Venda de Rações e Petiscos" },
            { 7, "Venda de Acessórios e Higiene" },
            { 8, "Corte de Unhas" },
            { 9, "Limpeza de Ouvidos" }
        };
    }
}
