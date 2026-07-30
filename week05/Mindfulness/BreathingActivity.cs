using System;

public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base(
            "Breathing Activity",
            "This activity will help you relax by walking you through breathing slowly.")
    {
    }

    public void Run()
    {
        StartActivity();

        DateTime end = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < end)
        {
            Console.Write("\nBreathe in... ");
            ShowCountdown(4);

            Console.Write("\nBreathe out... ");
            ShowCountdown(4);

            Console.WriteLine();
        }

        EndActivity();
    }
}