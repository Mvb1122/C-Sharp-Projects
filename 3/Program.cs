// A REPL of this program can be found at https://replit.com/@mb1122/Learning-C-REPL3
// The most up-to-date version of this program can be found at https://github.com/Mvb1122/C-Sharp-Projects/blob/main/3/Program.cs


// This lesson focuses on Strings and their multitude of methods.
    // Skip to line 15, I guess.
using System;

namespace _3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Make sure to read the code! It explains everything new!");
            // What are Strings?
                // Strings are lists of characters, just like the "Hello World!" message below.
                // They're started with a quote and ended with a quote, unlike Characters, which are capped by apostrophes.
            Console.WriteLine("Hello World!");
                // Most often, they're used to hold words or to output information. 

            // How do we initialize a String?
                // Just like any other variable, you start with a data type; in this case, string; followed by a name and an assignment.
            string aString = "I am a string.";

            // What if we need to put quotes in a string? Wouldn't that end the string?
                // Well, you can use a \ backslash before a character in order to have the compiler include it in the string--
                // and for quotes, this means that they can be included like so:
            aString = "I am a string, \" that includes quotes in itself.";

            // What if we wanted to start on the next line?
                // We can use \n to signal the start of a new line:
            aString = "I am a string \non multiple lines.";
            Console.WriteLine(aString);
                // Note, however, that the \n will immediately start up the next line, so if you put a space after it, it will push
                // the rest of the letters over.

            // What about putting strings together? How do we merge them?
                // To merge strings, you can "add" them together, in a process known as concatenation. 
                // To do it, all you do is place two strings next to eachother, with a plus in-between.
            string anotherString = aString + " ~and I added onto it!";
            Console.WriteLine(anotherString);

            // What if we want to put a String inside of another String?
                // We can use something called "String Interpolation", which functions basically the same as JavaScript's template strings:
                // To use it, you put a $ before the start of the quote, and then put the name of the variable you want to insert in {}
                // curly brackets, like this:
            string bigString = $"I encapsulate this string: \"{anotherString}\"\nwow isn't that cool?";
            Console.WriteLine(bigString);

            // What if we want to find how long a String is?
                // We can use the .Length property of the String, like so:
            Console.WriteLine("That big string is " + bigString.Length + " characters long.");

            // What if we want to find a specific part of a String's location?
                // We can use the .IndexOf() method to find it, by passing in the part of the string that we want to find, like so:
            int locationOfAnd = bigString.IndexOf("and"); // Holds 63, since "and" starts at the 63d character, starting at 0.
            Console.WriteLine($"The first time that \"and\" is in the string, is at {locationOfAnd}.");

            // What can we do with the index? Can we get strings from inside other strings?
                // After we've got an index, we can use a method, called Substring(), that fetches from a index to the end of a String, like this:
            string andToEnd = bigString.Substring(locationOfAnd);
            Console.WriteLine("The string from \"and\" to the end is: '" + andToEnd + "\"'");

                // We can also get a Substring from one point to another, by specifiying a length, like so:
            string and = bigString.Substring(locationOfAnd, 3);
                // Note that I hard-coded the length of 3 here, since and is three letters long, but you could use a variable to determine it.
            Console.WriteLine($"and: {and}");

            // What if we just wanted to get *one* character, how do we do that?
                // You can fetch a character at a location by putting brackets at the end of the string's name, and then putting an index inside the brackets, like this:
            char thirdCharacter = bigString[2]; // Note that strings are 0-indexed, so position 2 is actually position 3, since position 0 exists.
            Console.WriteLine($"The third character is {thirdCharacter}.");

            // WHAT IF YOU'RE REALLY ANGRY AND NEED TO CAPITALIZE EVERYTHING?
                // You can become enraged by using the ToUpper() method:
            string shouting = "I'm really angry.".ToUpper();
            Console.WriteLine("ToUpper: " + shouting); // Outputs: "ToUpper: I'M REALLY ANGRY."

            // what if you like... are kinda shy and need to have everything lowercased?
                // You can make everything lowercased by using the ToLower() method:
            shouting = shouting.ToLower();
            Console.WriteLine("ToLower: " + shouting);


            // This just keeps the program open at the end, until the user hits "enter."
            Console.WriteLine("Press enter to close the program.");
            Console.ReadLine();
        }
    }
}
