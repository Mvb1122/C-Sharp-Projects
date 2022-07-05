using System;

namespace Electronegativity_Differences_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the EN of the first element.");
            double x = Double.Parse(Console.ReadLine());
            Console.WriteLine("Enter the EN of the second element.");
            double y = Double.Parse(Console.ReadLine());

            double[] top = new double[] {x};
            double[] side = new double[] {y};

            int runs = 1;
            foreach (double a in top)
                foreach (double b in side) {
                    // END-- Electronegativity Difference; Determines what kind of bond it is.
                    double END = Math.Round(Math.Abs(a - b), 2);

                    // Type-- What type of bond it is.
                    string type = "GLITCH";
                    if (END < 0.39) {
                        type = "Non-Polar Covalent NPC";
                    } else if (END < 0.99 && END >= 0.4) {
                        type = "Moderately Polar Covalent MPC";
                    } else if (END > 1 && END < 1.69) {
                        type = "Very Polar Covalent VPC";
                    } else {
                        type = "Ionic";
                    }
                    Console.WriteLine($"{(runs == 1 ? "" : "\n")}{runs++}: The bond type is {type}, with an END of {END}");
                }
        }
    }
}