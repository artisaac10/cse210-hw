using System;


public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }



    public void Start()
    {
        bool running = true;

        while (running)
        {
            Console.Clear();

            DisplayPlayerInfo();

            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Record Event");
            Console.WriteLine("  4. Save Goals");
            Console.WriteLine("  5. Load Goals");
            Console.WriteLine("  6. Quit");

            Console.Write("Select a choice: ");
            string choice = Console.ReadLine();

            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;

                case "2":
                    ListGoalDetails();
                    break;

                case "3":
                    RecordEvent();
                    break;

                case "4":
                    SaveGoals();
                    break;

                case "5":
                    LoadGoals();
                    break;

                case "6":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

            if (running)
            {
                Console.WriteLine();
                Console.WriteLine("Press ENTER to continue...");
                Console.ReadLine();
            }
        }
    }

  

    public void DisplayPlayerInfo()
    {
        Console.WriteLine("=================================");
        Console.WriteLine("         ETERNAL QUEST");
        Console.WriteLine("=================================");
        Console.WriteLine($"Score: {_score}");
        Console.WriteLine("=================================");
    }

    public void ListGoalNames()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("You have no goals.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetName()}");
        }
    }



    public void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("You have no goals.");
            return;
        }

        Console.WriteLine("Your Goals:");
        Console.WriteLine();

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }



    public void CreateGoal()
    {
        Console.WriteLine("The types of goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");

        Console.Write("Which type of goal would you like to create? ");
        string choice = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description? ");
        string description = Console.ReadLine();

        Console.Write("How many points is this goal worth? ");
        string points = Console.ReadLine();

        if (choice == "1")
        {
            SimpleGoal goal = new SimpleGoal(
                name,
                description,
                points);

            _goals.Add(goal);

            Console.WriteLine("Simple goal created!");
        }
        else if (choice == "2")
        {
            EternalGoal goal = new EternalGoal(
                name,
                description,
                points);

            _goals.Add(goal);

            Console.WriteLine("Eternal goal created!");
        }
        else if (choice == "3")
        {
            Console.Write("How many times must you complete this goal? ");
            int target = int.Parse(Console.ReadLine());

            Console.Write("How many bonus points will you receive? ");
            int bonus = int.Parse(Console.ReadLine());

            ChecklistGoal goal = new ChecklistGoal(
                name,
                description,
                points,
                target,
                bonus);

            _goals.Add(goal);

            Console.WriteLine("Checklist goal created!");
        }
        else
        {
            Console.WriteLine("Invalid goal type.");
        }
    }


    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("You don't have any goals.");
            return;
        }

        Console.WriteLine("Choose a goal to record:");
        ListGoalNames();

        Console.Write("Which goal did you accomplish? ");
        int choice = int.Parse(Console.ReadLine());

        if (choice < 1 || choice > _goals.Count)
        {
            Console.WriteLine("Invalid goal number.");
            return;
        }

        Goal goal = _goals[choice - 1];


        bool wasComplete = goal.IsComplete();

       
        goal.RecordEvent();

  
        bool isComplete = goal.IsComplete();

   
        int points = int.Parse(goal.GetPoints());

      
        _score += points;

    
        if (!wasComplete && isComplete)
        {
            ChecklistGoal checklist = goal as ChecklistGoal;

            if (checklist != null)
            {
                _score += checklist.GetBonus();

                Console.WriteLine();
                Console.WriteLine("🎉 Congratulations!");
                Console.WriteLine(
                    $"You completed the goal and earned {checklist.GetBonus()} bonus points!");
            }
        }

        Console.WriteLine();
        Console.WriteLine($"You earned {points} points!");
        Console.WriteLine($"Your score is now {_score}.");
    }


    public void SaveGoals()
    {
        Console.Write("Enter a filename to save to: ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);

            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals saved successfully.");
    }



    public void LoadGoals()
    {
        Console.Write("Enter the filename to load: ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("That file does not exist.");
            return;
        }

        string[] lines = File.ReadAllLines(filename);

        if (lines.Length == 0)
        {
            Console.WriteLine("The file is empty.");
            return;
        }

      
        _score = int.Parse(lines[0]);

       
        _goals.Clear();

  
        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split('|');

            string goalType = parts[0];

            if (goalType == "SimpleGoal")
            {
                string name = parts[1];
                string description = parts[2];
                string points = parts[3];
                bool isComplete = bool.Parse(parts[4]);

                SimpleGoal goal = new SimpleGoal(
                    name,
                    description,
                    points);

               
                if (isComplete)
                {
                    goal.RecordEvent();
                }

                _goals.Add(goal);
            }
            else if (goalType == "EternalGoal")
            {
                string name = parts[1];
                string description = parts[2];
                string points = parts[3];

                EternalGoal goal = new EternalGoal(
                    name,
                    description,
                    points);

                _goals.Add(goal);
            }
            else if (goalType == "ChecklistGoal")
            {
                string name = parts[1];
                string description = parts[2];
                string points = parts[3];

                int target = int.Parse(parts[4]);
                int bonus = int.Parse(parts[5]);
                int amountCompleted = int.Parse(parts[6]);

                ChecklistGoal goal = new ChecklistGoal(
                    name,
                    description,
                    points,
                    target,
                    bonus);

                
                for (int j = 0; j < amountCompleted; j++)
                {
                    goal.RecordEvent();
                }

                _goals.Add(goal);
            }
        }

        Console.WriteLine("Goals loaded successfully.");
    }
}