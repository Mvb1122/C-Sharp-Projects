// A REPL of this program can be found at https://replit.com/@mb1122/Learning-C-REPL7
// The most up-to-date version of this program can be found at https://github.com/Mvb1122/C-Sharp-Projects/blob/main/7/Program.cs;
using System;

// When I first started this series, I wrote:
    // C# is Microsoft's version of C++, which is to say that it's C, except with classes.
// And so, we're going to be talking about the classes thing there, this time, I guess.

// What are classes?
    // Classes, in effect, are just custom data types-- the kind that you can create.
    // They're useful for really anything; you could store all the information on a Student, for example.
    // Each class can contain methods, like we've made in the past, and members, which are attached
    // variables to a class.

// How do we make one?
    // In the past, you may have noticed the line "internal class Program" in these demos,
    // and it turns out, that's how you make a class!

    // EG; to simply create a class, you just use the keyword "class" and then put the name of the
    // class to create.
        // (We'll talk about the "internal" keyword eventually, probably.)

    // For other reasons, you also have to be within a namespace, which is a grouping of classes.
        // (We'll talk about name spaces later...)
namespace _7
{
    // Oftentimes, classes will be declared in separate files with the name of the class as the title,
    // and with the extension ".cs"
        // You can see this in my other examples, if you want.

    // Let's create a class, for tracking the information that a student has, as an example:
    class Student
    {
        // We can create members just by putting the declaration in the class, like this:
        int id;
        string name;
        int age;

        // As a note, we can create an property, which effectively acts as a member that controls how another 
        // member can be set or retrieved. We make them like this:
        public int Age
        {
            get { return age; }
                // As a note, we can avoid the extra code by simply putting a semicolon there, instead of the entire
                // `{ return age; }` part.
            set { 
                // Since you can't have an age less than zero, we'll compare the "value" to zero,
                // and only assign it if it's greater than zero.
                    // Note that the "value" keyword is just the assigned value to the variable.
                if (value > 0)
                    age = value; 
                else
                    age = 0;
            }
        }
        // Now, if we were to try to do something like student.Age = -1, the actual value would be set to 0.
            // Note that the original "age" variable is still accessible, since it's "public."
            // I'll explain what this means later.

        // Also, we can make read-only properties by just not defining a set method or by making the set method private.
            // (We can put the keyword "private" before the setter in order to make it private.)

        // We can also create methods, like we're used to.
        public int getID()
        {
            // Note that we can return the value of a class's members simply by using its name within a method.
            return id;
        }

        // As an addendum, we could also use the "this" keyword to specify the usage of a member variable or property
        // instead of a method variable.
        // Here's an example using it:
        public string getName()
        {
            return this.name;
        }

        // In order to take advantage of the fact that a class can have data attached, we have to
        // create that data in the past, with a method called a constructor, which is a public method
        // which is simply just named after the class:
        public Student(int id, string name, int age)
            // Note the lack of a return type, that's because this method
            // automatically returns the class we're constructing. 
        {
            // We can then use the keyword "this", with a dot, to signify the fields of the class.
                // Note that we do not have to use "this" if there isn't a variable with the same name in the scope.
            this.id = id;
            this.name = name;
            this.age = age;
        }

        // Additionally, we can have multiple versions of a function simply by defining it multiple times.
        // However, we *have* to make them different in some way-- in the number and/or type of variables, like this:
        public Student(string name, int age)
            // As an example, this overloaded constructor differs in the way that it lacks the id parameter.
        {
            this.name = name; this.age = age; 
            this.id = new Random().Next();
            // The above line of code gives the student a random ID. 
        }

        // We can even call constructors within constructors, like this overload with only a name being specified:
        public Student(string name) : this(name, 0)
            // We use the colon here to indicate the version of the constructor to be run.
        {
            // We could then write some code in here, to be run after the previous constructor.
            Console.WriteLine($"Created a student with the name {name} and an age of zero.");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {

// That's cool, but what good is a fancy data-structure if we can't use it? How do we use classes?
    // In order to use classes, we simply put the name of the class as the data type,
    // then the name of a variable, then use the new keyword, and call the constructor, like this:
            Student me = new Student(123, "M", 69420);

    // We could then call one of the methods of the class like this:
            Console.WriteLine($"My id is {me.getID()}");

            Console.WriteLine("Make sure to check out the code!");
        }
    }

// What the heck is a public? What is a private? Can I see your privates?
    // Public and Private are access modifiers. What this actually means is just where you can access 
    // anything that it's attached to, be it anything from a variable all the way up to an entire class.

    // Here's what public and private do:
    /*
     * public  - This thing can be accessed from basically anywhere.
     * private - This thing can only be accessed within the same class.
     */
    // Note that this isn't all of the access modifiers, and Microsoft has a list of them here:
    // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/access-modifiers


}

// Before any of you start crying about Static stuff, that's what the next one will focus on.