
public class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void StartMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name} Activity.\n");
        Console.WriteLine($"{_description}\n");

        Console.Write("How long (in seconds) would you like this session to last? ");
        while(!int.TryParse(Console.ReadLine(), out _duration) || _duration <= 0)
        {
            Console.Write("Please enter a positive number: ");
        }

        Console.WriteLine("\nGet ready...");
        ShowSpinner(3);
    }

    public void EndMessage()
    {
        Console.WriteLine("\nWell done!");
        Console.WriteLine($"You completed {_duration} seconds of the {_name} Activity!\n");
        ShowSpinner(3);

        // Save log to file
        SaveLog();
    }

    protected void ShowSpinner(int seconds)
    {
        List<string> icons = new List<string> { "|", "/", "-", "\\" };
        for (int i = 0; i < seconds * 4; i++)
        {
            int index = i % icons.Count;
            Console.Write(icons[index]);
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

    // Save activity log to log.txt
    private void SaveLog()
    {
        string logLine = $"{DateTime.Now}: {_name} Activity for {_duration} seconds";
        File.AppendAllText("log.txt", logLine + Environment.NewLine);
    }
}