// BTW, this isn't part of the "Learning C#" series, so there's no REPL here.
using System;

namespace Interfaces_Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IRecyclable[] recyclables = new IRecyclable[] {new Paper(1), new Paper(2), new Paper(3), new Paper(4), new Tin(1), new Tin(2)};
            
            foreach (IRecyclable i in recyclables)
            {
                if (i != null && i.IsRecyclable())
                {
                    i.Recycle();
                } else
                {
                    Console.WriteLine($"We couldn't recycle the {i.GetType().Name} with a number of {i.getNumber()}.");
                }
            }
        }
    }

    interface IRecyclable
    {
        public bool IsRecyclable();

        public void Recycle();

        public int getNumber();   
    }

    public class Paper : IRecyclable
    {
        readonly int num;

        public bool IsRecyclable()
        {
            return num == 1;
        }

        public void Recycle()
        {
            Console.WriteLine("The piece of paper was recycled.");
        }

        public int getNumber() { return num; }

        /// <summary>
        /// Creates a slice of paper with a recoverability number.
        /// </summary>
        /// <param name="num">1 if it's recyclable</param>
        public Paper(int num)
        {
            this.num = num;
        }
    }

    public class Tin : IRecyclable
    {
        readonly int num;
        public int getNumber() { return num; }
        public bool IsRecyclable()
        {
            return num == 2;
        }

        public void Recycle()
        {
            Console.WriteLine("The piece of tin was recycled.");
        }

        /// <summary>
        /// Creates a piece of tin with a recoverability number.
        /// </summary>
        /// <param name="num">2 if it's recyclable</param>
        public Tin(int num)
        {
            this.num = num;
        }
    }
}