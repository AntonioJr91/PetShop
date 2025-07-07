using PetShop;

while (true)
{
    Console.Clear();
    Console.WriteLine("### PetShop ####");
    Console.WriteLine("1. Cadastrar tutor");
    Console.WriteLine("2. Cadastrar pet");
    Console.WriteLine("3. Listar pets");
    Console.WriteLine("4. Adicionar pet na lista de atendimento");
    Console.WriteLine("5. Listar fila de atendimento dos pets");
    Console.WriteLine("6. Atender próximo pet");
    Console.WriteLine("0. Sair");
    string? opcao = Console.ReadLine();

    switch (opcao)
    {

        case "0":
            Console.WriteLine("\nPrograma encerrado!");
            return;
        case "1":
            Console.Clear();
            Gerenciador.CadastrarTutor();
            break;

        case "2":
            Console.Clear();
            Gerenciador.CadastrarPet();
            break;

        case "3":
            Console.Clear();
            Gerenciador.ListaDePets();
            break;

        case "4":
            Console.Clear();
            Gerenciador.AdicionarAnimalAFilaAtendimento();
            break;

        case "5":
            Console.Clear();
            Gerenciador.ListaDaFilaDeAtendimento();
            break;

        case "6":
            Console.Clear();
            Gerenciador.AtenderProximoPet();
            break;

        default:
            Console.WriteLine("\nOpção inválida!");

            break;
    }
    Console.Write("\nPressione qualquer tecla para voltar ao menu...");
    Console.ReadKey();
}