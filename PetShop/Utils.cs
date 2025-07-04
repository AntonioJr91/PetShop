namespace PetShop
{
    internal class Utils
    {
        public static T LerEntrada<T>(string mensagem)
        {
            while (true)
            {
                Console.Write($"{mensagem}: ");
                string? entrada = Console.ReadLine();

                try
                {
                    if (typeof(T) == typeof(string))
                    {
                        if (!string.IsNullOrWhiteSpace(entrada))
                            return (T)(object)entrada;
                        else
                            throw new Exception("Texto vazio não é válido.");
                    }

                    if (string.IsNullOrWhiteSpace(entrada))
                    {
                        throw new Exception("A entrada de dados não pode ser vazia.");
                    }

                    T valor = (T)Convert.ChangeType(entrada, typeof(T));
                    return valor;
                }
                catch
                {
                    Console.WriteLine("\nValor inválido para o tipo esperado. Tente novamente.");
                }
            }
        }
    }
}
