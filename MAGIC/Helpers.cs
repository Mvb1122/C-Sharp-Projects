using System;

namespace Magic
{
    public enum SequenceType
    {
        Loop, Action, Declarative
    }

    public enum SpellType
    {
        Null, Attack, Defense, Heal
    }

    public record SpellStyleInformation
    {
        public SpellType Type;
    }

    public record ExecutionResult
    {
        /// <summary>
        /// How much to move relative to the current sequence's position. Eg, Move=1 means to move forward one Sequence.
        /// </summary>
        public int Move;

        /// <summary>
        /// How long to wait after the sequence, in ms.
        /// </summary>
        public float Wait;
    }
}
