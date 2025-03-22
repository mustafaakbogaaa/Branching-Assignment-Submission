// A console program that calculates shipping cost based on input dimensions and weight
using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            ExecuteShippingLogic(); // Start the process
        }
        catch (Exception error)
        {
            Console.WriteLine($"An error occurred: {error.Message}");
        }
    }

    static void ExecuteShippingLogic()
    {
        // Show welcome message
        Console.WriteLine("Hello! You're now using Package Express.");

        // Ask for package weight
        decimal weight = GetInput("Enter package weight:");
        if (weight > 50)
        {
            Console.WriteLine("Package too heavy to be shipped via Package Express. Have a good day.");
            return;
        }

        // Ask for dimensions
        decimal width = GetInput("Enter package width:");
        decimal height = GetInput("Enter package height:");
        decimal length = GetInput("Enter package length:");

        // Check if dimensions are too large
        if ((width + height + length) > 50)
        {
            Console.WriteLine("Package too big to be shipped via Package Express.");
            return;
        }

        // Calculate quote using formula
        decimal quote = (width * height * length * weight) / 100;

        // Display the result
        Console.WriteLine($"Your estimated total for shipping this package is: ${quote:F2}");
        Console.WriteLine("Thanks for using our service!");
    }

    // Utility to retrieve valid decimal number from user
    static decimal GetInput(string prompt)
    {
        while (true)
        {
            Console.WriteLine(prompt);
            if (decimal.TryParse(Console.ReadLine(), out decimal number) && number > 0)
                return number;

            Console.WriteLine("Invalid input. Enter a positive numeric value.");
        }
    }
}
