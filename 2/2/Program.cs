// A REPL of this program can be found at https://replit.com/@mb1122/Learning-C-REPL2
// The most up-to-date version of this program can be found at https://github.com/Mvb1122/C-Sharp-Projects/blob/main/2/2/Program.cs

// Forgoing all the sappy commentting stuff, this lesson's going to focus on variables-- that "x" thing I used in the last lesson.

// What's a variable?
    // Effectively, a variable is a little peice of information that a computer holds on to, and can track for us.

// What components make up a variable?
    // Well, there are three main components to a variable, the Data Type, the Name, and the Assignment, although this only goes for strongly-typed languages, like C#.
        // In looser languages like Python, you only have the Name and Assignment components. (Although Python lets you "hint" at a variable's type.)
    // Although this lesson will mainly focus on the Data Type component, you will see the other two constantly demonstrated.

// What common data types are there?
    // A few common data types are:
        // the Integer, int, which is a whole number;
        // the String, string, which is a list of letters;
        // the Boolean, bool, which is a true/false value;
        // the Double, double, which is a decimal number;
        // the Character, char, which is a single letter;
    // Note that these are not the only types, and you can in~fact create your own, which we will focus on in a later lesson.

// What's the difference between Integer and Double?
    // Mainly, the precense of decimals, but there's also a difference in range-- Double can hold any number between positive and negative 1.7x10^305, while Integer can only hold values
    // between -2,147,483,648 to 2,147,483,647, where Integer can **only** hold whole numbers, without Decimals. 

// How do you declare a variable?
    // Well, first, you have to start writing a program, so write something like this: (We will focus on this in a later lesson.)
using System;

namespace _2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Now that you're in a program, you can start the line with the Data Type:
            int
            // And then you follow that with a name and an equal sign,
            aNumber =
                // Also, note that a name can't include apostrophes, or start with a number-- you can name something _2 but not 2.
            // And then, to cap it all off, you follow it with a value and a semicolon:
            36;

            // Written down all on one line, that looks like:
            int anotherNumber = 36;

                // Even though C# is a strongly-typed language, which means it has strict syntax rules, it ignores white-space, and comments like these, which means that we can write things out on multiple lines, like above.
    
    // Additionally, we can declare multiple variables at once like this:
            int aThirdNumber, aFourthNumber;
            // In which case, we'd have to assign each variable seperately, like this:
            aThirdNumber = 3;
            aFourthNumber = 4;
        

            
// What kind of other assignments are there, besides the direct assignment?
    // Besides what's called a "Literal", where you directly set the value of a variable, you can set a variable's value based on anything that evaluates to the specified data type, like this:
            int aFifthNumber = aNumber * anotherNumber;
    // In this program, the value of aThirdNumber will be equal to 1296, since that's 36 * 36.

// So far, we've only seen int assignments, what do assignments look like in other Data Types?
    // For Strings, it looks like this:
            string aString = "I'm a string.";
        // In Strings, a value is wrapped with quotes to show where it starts and ends.
        // We'll go into other kinds of strings, like Template Strings, in a future lesson.
    
    // For Boolean, it looks like this:
            bool aBoolean = true;
        // For Booleans, you can either set them to true or false, or the value of a boolean expression, which we'll go into in a future lesson.

    // For Double, it looks like this:
            double aDouble = 36.9;
        // For Doubles, you can include a decimal value, like the .9 in this value.
        // If you don't include one, the Compiler will "put" one there for you, a zero.

    // For Character, it looks like this:
            char aCharacter = 'A';
        // Unlike Strings, Characters are ended and started with single apostrophes, and only contain one character.
        // So they could include something like '2' or '§', since both of these are only characters.
        // Additionally, you can't "add" together characters, like if I had '6' + '2', I would get an error instead of 8.

// How do we convert between different types of variable?
    // There are two types of conversion between Data Types, Explicit and Implicit.
    // Explicit is when you specifically choose a class to change to, via a method called Casting.
        // For example, if I wanted to turn a Double into an Integer, I could do something like this:
            aNumber = (int) aDouble;
            // Note, we specify the converted class inside the parenthesis.
        // This only works with classes that extend eachother.
    // The other kind, implicit, is when you put a variable of lower precision into a variable of higher precision-- when you turn Doubles into Integers.
        // Like this:
            aDouble = aNumber;
            // Note that you don't have to do the parenthesis here, since it's implied.
            // This also works for classes you make yourself, which we'll go into in a future lesson.

            // Additionally, Convert, a library packed in with C#, lets you convert variables into other types:
            // Moreso than what the default relationships allow you to do: 
            aNumber = Convert.ToInt32(aCharacter); // aNumber now holds the value of 65, since that's the character code for 'A'
                // Although you can usually get away with just using the default libraries.

// How do we do math with variables? How do we assign the result of math to a variable?
    // You can do math with variables by using the name of a variable, followed by an operator, and then the second variable's name.
    // This forms a statement, which we can use to assign the result of the math to another variable like so:
        // Compute a number ^2
            int aSquaredNumber = aNumber * aNumber;
        //                               ^ Here's the operator, which we'll go over C#'s list in a bit.
    
// What math operators does C# have?
    // C# has the following:
        /*
            *, the multiplication operator,
            +, the addition operator,
            -, the subtraction operator,
            /, the divsion operator,
            and %, the remainder operator.
            Among others, like assignment operators, and even the ability to "overload" an operator, which is something we'll go over in a future lesson.
         */
    // Also, whenever you're doing math, the result will always be in the *most* precise type of number involved; if you're dividing an integer by an integer, the result will be an integer, and therefore lack decimal places.

// Quick note here, if you're using Decimal or Long, which are larger number classes, you have to follow any literal of a value for those with an m or L, respectively.
        // Like this:
            long aLong = 69420177013L;
            Decimal aDecimal = 69420m;

// What are assignment operators?
    // If you're not familiar with a programming language already, an assignment operator is effectively an operator that both does a math operation and assigns it back to the variable that it was pulled from, all at once.
        // For example, if we wanted to square aNumber and assign it back to itself, we could do something like:
            aNumber *= aNumber;
        // Note that you could replace the * here with any of the other listed operators above and it'd work just fine.

    // There's also another kind of assignment operator: increment and decrement operators.
        // These basically increase or decrease the value of a variable by one.
            aNumber++;
        // This just increases the value of aNumber by one.

// What if I want to do more complex math? How do I do absolute value? Minimum/Maximum?
    // In order to do more complex math, C# has a number of built-in Math functions, like:
    /*
     * Math.Abs(), which finds the absoulte value of a number,
     * Math.Sqrt(), which finds the square root of a number,
     * Math.floor(), which rounds down a number to the nearest whole number.
     * and Math.Min(,) which returns the lesser of two numbers.
     */
    // Among others. Here's how to use one.
            aNumber = -15;
            aNumber = Math.Abs(aNumber); // aNumber now holds 15.

            Console.WriteLine("This program doesn't output anything, so just open the code and read it.");
        }
    }
}
