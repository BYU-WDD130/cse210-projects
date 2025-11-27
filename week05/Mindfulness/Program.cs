class Program
{
    static void Main(string[] args)
    {
        int choice = 0;

        while (choice != 4)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program\n");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflecting Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("Choose an option: ");

            while(!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 4)
            {
                Console.Write("Please enter a valid option (1-4): ");
            }

            switch(choice)
            {
                case 1:
                    new BreathingActivity().Run();
                    break;
                case 2:
                    new ReflectingActivity().Run();
                    break;
                case 3:
                    new ListingActivity().Run();
                    break;
                case 4:
                    Console.WriteLine("Thank you for using the Mindfulness Program!");
                    break;
            }
        }
    }
}


/*
Mindfulness Program - Exceeding Requirements:

1. Added a session log: each activity saves date, type, and duration to "log.txt".
2. Improved animations: BreathingActivity now has growing dots that slow down to simulate real breath.
3. No repeats: ReflectionActivity and ListingActivity now use all prompts/questions before repeating any.
4. Input validation: ensures duration and menu choices are correct.
5. Overall clean code and structure for maintainability and readability.
*/