// A REPL of this program can be found at https://replit.com/@mb1122/Learning-C-REPL8
// The most up-to-date version of this program can be found at https://github.com/Mvb1122/C-Sharp-Projects/blob/main/8/Program.cs;
using System;

namespace _8
{
// What is "static"?
    // "static" is a keyword which indicates that a piece of a program should be shared across a class. 
    // So, what it actually means is that a variable should be the same across any object of a class.

    // Let's revisit the Student Class from last time, but this time with a static numStudents variable:
    class Student {
        // What this says is basically that there is this number, which is the same across all the objects.
        static int numStudents;
            // Note that you can use static on basically anything:
            // classes, objects, methods, members, and Properties.

        // And we put it along with any other variables or whatnot in the class:
        int id, age; string name;

        public Student(string s) : this(s, 0) {
            Console.WriteLine($"Created a Student with the name \"{s}\" and an age of zero.");
        }

        public Student(string name, int age)  {
            this.name = name;

            // See, since numStudents is static, it retains the same value whenever a student is made
            // And so we can reference it to choose an ID. And if we manipulate it, the change is shared.

            // For this example, we start giving students an ID at zero, and then we increase the id after it's assigned.
            // So in effect, the first student has the id 1, the second has id 2, and so on...
            id = numStudents++;
            this.age = age;
        }

        public int GetID() {
            return this.id;
        }

        // We can also make methods static, but they won't have access to any of the members of an actual
        // object. For instance, you could make a static method which gets the number of students,
        // like this:
        public static int GetNumStudents()
        {
            return numStudents;
        }

    // As an aside, you can initialize static variables using a static constructor, like this:
        // Note that it's created without being labeled public or private.
        static Student()
        {
            numStudents = 1;
        }

    // This just sets the value of numStudents to one,
    // so that way the program knows to start it at one student.
        // If we didn't make this constructor, it would start at zero, which is the default value
        // for `int`s. 
    }

// A bit ago, you mentioned making classes static, how does that work?
    // When we make an entire class static, it makes it so you can't have any real operations
    // storing information-- you can't use variables outside methods.
    // For example, we might want to make a static class if we're making something like a math library,
    // or a utility.

    // As an example, here's a class which sums up an array of numbers.
    static class MathStuff
    {
        public static int Sum(int[] numbers)
        {
            int sum = 0;
            foreach (int number in numbers)
                sum += number;

            return sum;
        }
    }


// Okay... But what's it actually useful for?
    // Static variables are useful for all sorts of things, but most usually just values that are shared across every object 
    // in a class.

    // For a few examples, you might use static variables to:
    /* 
        track the number of students, since each student doesn't need to keep their own count.
        track the X and Y locations of a mouse pointer, since you can only have one pointer.
        track the number of people who are alive.
        etc...
    */

    internal class Program
    {
// Now that you've learned what static means, you should be able to figure out what 
// the line below means.
        static void Main(string[] args)
    // Yeah, that's right. This entire time, we've been using a static method to run the program.
    // Main() is a function called by C# when the program's run, if you didn't know, somehow.
    // By the way, when we run these programs with "dotnet run", you can pass variables to the program
    // by writing them after the end of the "run" part, and they'll be converted to Strings and
    // sent into the program.
        // EG; if we ran "dotnet run 12345", the args variable would contain {"12345"}.
        {
    // Here's a show-off of the stuff we wrote earlier.
            Student me = new Student("Micah", 16);
            Console.WriteLine($"My ID is {me.GetID()}.");

            Student secondStudent = new Student("Second");
            Console.WriteLine($"The second student's ID is {secondStudent.GetID()}.");

// BTW, here's how you use a static method on a static class:
            int[] numbers = {1, 2, 3};
            int sum = MathStuff.Sum(numbers);
            Console.WriteLine($"The sum of numbers is {sum}");

            Console.WriteLine("Remember to check out the code! It explains the stuff.");
        }
    }
}