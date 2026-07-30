using System;


public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>()
    {
        "Who are people that you appreciate?",
        "What are your personal strengths?",
        "Who have you helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are your personal heroes?"
    };

    public ListingActivity()
        : base(
            "Listing Activity",
            "This activity helps you think about the good things in your life.")
    {
    }

    public void Run()
    {
        StartActivity();

        Random rand = new Random();

        Console.WriteLine();
        Console.WriteLine(_prompts[rand.Next(_prompts.Count)]);

        Console.WriteLine("\nYou may begin in...");
        ShowCountdown(5);

        int count = 0;

        DateTime end = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < end)
        {
            Console.Write("> ");
            Console.ReadLine();
            count++;
        }

        Console.WriteLine($"\nYou listed {count} items!");

        EndActivity();
    }
}