// У файлі ConsoleAppFraction\Program.cs
using System;
using FractionLibrary;

class Program
{
    static void Main()
    {
        Fraction fraction1 = GetFractionFromUser("Enter the first fraction:");
        Fraction fraction2 = GetFractionFromUser("Enter the second fraction:");

        Console.WriteLine($"Fraction 1: {fraction1}");
        Console.WriteLine($"Fraction 2: {fraction2}");

        while (true)
        {
            Console.WriteLine("\nChoose an action:");
            Console.WriteLine("1. Addition");
            Console.WriteLine("2. Subtraction");
            Console.WriteLine("3. Multiplication");
            Console.WriteLine("4. Division");
            Console.WriteLine("5. Comparison");
            Console.WriteLine("6. Convert to double");
            Console.WriteLine("7. Exit");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        Console.WriteLine($"Result of Addition: {fraction1 + fraction2}");
                        break;
                    case 2:
                        Console.WriteLine($"Result of Subtraction: {fraction1 - fraction2}");
                        break;
                    case 3:
                        Console.WriteLine($"Result of Multiplication: {fraction1 * fraction2}");
                        break;
                    case 4:
                        try
                        {
                            Console.WriteLine($"Result of Division: {fraction1 / fraction2}");
                        }
                        catch (DivideByZeroException ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        break;
                    case 5:
                        Console.WriteLine($"Comparison Result: {CompareFractions(fraction1, fraction2)}");
                        break;
                    case 6:
                        Console.WriteLine($"Result as double (Fraction 1): {(double)fraction1}");
                        Console.WriteLine($"Result as double (Fraction 2): {(double)fraction2}");
                        break;
                    case 7:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
    }

    static Fraction GetFractionFromUser(string message)
    {
        Console.WriteLine(message);

        Console.Write("Enter numerator: ");
        int numerator;
        while (!int.TryParse(Console.ReadLine(), out numerator))
        {
            Console.WriteLine("Invalid input. Please enter a valid integer for the numerator.");
        }

        Console.Write("Enter denominator: ");
        int denominator;
        while (!int.TryParse(Console.ReadLine(), out denominator) || denominator == 0)
        {
            Console.WriteLine("Invalid input. Please enter a valid integer (non-zero) for the denominator.");
        }

        return new Fraction(numerator, denominator);
    }

    static string CompareFractions(Fraction fraction1, Fraction fraction2)
    {
        if (fraction1 == fraction2)
            return "Fractions are equal.";
        else if (fraction1 > fraction2)
            return "Fraction 1 is greater.";
        else
            return "Fraction 2 is greater.";
    }
}
