// See https://aka.ms/new-console-template for more information
using Magic;

/*
Spell Debug = new()
{
    Contents = new Sequence[][] { new Sequence[] {
        new For().Parse("3"),
        new DebugLog(),
        new ForEnd()
    } }
};

Console.WriteLine($"Started. Final cost: {Debug.Cost}");
Debug.Fire();
Console.WriteLine($"Ended.");

Console.WriteLine($"Code:\n{Debug.GetCode()}");

// Attempt reconstruct from just code.
Spell NewOne = Spell.Parse(Debug.GetCode());
Console.WriteLine($"New Code:\n{NewOne.GetCode()}\nNew Cost {NewOne.Cost}\nNew result:");
NewOne.Fire();
*/

// Runtime example.
// Debug thing.

do
{
    String code = Console.ReadLine();
    try
    {
        Spell r = Spell.Parse(code);
        Console.WriteLine($"Compilation complete. Cost {r.Cost}, Executing:");
        r.Fire();
    } catch (Exception _)
    {
        Console.WriteLine("Something went wrong (You probably messed up :/)");
    }
} while (true);

// .00300.02002.01001
// .00300.02Hello02.01001