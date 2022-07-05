using System;
using System.Collections;

namespace Lab_20._1
{
    internal class Program
    {
        // Immediately calls animalSounds() when the program starts.
        static void Main(string[] args) => animalSounds();

        // Creats a list to hold the animals of the farm and loads it with animals before the program can run.
        private static ArrayList myFarm = new ArrayList();
        static Program() {
            myFarm.Add(new Cow());
            myFarm.Add(new Chick(true));
            myFarm.Add(new Pig());
            myFarm.Add(new NamedCow("Elsie"));
        }

        // Vocalizes the types and noises of each animal, using the interface.
        public static void animalSounds() {
            IAnimal temp;
            for (int i = 0; i < myFarm.Count; i++) {
                temp = (IAnimal) myFarm[i];
                Console.WriteLine(temp.Type + " goes " + temp.Noise);
            }

            NamedCow named = (NamedCow) myFarm[3];
            Console.WriteLine(named.Name);
        }
    }

    // Creates a polymorphic backplane for the animals to extend.
    interface IAnimal {

        // Implements the type and noise getter methods as C# properties instead of Java-style methods.
        string Type {
            get;
        }

        string Noise {
            get;
        }
    }

    // Creates a cow class, which extends the aforementioned animal interface.
    public class Cow : IAnimal
    {
        // Makes variables to hold the noises and types of the animal.
        private string myType, myNoise;

        // Returns types and noises properly when the interface is used. 
        string IAnimal.Type { get { return myType; } }
        string IAnimal.Noise { get { return myNoise; } }

        // Sets up the noise and type when the cow is constructed.
        public Cow() {
            myType = "cow";
            myNoise = "moo";
        }
    }

    // Creates a class for named cows to use, which has all the usual facilities of a normal cow, with the addended Name property.
    public class NamedCow : Cow
    {
        // Sets up the Name property, with a public getter and a private setter.
        public string Name {
            get; private set;
        }

        // Names the cow after it's constructed atop a based cow.
        public NamedCow(string name) : base() {
            Name = name;
        }
    }

    // Creates a class for Pigs, also known as AP CSA.
        // This is satire if you can't tell...
        // This class also extends the Animal interface.
    public class Pig : IAnimal
    {
        // As with Cow, Pig makes the same interfacial properties and private values.
        private string myType, myNoise;

        string IAnimal.Noise { get { return myNoise; } }
        string IAnimal.Type { get { return myType; } }

        // Constructs a pig. 
        public Pig() {
            myType = "pig";
            myNoise = "oink";
        }
    }

    // This creates a class for young Chickens, and extends the Animal interface.
    public class Chick : IAnimal
    {
        // Unlike Pig and Cow, Chick uses one String for its type and then a boolean to control its sounds.
        private string myType;
        private bool makesTwoSounds;
        
        // Implements the interface's properties, where the Noise just calls the getNoise() method.
        string IAnimal.Noise { get => getNoise(); }
            // Otherwise, the Type property is as normal.
        string IAnimal.Type { get { return myType; } }

        // Births a Chick, taking in a flag which determines if the chick makes multiple sounds.
            // True -- The chicken has a 50:50 chance of making either sound.
            // False-- The chicken goes "cheep".
        public Chick(bool multipleSounds) {
            makesTwoSounds = multipleSounds;
            myType = "chick";
        }

        // Provides an empty constructor which just calls the existing constructor with false.
        public Chick() : this(false) {}

        // This private method just decides what noise the chicken should make.
        private string getNoise() {
            // If the Chick does make two sounds, generate a random number between 0 and 1. If it's 0, return "cheep". Otherwise, return "cluck".
            if (makesTwoSounds) 
                return new Random().Next(2) == 0 ? "cheep" : "cluck";

            // If the Chick only makes one noise, return "cheep".
            else return "cheep";
        }
    }
}