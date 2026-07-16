using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the ScriptureMemorizer Project.");
        Reference reference = new Reference("John", 3, 16);
        Scripture scripture = new Scripture(reference, "for God so loved the world that he gave his one and only Son that whoever believes in him shall not perish but have eternal life");

        Console.WriteLine(scripture.GetDisplayText());

        while (!scripture.IsCompletelyHidden())
        {
            Console.WriteLine();
            Console.WriteLine("Press enter to hide words or type quit to exit:");
            string input = Console.ReadLine();

            if (input == "quit")
            {
                break;
            }

            scripture.HideRandomWords(3);

            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
        }

    }
}