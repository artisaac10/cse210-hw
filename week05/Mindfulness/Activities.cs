using System;

public class Activity
{
    private string _name;
    private string _description;
    protected int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void StartActivity()
    {
        Console.Clear();
        Console.WriteLine($"--- {_name} ---");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();

        Console.Write("How long, in seconds, would you like for your session? ");
        _duration = int.Parse(Console.ReadLine());

        Console.WriteLine("\nPrepare to begin...");
        ShowSpinner(3);
    }

    public void EndActivity()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!");
        ShowSpinner(3);

        Console.WriteLine($"\nYou have completed {_duration} seconds of the {_name}.");
        ShowSpinner(3);
    }

    protected void ShowSpinner(int seconds)
    {
        string[] spinner = { "|", "/", "-", "\\" };

        DateTime end = DateTime.Now.AddSeconds(seconds);
        int i = 0;

        while (DateTime.Now < end)
        {
            Console.Write(spinner[i++ % spinner.Length]);
            Thread.Sleep(250);
            Console.Write("\b \b");
        }
    }

    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}