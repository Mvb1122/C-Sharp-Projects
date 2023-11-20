// See https://aka.ms/new-console-template for more information
namespace Magic
{
   public abstract class Sequence
    {
        public SequenceType Type { get; set; }
        public float Cost { get; set; }
        public abstract String GetCode();

        /// <summary>
        /// Set automatically by the caller, just says what index the sequence has in the ring.
        /// </summary>
        public int Position { get; set; }

        /// <summary>
        /// Executes the sequence.
        /// </summary>
        /// <param name="Ring">All sequences in the current ring.</param>
        /// <param name="Position">The index on the ring.</param>
        /// <param name="DoEffect">Whether or not to do the spell's actual effect.</param>
        /// <returns>How far to move forward or backward, and if waiting is needed.</returns>
        public abstract ExecutionResult Execute(Sequence[] Ring, int Position, bool DoEffect);

        /// <summary>
        /// Given the code contents as determined by the basic spell parser, a sequence should be able to parse its contents.
        /// </summary>
        /// <param name="parse">The contents of the spell being imported.</param>
        /// <returns>A constructed sequence.</returns>
        public abstract Sequence Parse(String parse);

        /// <summary>
        /// Not required, but if a sequence needs access to the whole ring after parsing, it can use this.
        /// Called after all Parse() methods on the ring.
        /// </summary>
        /// <param name="Ring">All sequences in the current ring.</param>
        /// <param name="Position">The index on the ring.</param>
        /// <returns>The sequence updated to take into account the whole ring.</returns>
        public virtual Sequence LateParse(Sequence[] Ring, int Position)
        {
            return this;
        }

        public virtual void Reset() { }
    }
}
