// A REPL of this program can be found at https://replit.com/@mb1122/Learning-C-REPL4
// The most up-to-date version of this program can be found at https://github.com/Mvb1122/C-Sharp-Projects/blob/main/4/Program.cs


// This lesson talks about Booleans and Boolean Expressions, then goes onto describe control flow stuff, like If Statements, so yeah, that's what this'll cover.

// What is Boolean? What is a Boolean Expression?
    // A Boolean is a simple true or false value-- computers use them to determine actions to take (focused on in the next lesson.)
    // A Boolean Expression, on the other hand, is simply an expression that evaluates to a boolean-- and usually involves logical operators.

// How do we initialize a boolean?
    // Well, first, we have to be within a place where we can actually put code, so skip to line 22.
    // (We'll explain all the stuff in-between eventually.)
using System;

namespace _4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Make sure to read the code! It's commented out to explain everything.");

            // Just like any other variable declaration, we start with the data type, then follow it with a name, all followed by an assignment:
            bool aBoolean = true;
            // Note that we use the Data Type bool for Boolean values.


            // What is a boolean expression?
            // Unlike mathmatical expressions, boolean expressions evaluate conditions by using Boolean operators, like:
            /*
               Equals, ==, which returns true if the value to the left is equal to the value to the right,
               Not-Equals, !=, which returns true if the two values are not equal,
               Less than, <, which returns true if the value to the left is less than the value to the right,
               Greater than, >, which returns true if the value to the left is more than the value to the right,
               Less than or equal to, <=, which returns true if the value to the left is less than or equal to the value on the right,
               and Greater than or equal to, >=, which returns true if the value to the left is more than or equal to the value to the right.
            */
            // As well as a few others that we'll get around to talking about later.
            // So, as an example, here's a boolean expression that evaluates if three is less than four:
            bool expression = 3 < 4;
                // Note that you don't have to make a seperate boolean variable in order to use a boolean expression.
            Console.WriteLine("Is three less than four?: " + expression);

// What if we want to compare the results of boolean expressions using Logical Operators?
        /*
            We can use logical operators, like:
            Not, which inverts the value to its right,
            And, &&, which returns true if both of the values on the left and right are true.
            and Or, ||, which returns true if at least one of the sides is true.
        */
            // So can do something like this: if we wanted to check if a number is less than 12 and greater than 7, we can write something like this:
            int aNumber = 6;
            expression = aNumber < 12 && aNumber > 7;
            Console.WriteLine("Is 6 less than 12 and greater than 7?: " + expression);


// "Alright," you ask, "but what if we want to do other stuff with it? What if we want the program to do different things based on a boolean condition?"
            // We can use something called "Control Flow", which are just statements that change their action based off of a boolean value.
            // To start, here's the most basic of control flow statements, the If-Else statement:
                // The code of an If-Else statement is only run *if* the boolean is true, and the else part's code only runs if it's false.
            if (false)
            {
                Console.WriteLine("This code won't run, since the boolean in the parenthesis above is false.");
            } else
                // Note that you don't have to include an "else" case, but the option is there.
            {
                Console.WriteLine("But this code will run, since the boolean is false.");
            }

            // As a second example, we'll remake the condition from earlier, but in the form of an If-Else statement:
            if (aNumber < 12 && aNumber > 7)
            {
                Console.WriteLine("Yes, " + aNumber + " is less than 12 and greater than 7.");
            } else
            {
                Console.WriteLine("No, " + aNumber + " is not less than 12 and greater than 7.");
            }

// Okay, but what if we want to check multiple conditions before running code?
            // We can check multiple conditions by using else-if statements at end of an If statement
            // As an example, if we want to do different things based on the value of a number, we can use if-else-if statements:
            if (aNumber == 3)
            {
                Console.WriteLine("Your number is 3");
            } else if (aNumber == 4)
            {
                Console.WriteLine("Your number is 4.");
            } else if (aNumber == 5)
            {
                Console.WriteLine("Your number is 5.");
            }
            // Also, if you don't have an "else" statement, the program won't do anything if none of the conditions are met, so let's put that in.
            else
            {
                Console.WriteLine("Your number isn't three, four, or five.");
            }

// That's cool and all, but it seems pretty inefficient for checking a bunch of different situations. Is there anything better?
            // Yeah, we can use the Switch statement, which is basically a list of values, where code is run if it is equal to the passed value.

            // They're written like this:
            switch (aNumber)
                // A value in the parenthesis is passed to the conditional.
            {
                // We use the keyword "case" to start off, then put the value to equal with and a colon.
                case 3:
                    // Then we put some code.
                    Console.WriteLine("Your number is still 3.");
                    // And then we use the "break" keyword to break from the conditional.
                        // Note that if you don't include the break keyword, it'll just check all of the other conditionals, until it reaches the end.
                    break;
                case 4:
                    Console.WriteLine("Your number is still 4.");
                    break;
                case 5:
                    Console.WriteLine("Your number is still 5.");
                    break;

                // Then, we use the "default" keyword to signal code to be run in case none of the above conditionals are true.
                default:
                    Console.WriteLine("Your number wasn't three, four, or five.");
                    break;
            }

// What if we want to set the value of a variable based off of a condition?
            // We can use something called a Ternary operator-- it works like this:
            bool condition = true;
            int trueValue = 5;
            int falseValue = 3;
            // First, we put a condition in parenthesis, then we put a "?" and then the value that we want when the condition is true, 
            aNumber = (condition) ? trueValue : falseValue;

            // In practice, this looks like:
            aNumber = (true) ? 5 : 3;



            // This just keeps the window open at the end of the program.
            Console.ReadLine();
        }
    }
}
