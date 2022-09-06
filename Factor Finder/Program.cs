using System;

class Program
{
    public static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Enter a number: ");
            int number;
            try { number = int.Parse(Console.ReadLine() + ""); } catch (Exception) { break; }

            for (int i = 2; i < number / 2; i++)
                if (number % i == 0)
                    Console.WriteLine($"{i} * {number / i} == {number}");

        }
    }
}