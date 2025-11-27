public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>()
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    private List<string> _unusedPrompts;
    private List<string> _responses;

    public ListingActivity() : base(
        "Listing",
        "This activity will help you reflect on the good things in your life by listing as many items as you can in a certain area.")
    {
        _unusedPrompts = new List<string>(_prompts);
        _responses = new List<string>();
    }

    private string GetRandomPrompt()
    {
        if (_unusedPrompts.Count == 0)
            _unusedPrompts = new List<string>(_prompts);

        Random rand = new Random();
        int index = rand.Next(_unusedPrompts.Count);
        string prompt = _unusedPrompts[index];
        _unusedPrompts.RemoveAt(index);
        return prompt;
    }

    public void Run()
    {
        StartMessage();

        string prompt = GetRandomPrompt();
        Console.WriteLine($"--- {prompt} ---\n");

        Console.WriteLine("You may begin in...");
        ShowCountdown(5);
        Console.WriteLine();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
                _responses.Add(input);
        }

        Console.WriteLine($"\nYou listed {_responses.Count} items!");
        EndMessage();
    }
}
