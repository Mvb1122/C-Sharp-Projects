// A REPL of this program can be found at https://replit.com/@mb1122/Learning-C-REPL1?c=171590
// The most up-to-date version of this program can be found at 

// C#, what is it?
// C# was invented in 2000 when Anders Hejlsberg from Microsoft decided that we didn't have enough programming languages and so decided that it would be funny if he made one.
// EMCA later approved the language and it has since been a standard for computing. C# is a little bit slower than C++, and even moreso slower than C. In relation to Java, it's about the same speed, except a little bit slower.
// C# is slower to compile than Java, too.
// Overall, to a Java user, it seems like it's basically the same thing, except "import" is replaced with "using" and namespaces are a thing.

// Why is it C# and not C-Flat? How does it relate to C++ and C itself?
// C# is Microsoft's version of C++, which is to say that it's C, except with classes.


// Here's the standard "Hello World" program:
// Although I also edited it just a little bit to show off readign from the console.
// The "using System" line here says that the program should be compiled with the Console and other standard libraries, a little like <using namespace std> does in C++, or like importing java.lang.* does in Java.
// Note that, for C# at least, you **have** to use System in order to use the Console.
using System;

    // This "namespace HelloWorld" line declares that this program takes place in the HelloWorld namespace-- that this group of classes and methods can be used by simply "using HelloWorld", but we'll get to that later.
namespace HelloWorld
{
    // This "class Program" line declares an instantatiateable object format (read: a class), that is named "Program"
    class Program
    {
        // This is the Main() method-- it runs whenever the program is started.
            // We'll take another look at this eventually. 
        static void Main(string[] args)
        {
            // This Console.WriteLine() line prints out the information contained inside the parenthesis. 
            Console.WriteLine("Hello World!");

            // Now, here's a little demo of what a more-robust program might actually look like:
                // First, we ask the user to enter a value.
            Console.WriteLine("Enter a boolean value (True/False)");
                // Then, we can do a little something like this:
                    // First, we use the Console.ReadLine() method to read in input from the user.
                    // Second, we use the Boolean.Parse() function, which is included with System, to turn that read-text into a boolean that the computer actually understands.
                    // And finally, we set that boolean value to the value of a variable, x, of type bool.
            bool x = Boolean.Parse(Console.ReadLine());
                // Of course, we'll take deeper looks at all this eventually.

                // And then, as a demo of template strings, we tell the user what their inputted value was, and what the opposite was.
                    // eg; if you put in "true" it would read this: "Your boolean was True, the opposite was False"
            Console.WriteLine($"Your boolean was {x}, the opposite was {!x}");

                // Then, to stop the console window from closing immediately, we tell the computer to read in from the console, but don't do anything with the value.
            Console.ReadLine();

            // At the end of the Main() method, the program closes automatically, just like in Java.
        }
    }
}
