using System;

class Program
{
    static void Main(string[] args)
    {
        string secret = new Random().Next(1, 101).ToString();
        string response = "";

        do
        {
            Console.Write("\nDigite um número entre 1 e 100 (ou 'S' para sair): ");
            response = Console.ReadLine()!;

            if (response.Equals("s", StringComparison.CurrentCultureIgnoreCase))
            {
                Console.WriteLine("\nAté logo!");
                return;
            }

            if (response == secret)
            {
                Console.WriteLine("\nParabéns, você acertou o número!");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("\nNúmero incorreto. Tente novamente!");
            }
        } while (response != secret);
    }
}
