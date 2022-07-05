using System;

// This lesson covers inheritance, overriding, and being overridden, so yeah.
// Pretty cool.

// What is inheritance?
    // inheritance, in OOP, is the concept that objects of one class can gain, or inherit, properties from other classes.
    // In effect, it basically means that you can write less repetitive code by re-using parts from other classes that you've already written.

namespace _11
{
// How does inheritance work?
    // In order to have inheritance, we need at least two classes.
    // For this example, we'll be using cars.
    public class Vehicle {
        // All vehicles have things like wheels and speed, so we'll put stuff that we want to share in here.
        public int Wheels { get; protected set; }
            // Note that we have to make things that we want to inherit "protected" instead of private. Public will also be inherited.
            // (Private things aren't inherited.)
        
        // We can also share methods, so we'll make one that toots the horn.
        public void Honk() {
            Console.WriteLine("*Honk!*");
        }

        public Vehicle(int numWheels) {
            Wheels = numWheels;
        }
    }

    // Now that we've got one class, we can make another that inherits from it:
    public class Car : Vehicle {
        // We use the colon to denote the class that we inherit from, with any interfaces following after.
        // Note that we can only inherit from one class at a time.

        // We could include anything that a car needs to have in addition to a vehicle, like a license plate:
        public string LicensePlate { get; private set; }
        
        // And, when we make a constructor, we can use a colon, and then the keyword "base" to run a constructor, like this:
        public Car(int Wheels) : base(Wheels) {
            // We can also pass parameters to the inherited constructor by putting the parameters in the parenthesis.

            // (This just generates a random license plate for a car.)
            LicensePlate = "";
            for (int i = 0; i < 7; i++) LicensePlate += getRandomChar().ToString().ToUpper();
        }

        // These are XML comments, they show up in your IDE while you edit the code if you make them properly. 
        /// <summary>
        /// Returns a random character between the 97th and 122nd character on your computer.
        /// </summary>
        /// 
        /// <example>
        /// Use it like this:
        /// <code>
        ///     char c = getRandomChar()
        /// </code>
        /// </example>
        /// 
        /// <returns>A random lower-case letter.</returns>
        private char getRandomChar() {
            return (char) new Random().Next(97, 122);
        }

// What if we want to over-rule something that we inherit? 
    // To override a method we inherit, we can simply use the new keyword in the definition:
        new public void Honk() {
            // This method overrides the one in the Vehicle class, and will be run instead of the other one.
            Console.WriteLine("*beep beep*");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {

// Okay, but how do we actually use it?
    // We can just create an object with its constructor.
            Car c = new Car(4);
    // Then, its methods, properties, and anything else become availble to us.
            Console.WriteLine($"The car's license plate is {c.LicensePlate}");
    // We can also use any of the object's parent class's methods, too.
            c.Honk();

    // Also, we can create objects using constructor of a subclass, like this:
            Vehicle v = new Car(4);
        // We cannot make them like this, though: 
            // Car v2 = new Vehicle(4);
        // The above definition causes an error because it doesn't know how to convert a vehicle to a car.

        // Note that, when we use methods of an object that was constructed with a subclass, it runs the superclass's method:
            v.Honk(); // Goes "*Honk!*"
        }
    }
}