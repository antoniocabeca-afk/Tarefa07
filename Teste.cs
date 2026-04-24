 class Programa
    {
        static void Main(string[] args)
        {
        Console.WriteLine("=== Programa de Exemplo em C# ===");

        Console.Write("Introduza o seu nome: ");
        string nome = Console.ReadLine();

        Console.Write("Introduza a sua idade: ");
        int idade = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine($"\nOlá, {nome}! Tens {idade} anos.");
        
        Console.WriteLine("\nPrima qualquer tecla para sair...");
        Console.ReadKey();
        }
    }
