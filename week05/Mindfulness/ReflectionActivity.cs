using System; 

public class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string>()
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>()
    {
        "Why was this experience meaningful to you?",
        "How did you feel when it was complete?",
        "What did you learn about yourself?",
        "What made this different?",
        "What could you learn from this?"
    };

    public ReflectionActivity()
        : base(
            "Reflection Activity",
            "This activity helps you reflect on times you have shown strength.")
    {
    }

    public void Run()
    {
        StartActivity();

        Random rand = new Random();

        Console.WriteLine("\nConsider the following prompt:");
        Console.WriteLine($"--- {_prompts[rand.Next(_prompts.Count)]} ---");

        Console.WriteLine("\nPress Enter when ready.");
        Console.ReadLine();

        DateTime end = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < end)
        {
            Console.WriteLine();
            Console.WriteLine(_questions[rand.Next(_questions.Count)]);
            ShowSpinner(5);
        }

        EndActivity();
    }
}