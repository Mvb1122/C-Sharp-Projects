// A REPL of this program can be found at https://replit.com/@mb1122/Learning-C-REPL6
// The most up-to-date version of this program can be found at https://github.com/Mvb1122/C-Sharp-Projects/blob/main/6/6/Program.cs

using System;

// Last time, I said I'd focus on doing Arrays the *next time* and now it *is* that time, so here we are; Yup, this is the Arrays lesson.

// What are arrays?
    // Well, arrays are simply organized lists. They can be of anything, but they're always in order and they always have a set length.
    // In effect, they provide an easy way for us to "loop" through a bunch of things, something we'll also cover here.

// How do we make an array?
    // Well, to make an array, we have to first be within a method, so let's skip down to line 20.
namespace _6
{
    public class Program
    {
        public static void partOne()
        {
            // Once we're within a method, we can create an array by putting a type, then square brackets,
            // and then a variable name, like this:
            int[] numbers;
            // Next, we could add values to the array, by putting them within curly brackets, and seperated by commas,
            // after the "new" keyword and the type next to brackets:
            numbers = new int[] { 1, 2, 3, 4, 5 };
            // Note the "new" keyword here, which tells C# to create space for the array.

            // We can even compact this onto one line, like so:
            /*int[]*/ numbers = new int[] { 1, 2, 3, 4, 5 };
                // Note that I commented out the type declaration, since it would cause an error to re-make that same variable.

// What can we actually do with an array?
    // Well, once we've got an array, we can take the length of it, using the .Length property.
            Console.WriteLine($"There are {numbers.Length} items in the list!");

    // Additionally, we can get individual items by putting a number in square brackets to ge the item at that location.
            int numberAt4 = numbers[4];
        // Note that arrays start their numbering at zero, so that's why this prints out 5 instead of 4. 
            Console.WriteLine($"The number at index 4 is {numberAt4}");

    // We can also set the values of an array using the same method:
            numbers[4] = numbers[numbers.Length - 1];
                //              ^ this bit of code here just gets the last value in the array.

    // As an addendum, we can also use the in-built Array methods on the array:
        /*
         * Array.Sort()    - Sorts a number array from least to greatest.
         *                 - Sorts string arrays in alphabetical order.
         * Array.IndexOf() - Returns the index of a value in an array.
         * Array.Find()    - This method's a little more complex, so I'll show it off below.
         * And others, these aren't the only methods.
        */

        // Array.Find() is a method that takes in an array and a method which takes in only one value and returns a boolean.
            // Which is to say that you have to use a lambda expression, like this:
            int firstNumberGreaterThan4 = Array.Find(numbers, number => number > 4);
            Console.WriteLine($"The first number greater than 4 is " + firstNumberGreaterThan4);
            // It returns the first value, so we can just use Array.IndexOf() to find the location of it.
            Console.WriteLine($"~~Which is at index #{Array.IndexOf(numbers, firstNumberGreaterThan4)}");
        }

// Okay... But what if we want to do the same thing a ton of times? Like if we want to do the same thing to every element on an array?
    // We can use a loop, which is basically a block of code that gets run at least once.

// How do we write a loop? What types are there?
    // There are several kinds of loops, like:
    /*
     *  While loops    - Execute code While a condition is true.
     *  Do-While loops - Executes code once, then evaluates a condition, and keeps executing if the condition is true.
     *  For loops      - Executes code a fixed number of times.
     *  Foreach loops  - Executes code on each element of an Array.
     */

    // Now, in order, here's an example of each loop.
        private static void whileLoop()
        { 
            int aNumber = 1;

            // To create a While loop, we use the keyword "while" and follow it with a condition in parenthesis.
            while (aNumber < 10)
            {
                // Then we follow it with some code in brackets.
                // For this example, we're just looping while a number is less than ten, and increasing it each time.
                aNumber++;
                Console.WriteLine($"While Loop: Increased the value of aNumber, it's now {aNumber}.");
            }
            Console.WriteLine($"The final value of aNumber is {aNumber}.");

            // Quick Note: Sometimes, a While loop can go on forever, those are called "Infinite Loops."
        }

