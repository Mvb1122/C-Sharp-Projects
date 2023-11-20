using System;

namespace Magic
{
    public class For : Sequence
    {
        public int Loops;
        public ForEnd? End; // We don't particularly care if we have an end assigned or not, because if we don't, then we just won't get run again.

        private int RemainingLoops; // For use during a firing, to determine how many loops are left.
        public override For Parse(String Parse)
        {
            // Parses a string and makes a for sequence.
            // All digits: #Loops.
            RemainingLoops = Loops = Int32.Parse(Parse);

            // For a for loop, the cost is equal to the number of loops, I guess. 
            Cost = Loops;
            return this;
        }

        public override ExecutionResult Execute(Sequence[] Ring, int Position, bool doEffect)
        {
            _ = doEffect;
            // Subtract one from the Current loops and move forward one sequence.
            if (RemainingLoops > 0)
            {
                RemainingLoops--;
                ExecutionResult r = new()
                {
                    Move = 1,
                    Wait = 0.1F,
                };
                return r;
            } else
            {
                // Skip one past our end, or move forward two if it's not defined. Also reset, in case we're called again.
                if (End != null)
                {
                    Reset();
                    return new ExecutionResult()
                    {
                        Move = End.Position - Position + 1
                    };
                }
                else return new ExecutionResult()
                {
                    Move = 1000,
                    Wait = 0.0F,
                };
            }
        }

        public override string GetCode()
        {
            return Loops.ToString();
        }

        public override void Reset()
        {
            RemainingLoops = Loops;
        }
    }

    public class ForEnd : Sequence
    {
        /// <summary>
        /// Where this loop starts.
        /// </summary>
        public For? Start;
        public override ExecutionResult Execute(Sequence[] Ring, int Position, bool DoEffect)
        {
            if (Start != null)
                return new ExecutionResult()
                {
                    Move = Start.Position - Position,
                    Wait = 0
                };
            else return new ExecutionResult()
                {
                    Move = 1,
                    Wait = 0
                };
        }

        public override ForEnd LateParse(Sequence[] Ring, int Position)
        {
            // Just jump back to the last For sequence before us that doesn't already have an end assigned.
            for (int i = Position; i >= 0; i--)
            {
                if (Ring[i].GetType() == typeof(For))
                {
                    // Check if it's taken.
                    if (((For)Ring[i]).End == null)
                    {
                        // Here, it's not taken, so just assign it to ourselves. 
                        ((For)Ring[i]).End = this;
                        Start = (For)Ring[i];
                        break;
                    }
                }
            }

            return this;
        }

        public override string GetCode()
        {
            return "0";
        }

        public override Sequence Parse(string parse)
        {
            Cost = 0; // The end of a for loop costs nothing; it's already been paid by the start. 
            return this;
        }
    }
}
