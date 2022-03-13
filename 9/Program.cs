// A REPL of this program can be found at https://replit.com/@mb1122/Learning-C-REPL9
// The most up-to-date version of this program can be found at https://github.com/Mvb1122/C-Sharp-Projects/blob/main/9/Program.cs

using System;

namespace _9
{

// What if we want to have different behaviors taken on similar objects? For example, paper is recycled differently from tin, 
    // so how would we do something like that?
    // We can use something called an interface to make it so that we can easily run similar actions on different objects.
    // I like to think about it as building the foundation of a house, and then you can build like, rooms and whatnot on top of the foundation.

    // I digress; an Interface is effectively just a platform for us to write similar code on. 
    // Here's how we make and use one:

    // We use the keyword "interface" and then place a name for it, begun with a capital I, to create an interface.
    interface INumber {
        // Once inside, we can only place static variables, Properties or methods.
        public int getNumber();
        public void setNumber(int number);
    }

    // Now, we can use it in a class, like this:
    public class X3 : INumber
        // We use a colon to signal the interface that we're using.  
    {
        private int number;
        public X3(int number) {
            ((INumber) this).setNumber(number);
            // As an addendum, you can't use the interfaced methods directly within the class's methods, but
            // you *can* just cast the object to the interface and then use the methods that way.
            // The line above just calls the setNumber method as the interface.
        }

        // Note that a class which implements an interface *MUST* implement all of the items in the interface.
        void INumber.setNumber(int number) { this.number = 3 * number; }
            // To signify that we're creating a method for the interface, we have to 
            // place the name of the interface before the name of the method that we're implementing.

            // Or you can just make the method public or property public and the compiler will figure it out for you.
        int INumber.getNumber() { return number; }
    }

    // Now, for the biggest feature, we can create another class which also uses the same interface: 
    public class X4 : INumber
    { 
        private int number;
        public X4(int number) {
            ((INumber) this).setNumber(number);
        }
        public void setNumber(int number) { this.number = 4 * number; }
        public int getNumber() { return number; }
    }

    internal class Program
    {
// Okay, but how do we use it?
    // To use an interface, we can treat it like any other object:
    // Once we're within a method, you can treat it like anything else, except you have to initialize it with the
    // constructor of a class that implements the interface. You can also just create them as normal, then interpret them as the interface.
        static void Method1() {
            X4 multiplyByFour = new X4(4);
            X3 multiplyByThree = new X3(3);

    // Once we've gotten them, we could do what's done most often: put the interfaces into an array so that we can loop over it.
            INumber[] numbers = new INumber[]{ multiplyByFour, multiplyByThree };

            foreach (INumber number in numbers) {
                Console.WriteLine($"The number {number.getNumber()} is actually an {number.GetType().Name}!");
            }
        }

        static void Method2() {
    // Here's the same example where the objects are made directly into an array.
            INumber[] numbers = new INumber[] { new X4(4), new X3(3) };
            
            foreach (INumber n in numbers) {
                Console.WriteLine($"The number {n.getNumber()} is actually an {n.GetType().Name}!");
            }
        }

        /// <summary>
        /// This method just runs the entire program.
        /// </summary>
        /// <param name="args">The arguments passed to the Program.</param>
        static void Main(string[] args)
        {
            Action[] parts = new Action[]{Method1, Method2};
            foreach (Action action in parts)
                action();

            Console.WriteLine("Remember to check out the code!");
        }
    }
}