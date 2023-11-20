using System;

namespace Magic
{
    public class DebugLog : Sequence
    {
        string content = "0";
        public override ExecutionResult Execute(Sequence[] Ring, int Position, bool DoEffect)
        {
            if (DoEffect && content == "0")
                Console.WriteLine($"DebugLog sequence reached with position {Position}!");
            else if (DoEffect) Console.Write(content.Trim('"'));

            return new ExecutionResult()
            {
                Move = 1,
                Wait = 0,
            };
        }

        public override string GetCode()
        {
            return "0";
        }

        public override Sequence Parse(string parse)
        {
            content = parse;
            return this;
        }
    }
}
