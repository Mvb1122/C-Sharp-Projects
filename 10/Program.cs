// A REPL of this program can be found at https://replit.com/@mb1122/Learning-C-REPL10
// The most up-to-date version of this program can be found at https://github.com/Mvb1122/C-Sharp-Projects/blob/main/10/Program.cs

// So, this is just a brief overview of running code from other files. 
using System;

// How do we run code from other files?
    // It's relatively simple; all we have to do is put it in the same namespace.
namespace _10
{
    internal class Program
    {
    // As an example, you can click over to the Example.cs file to see the code for an object that we're going to use here.
        static void Main(string[] args)
        {
            Example x = new Example();
            x.ExampleMethod();

// That's pretty cool, but what actual use does keeping code in different files serve?
    // When we seperate code into different files, it helps keep it organized. By being organized, we can remember what class does what.
    // Also, keeping code in its own files makes it easier for people to read your program, if they want to.

    // Also, it keeps you from making 500-lines-in-one-file programs, which usually take forever to compile, since the whole file has to
    // be recompiled everytime you want to run it-- seperating into seperate files speeds up compilation because only the part you change 
    // gets recompiled.
        }
    }
}