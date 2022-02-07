// A REPL of this program can be found at https://replit.com/@mb1122/Learning-C-REPL5
// The most up-to-date version of this program can be found at https://github.com/Mvb1122/C-Sharp-Projects/blob/main/5/Program.cs


// What if we want to reuse a peice of code, but like without using a loop?
    // (Loops are something we'll go over next time.)
    // We can use a Method-- which is a peice of code that does a specific task, and can be run multiple times.

// How do we write methods?
    // You might've noticed the "static void Main(string[] args" line down below, and that's actually the start of a method.
    // Let's skip down to line 37, where I'll explain how we make a method.
using System;

namespace _5
{
    class Program
    {
        static void Main(string[] args)
        {
            // We can call a method by putting its name, then parenthesis, like this:
            exampleMethod();
            // Now, go down to line 49 to figure out how to return values from methods.

            // We can set the return value of a method to a variable simply by putting the call to it right next to a declaration.
            int returnedValue = returnsAnInt();

            // We can pass values into a method like this, by putting the value to be passed inside of a method.
            int threeTimesThree = multiplyByThree(3);
            // Go down to line 56 to see how to get that parameter in the method.

            // This just keeps the program open after all the stuff's run.
            RunTheRestOfTheProgram();  Console.WriteLine("Remember to check out the code!");  Console.ReadLine();
        }

        static void exampleMethod()
        {
            // To create a method, we start with the keyword "static", which we'll explain later on.
            // Then, we follow it with a return type, or void, if we're not returning anything. (I'll explain this later.)
            // And finally, we put the name of the method, then parenthesis and open brackets.

            // We can then put some executable code in the brackets, like a Console.WriteLine() statement:
            Console.WriteLine("This code ran within the method!");

            // Go back up to line 20 to learn how to call methods.
        }

        static int returnsAnInt()
        {
            // We can use the "return" keyword to return a value from a method.
            return 1;
            // (Go back up to line 24)
        }

        static int multiplyByThree(int value)
        {
            // To recieve a parameter in a method, we just put the name and type of a variable in the parenthesis.
                // You can include multiple values by seperating them with a comma.
            Console.WriteLine($"Three times {value} is {3 * value}!");
            return 3 * value;

            // It's also of note that you can't use any values passed as parameters by their name outside of methods--
            // I couldn't use "value" here in another method, without calling that function and passing the value to it.
            // This concept is known as scope, since the variable is scoped down into just this method.
        }

        static int aMethodWithADefaultValue(int value = 3)
        {
            // We can also set default values for a method's parameters by settings them equal to a value in the parenthesis.
            return value * 3;
            // That equal sign will only be run if a value for that paremeter wasn't passed at the start.
        }

// What if our method has a lot of paremeters, all of which have default values, but we only want to set one of them when we call it?
    // We can simply call that function whilst addressing that value by name, like this:
        static void callingParametersByName()
        {
            aMethodWithALotOfDifferentParameters(c: 3);
            // We put the name of the parameter, then a colon, and then the value we want to pass into it.

            // It's also of note that you can pass values in any order you want, like this:
            aMethodWithALotOfDifferentParameters(a: 2, d: 5, c: 2, b: 3);
        }

        static int aMethodWithALotOfDifferentParameters(int a = 3, int b = 5, int c = 5, int d = 25)
        {
            return a * b * c * d;
        }

// What if we want a method to change its actions based off of what's passed to it?
    // We can use method overloading, which allows us to take different actions based off of the parameters passed to a method
        static void RunTheRestOfTheProgram()
        {
            // We can call methods with overloads like this:
            aMethodWithOverloads("5");
            aMethodWithOverloads(5);

            runMoreProgram();
        }

        // Then, to create an overload, we simply create different versions of a function which are named the same thing.
        static void aMethodWithOverloads(String aNumber)
        {
            int aNumberButItsANumberAndNotAString = Int32.Parse(aNumber);

            // Note that you don't have to call a method with overloads' other forms, but this example does.
            aMethodWithOverloads(aNumberButItsANumberAndNotAString);
        }

