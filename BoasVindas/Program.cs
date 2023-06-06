using System;

class Program
{
    static Dictionary<string, List<int>> bandsList = new Dictionary<string, List<int>>()
    {
        {"U2", new List<int> {5, 4, 4, 5, 5}},
        {"White Snake", new List<int> {5, 5, 4, 5}},
        {"Duran Duran", new List<int> {4, 3, 4, 3}},
        {"AC/DC", new List<int> {5, 4, 2, 5}},
        {"A-ha", new List<int> {5, 4, 4, 4}}
    };

    static void ShowLogo()
    {
        Console.WriteLine(@"
░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░");
    }

    static void ShowMenu()
    {
        ShowLogo();

        Console.WriteLine("\n[1]\tRegistrar uma banda");
        Console.WriteLine("[2]\tMostrar todas as bandas");
        Console.WriteLine("[3]\tAvaliar uma banda");
        Console.WriteLine("[4]\tExibir avaliação média de uma banda");
        Console.WriteLine("[5]\tSair\n");

        string option = Console.ReadLine()!;

        switch (option)
        {
            case "1":
                Console.Clear();
                ShowTitle("REGISTRAR BANDA");
                RegisterBand();
                break;
            case "2":
                Console.Clear();
                ShowTitle("BANDAS CADASTRADAS");
                ListBands();
                Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
                Console.ReadKey();
                Console.Clear();
                ShowMenu();
                break;
            case "3":
                Console.Clear();
                ShowTitle("AVALIAR BANDA");
                RateBand();
                break;
            case "4":
                Console.Clear();
                ShowTitle("AVALIAÇÃO MÉDIA DAS BANDAS");
                ShowBandRating();
                break;
            case "5":
                Console.Clear();
                Console.WriteLine("\nAté logo!");
                break;
            default:
                Console.WriteLine("Opção inválida!");
                Thread.Sleep(2000);
                Console.Clear();
                ShowMenu();
                break;
        }
    }

    static void ShowTitle(string title)
    {
        int charsNumber = title.Length + 2;

        Console.WriteLine(string.Empty.PadLeft(charsNumber, '='));
        Console.WriteLine(title);
        Console.WriteLine(string.Empty.PadLeft(charsNumber, '=') + "\n");
    }

    static void RegisterBand()
    {
        string bandName;

        Console.Write("Nome da banda: ");
        bandName = Console.ReadLine()!;

        if (bandName == "")
        {
            Console.WriteLine("\nDigite um nome válido para a banda!");
            Thread.Sleep(2000);
            Console.Clear();
            RegisterBand();
        }

        if (bandsList.ContainsKey(bandName))
        {
            Console.WriteLine("\nNão é possível cadastrar uma banda já registrada!");
            Thread.Sleep(2000);
            Console.Clear();
            RegisterBand();
        }

        bandsList.Add(bandName, new List<int>());

        Console.WriteLine($"\nBanda '{bandName}' registrada com sucesso!");
        Thread.Sleep(2000);
        Console.Clear();
        ShowMenu();
    }

    static void ListBands()
    {
        int i = 1;

        foreach (string band in bandsList.Keys)
        {
            Console.WriteLine($"[{i}]\t{band}");
            i++;
        }
    }

    static void RateBand()
    {
        ListBands();
        Console.Write("\nEscolha uma banda para avaliar: ");
        string option = Console.ReadLine()!;
        int bandOption = 0;

        while (!int.TryParse(option, out bandOption) || bandOption <= 0 || bandOption > bandsList.Count)
        {
            Console.Write("\nOpção inválida. Por favor, digite um valor numérico válido: ");
            option = Console.ReadLine()!;
        }

        int bandIndex = bandOption - 1;

        Console.Write($"\nAvalie a banda '{bandsList.ElementAt(bandIndex).Key}' com uma nota de 1 a 5: ");
        string option2 = Console.ReadLine()!;
        int bandRating;

        while (!int.TryParse(option2, out bandRating) || bandRating < 0 || bandRating > 5)
        {
            Console.Write("\nOpção inválida. Por favor, digite um valor numérico válido: ");
            option2 = Console.ReadLine()!;
        }

        bandsList.ElementAt(bandIndex).Value.Add(bandRating);
        Console.WriteLine("\nAvaliação cadastrada com sucesso!");
        Thread.Sleep(2000);
        Console.Clear();
        ShowMenu();
    }

    static void ShowBandRating()
    {
        int i = 1;

        foreach (var band in bandsList)
        {
            string bandName = band.Key;
            double average = band.Value.Average();

            Console.Write($"[{i}]\t{bandName}  {GetRatingStars(average)}  {average.ToString("0.0")}\n");
            i++;
        }

        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
        Console.ReadKey();
        Console.Clear();
        ShowMenu();
    }

    static string GetRatingStars(double rating)
    {
        int roundedRating = (int)Math.Round(rating);
        return new string('*', roundedRating);
    }

    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        ShowMenu();
    }
}