    // Do while loops are very similar to while loops, except they differ in the way that Do-While loops will run 
    // *at least* once, and then evaluate a condition-- While loops won't run if their condition evaluates to false
    // on the first check.
        private static void doWhileLoop()
        {
            // For this example, we'll divide a number by three at least once, until it's less than 5.
            int aNumber = 120;

            // To create a do-while loop, we use the keyword "do", then brackets containing code,
            // and then the keyword "while" next to a condition.
                // This will evaluate the code within the brackets until the condition is false, but at least once.
            do
            {
                aNumber /= 3;
                Console.WriteLine($"Dividing aNumber by three, the value is now: {aNumber}");
            } while (aNumber >= 5);
            // Note that I loop the loop *while* aNumber is greater than or equal to 5, since that will only quit the
            // loop when aNumber is less than 5.
            Console.WriteLine($"The final value of ANumber is {aNumber}");
        }

    // For loops are the most common loops, they let us do things in each element in an array, so that's what
    // this example will show:
        private static void forLoop()
        {
            // We'll create an array.
            int[] values = { 1, 2, 3, 4, 5 };

            // Then, we'll use a for loop to go through every element in the array, like so:
                /* To create a for loop, we use the "for" keyword, then we put a number declaration
                 * in quotes, then use a semicolon to put a condition after it, and then another semicolon
                 * is used to put a bit of code to run at the end of each loop.
                */ 
            // For this example, we're starting at zero and running to the length of the values array,
            // where we increase i by one after every loop.
            for (int i = 0; i < values.Length; i++)
            {
                // Then, we're going to output each value in the loop.
                Console.WriteLine($"Value number {i} is {values[i]}");
            }
        }

    // Alright, as our last loop type, we'll look at how to make for-each loops.
        private static void Main (String[] args)
        {
            // For this example, we'll be using a for-each loop to run every part of this program.
                // First, we'll create an array of all the methods in the program.
            Action[] parts = new Action[] { partOne, whileLoop, doWhileLoop, forLoop, breakAndContinue };
            
                // Then, we'll create a foreach loop to go through all the methods.
            /*
             * To create a foreach loop, we use the keyword "foreach" to start it off,
             * then we put a variable declaration next to the keyword "in", followed by 
             * the name of the array.
             * Then, we can follow that up with code to run, where the variable we declared earlier is an object from the Array.
             */
            foreach (Action action in parts)
            {
                Console.WriteLine($"Running method {action.Method.Name}!");
                // This call to action() just runs the selected method from the array.
                action();
            }
                
            Console.WriteLine("Make sure to check out the code!");
        }

// Okay... But why would we use any kind of loop over any other kind?
    // Choosing a type of loop to use usually depends on your use case--
    // if you're doing something where you know how many times you have to loop, use a for loop.
    // if you don't know how many times you're looping, use a while/do-while loop.
    // if you need to do the same thing to every item in an array, use a foreach loop.

// But what if we want to, like, stop a loop? What if we want to skip to the next run of a loop?
    // To stop a loop, you can use the "break" keyword. Using this anywhere within a loop will stop it.
    // To skip to the next run of a loop, you can use the "continue" keyword. Using this will just go onto the next run of the loop, or quit it depending on the conditions of the loop.
        private static void breakAndContinue()
        {
            // Here's an example of breaking from a loop: We'll increase a number by one each time the loop runs, and break if its square root is greater than 4.
            int number = 0;
            while (true)
            {
                if (Math.Sqrt(++number) > 4f) break;
                // This is a bit of complex syntax, but basically it's increasing the value of number by one, then evaluating if the number's Square root is greater than 4, and
                // if it is, it breaks.
                Console.WriteLine($"The value of number is {number}, its square root is {Math.Sqrt(number)}");
            }
            Console.WriteLine($"The final value of number was {number}, and its square root was {Math.Sqrt(number)}");


            // Now let's demo continuing in a loop; we'll loop through an array, and set all of the values to six, except for seven.
            int[] values = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] != 7) values[i] = 6;
                else continue;
            }

            Console.WriteLine($"The final values in the array were [{String.Join(", ", values)}]");
        }
    }
}