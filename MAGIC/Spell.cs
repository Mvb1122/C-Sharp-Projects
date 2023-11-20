// See https://aka.ms/new-console-template for more information

using Microsoft.VisualBasic;
using System.Reflection.PortableExecutable;

namespace Magic
{
    public class Spell
    {
        public Sequence[][] Contents { get; set; }
        public float Cost { get { return GetCost(); } }
        private float cost;
        public static Spell Parse(string Sequence)
        {
            // Look at the passed sequence and parse it into a sequence[]. 
            Spell s = new();

            // Split by \n, then parse. Note: Trim to get rid of empty last code.
            String[] rings = Sequence.Trim().Split("\n");
            s.Contents = new Sequence[rings.Length][];
            for (int i = 0; i < rings.Length; i++)
            {
                String[] codes = ParseToCodes(rings[i]); // Note: Remove the first character to get rid of the empty first code.
                s.Contents[i] = new Sequence[codes.Length];
                for (int j = 0; j < codes.Length; j++)
                {
                    // Make a sequence from the provided index.
                    SeqChunk chunk = SequenceGrimoire.SeqChunkFromSequence(codes[j]);
                    // Construct the sequence. (Note that Activator.CreateInstance(T) just makes an instance of T from its parameterless constructor.) 
                    Sequence newOne = (Sequence)Activator.CreateInstance(chunk.Sequence);
                    s.Contents[i][j] = newOne.Parse(chunk.InnerCode);
                }
            }

            return s;
        }

        private static string[] ParseToCodes(string ring)
        {
            // Remove first '.'
            if (ring[0] == '.') ring = ring.Substring(1);

            // Read through the string and split it out by complete segments (aka ignore segments in quotes.)
            List<String> codes = new();
            bool InQuote = false;
            for (int i = 0; i < ring.Length; i++)
            {

                if (!InQuote && ring[i] == '.')
                {
                    // Split off the chunk.
                    string chunk = ring.Substring(0, i);

                    // Remove starting period if it's there.
                    if (chunk[0] == '.') chunk = chunk.Substring(1);

                    codes.Add(chunk);
                    ring = ring.Substring(i);
                    i = 0;
                }

                // Whenever we're in a quote, just invert it.
                else if (ring[i] == '"') { InQuote = !InQuote; }
            }

            // Add the final code, but remove the period if it's at the start.
            if (ring[0] == '.') ring = ring.Substring(1);
            codes.Add(ring);

            return codes.ToArray();
        }

        /// <summary>
        /// Executes the rings, from outwards in.
        /// </summary>
        public void Fire()
        {
            Validate();

            // Run through each spell in the contents.
                // TODO: Rings run in parallel.
            for (int i = 0; i < Contents.Length; i++)
            {
                for (int j = 0; j < Contents[i].Length;)
                {
                    ExecutionResult r = Contents[i][j].Execute(Contents[i], j, true);

                    j += r.Move;
                }
            }
        }


        private void Reset()
        {
            for (int i = 0; i < Contents.Length; i++)
            {
                for (int j = 0; j < Contents[i].Length; j++)
                {
                    // Reset all sequences.
                    Contents[i][j].Reset();
                }
            }
        }

        private void Validate()
        {
            for (int i = 0; i < Contents.Length; i++)
            {
                for (int j = 0; j < Contents[i].Length; j++)
                {
                    // Set all positions.
                    Contents[i][j].Position = j;

                    // Call LateParse.
                    Contents[i][j].LateParse(Contents[i], j);
                }
            }

            // Calculate cost, then reset.
            GetCost();
            Reset();
        }

        public float GetCost()
        {
            // Calculate cost by running through the spell without actually triggering it.
            if (cost == 0) // Only calculate cost if we haven't done it already.
            {
                for (int i = 0; i < Contents.Length; i++)
                {
                    for (int j = 0; j < Contents[i].Length;)
                    {
                        ExecutionResult r = Contents[i][j].Execute(Contents[i], j, false);
                        cost += Contents[i][j].Cost;
                        j += r.Move;
                    }
                }

                return cost;
            }
            else return cost;
        }

        public String GetCode()
        {
            String code = "";
            for (int i = 0; i < Contents.Length; i++) {
                for (int j = 0; j < Contents[i].Length; j++)
                {
                    string Identifier = SequenceGrimoire.IdentifierFromType(Contents[i][j].GetType()).ToString();
                    code += $".{Identifier}{Contents[i][j].GetCode()}{Identifier}";
                }

                code += "\n";
            }
            return code;
        }
    }

    public class SequenceGrimoire
    {
        public static Type[] Sequences = new Type[] { typeof(For), typeof(ForEnd), typeof(DebugLog) };
        private const int IdentifierLength = 2;

        /// <summary>
        /// Finds the specified sequence in the Sequences array.
        /// </summary>
        /// <param name="search">The sequence to look for</param>
        /// <returns>The index, or -1 if not found. In string form in order to enforce compatibility with parse() methods.</returns>
        public static String IdentifierFromType(Type search)
        {
            for (int i = 0; i < Sequences.Length; i++)
            {
                if (search == Sequences[i])
                {
                    string Identifier = i.ToString();
                    if (Identifier.Length < IdentifierLength)
                        do
                        {
                            Identifier = "0" + Identifier;
                        } while (Identifier.Length < IdentifierLength);
                    return Identifier;
                }
            }
            return "-1";
        }

        public static Type TypeFromIndex(int index) { return Sequences[index]; }

        public static SeqChunk SeqChunkFromSequence(String sequence)
        {
            // First, find out what type it is from the first IdentifierLength characters.
            Type t = TypeFromIndex(int.Parse(sequence.Substring(0, IdentifierLength)));

            // Lop off the ends in order to get the InnerCode.
            String InnerCode = sequence.Substring(IdentifierLength, sequence.Length - 2 * IdentifierLength);

            return new SeqChunk()
            {
                Sequence = t,
                InnerCode = InnerCode,
            };
        }
    }

    public record SeqChunk
    {
        public Type Sequence;
        public String InnerCode;
    }
}