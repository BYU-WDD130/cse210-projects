using System;
using System.Linq;

namespace EternalQuest
{
    class Program
    {
        static QuestLog quest = new QuestLog();
        const string saveFile = "goals.txt";

        static void Main()
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n--- Eternal Quest ---");
                Console.WriteLine("1. Create Goal");
                Console.WriteLine("2. List Goals");
                Console.WriteLine("3. Record Event");
                Console.WriteLine("4. Show Score");
                Console.WriteLine("5. Save");
                Console.WriteLine("6. Load");
                Console.WriteLine("0. Exit");
                Console.Write("Option: ");
                
                switch (Console.ReadLine())
                {
                    case "1": CreateGoal(); break;
                    case "2": quest.ShowGoals(); break;
                    case "3": RecordEvent(); break;
                    case "4": quest.ShowScore(); break;
                    case "5": quest.Save(saveFile); break;
                    case "6": quest.Load(saveFile); break;
                    case "0": exit = true; break;
                    default: Console.WriteLine("Invalid option."); break;
                }
            }
        }

        static void CreateGoal()
        {
            Console.WriteLine("1. Simple Goal");
            Console.WriteLine("2. Eternal Goal");
            Console.WriteLine("3. Checklist Goal");
            Console.Write("Type: ");
            string type = Console.ReadLine();

            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Description: ");
            string desc = Console.ReadLine();

            if (type == "1")
            {
                int pts = PromptInt("Points: ");
                quest.AddGoal(new SimpleGoal(name, desc, pts));
            }
            else if (type == "2")
            {
                int pts = PromptInt("Points per completion: ");
                quest.AddGoal(new EternalGoal(name, desc, pts));
            }
            else if (type == "3")
            {
                int pts = PromptInt("Points each time: ");
                int target = PromptInt("Target count: ");
                int bonus = PromptInt("Bonus on finish: ");
                quest.AddGoal(new ChecklistGoal(name, desc, pts, target, bonus));
            }
            else
            {
                Console.WriteLine("Invalid type.");
            }
        }

        static void RecordEvent()
        {
            if (!quest.Goals.Any())
            {
                Console.WriteLine("No goals to record.");
                return;
            }

            quest.ShowGoals();
            int index = PromptInt("Which goal? (number): ") - 1;

            if (index >= 0 && index < quest.Goals.Count)
                quest.RecordGoalEvent(index);
            else
                Console.WriteLine("Invalid selection.");
        }

        static int PromptInt(string msg)
        {
            while (true)
            {
                Console.Write(msg);
                if (int.TryParse(Console.ReadLine(), out int value))
                    return value;

                Console.WriteLine("Enter a valid number.");
            }
        }
    }
}