        // Overloads must either have a different number of parameters or accept parameters of different types.
        static void aMethodWithOverloads(int aNumber)
        {
            Console.WriteLine($"Your number was {aNumber}.");
        }

// I heard something about the "out" keyword, what's that?
    // The out keyword allows us to almost, kinda, return two values from a method.
        static void runMoreProgram()
        {
            // Here's an example using out, which converts a string to an int.
            string aNumber = "36"; int anActualNumber;
            bool canBeConverted = Int32.TryParse(aNumber, out anActualNumber);
            // In the line above, we set the value of canBeConverted to wether or not we could turn aNumber into an actual number,
            // and then we set the value of the conversion to anActualNumber.

            // Now, let's see how it works in practice: read the code to outExample(), then come back here.
                // First, we'll declare the secondary result variable (just like, where the out data goes.)
            int divByThree;
            bool canWeDivideNineByThree = divisibleByThree(9, out divByThree);

            // We could then output some stuff to the user, like this:
            if (canWeDivideNineByThree)
                Console.WriteLine($"We can divide 9 by three and the result is {divByThree}");
            else
                Console.WriteLine("We cannot divide 9 by three.");

            moreProgramTwoElectricBoogaloo();
        }


        static bool divisibleByThree(int aNumber, out int dividedByThree)
        {
            // In the declaration above, we write the declaration of the variable to output after the keyword "out", and then
            bool result = aNumber % 3 == 0;
            if (result) dividedByThree = aNumber / 3;
            else dividedByThree = -1;

            return result;
        }

// UGH, that's SO much to type... What if I want to create a method on only one line?
    // We can use expression body definitions, which effectively allow you to create methods without having to deal with the hassle of using keywords and brackets.
    // They're only really useful for cases where you just want to return the value of an expression, like if you were checking if a number is divisible by three or not.
    // To make them, we just start off a method like we normally would, but then we use a fat arrow (=>) to "point" to the expression we want to use.
    // As an example, here's the divisibility test again, but with an expression-body definition. 
        static bool divisibleByThree(int aNumber) => aNumber % 3 == 0;

    // In the above example, we return the value of the boolean expression "aNumber % 3 == 0", to wherever the method was called from.
    // Note that with expression body definitions, you can't use them in cases where you'd run more than one line of code.

// Quick note here guys, sometimes you can pass methods as parameters to other methods, here's an example:
        static void moreProgramTwoElectricBoogaloo()
        {
            // Here, we're creating a list of numbers to check if they're divisible by three.
            int[] numbers = new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
                // Don't worry too much about this, but we'll cover it next time, probably.

            // Next, we'll use the Array.Exists() method to check all of them.
            bool result = Array.Exists(numbers, divisibleByThree);
                // In the background, this method calls the divisibleByThree() method on all of the objects, and returns true if any of them are divisible by three.

            // Next, we'll tell the user about it.
            Console.WriteLine($"Does the list contain a number divisible by three?: {result}");

// Okay... Nice example and all that, but what if like, we don't want to declare a method just to check it on an array?
    // We can use Lambda expressions, which are sorta like expression body definitions, except that they sit within another method:
    // To create one, instead of passing the name of a method to the Array.Exists() method, we can just put an expression definition in there--
        // We put a type-less parameter name in parenthesis, then use a fat arrow to point to the expression we want to evaluate, like this:
            result = Array.Exists(numbers, (a) => a % 3 == 0);
        // Note that it's type-less, since it just uses each value in the Array, so it inheirits the type from there.
    // Also, you could even remove the parenthesis, if you've only got one parameter.
        // (You can use multiple.)
    // Arrays are something we'll cover next time, so don't worry too hard about it.
        }
    }
}

// Alright, that's it, sorry about it being a long one, this time, I guess. 