#define debug
using System;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Please enter your difference of X-ics like this: x^5 + y^5. (Both variables must have the same exponent.)");
        Console.Write("Enter: ");

#if debug
        string input = "x^5 + y^5"; // Console.ReadLine() + "";
        Console.WriteLine();
#else
        string input = Console.ReadLine() + "";
#endif

        // Extract parts we need from the base string.
        string[] parts = input.Split(" ");
        string[] chunk1 = parts[0].Split("^");
        string[] chunk2 = parts[2].Split("^");

        // Further extract parts from the chunks.
        char var1, var2; int degree;
        var Chunk1CharArray = chunk1[0].ToCharArray();
        var1 = Chunk1CharArray[0];
        var2 = chunk2[0].ToCharArray()[0];
        degree = int.Parse(chunk1[1]);
        degree--;

        // Generate Formula.
        string output = $"({var1} {parts[1]} {var2})(";
        for (int var1Exponent = degree; var1Exponent != -1; var1Exponent--)
        {
            int var2Exponent = degree - var1Exponent;
            string part = "";
            if (var1Exponent != 0)
            {
                part += $"{var1}^({var1Exponent})";
            }

            if (var2Exponent != 0)
                part += $"{var2}^({var2Exponent})";

            output += part + " + ";
        }
        output = output.Substring(0, output.Length - 3);
        Console.WriteLine($"Your formula is:\n{output})");
    }
}