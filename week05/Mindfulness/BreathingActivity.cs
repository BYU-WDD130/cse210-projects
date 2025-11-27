
public class BreathingActivity : Activity
{
    public BreathingActivity() : base(
        "Breathing",
        "This activity will help you relax by guiding you through slow breathing.")
    { }

    public void Run()
    {
        StartMessage();

        int timeRemaining = _duration;

        while (timeRemaining > 0)
        {
            Console.WriteLine("\nBreathe in...");
            AnimateBreath(4);

            Console.WriteLine("\nBreathe out...");
            AnimateBreath(6);

            timeRemaining -= 10;
        }

        EndMessage();
    }

    private void AnimateBreath(int seconds)
    {
        // Grow dots faster at start, slower at end
        for (int i = 0; i < seconds * 4; i++)
        {
            int dots = i % 6 + 1;
            Console.Write(new string('.', dots));
            Thread.Sleep(250 + i * 20); // slow down gradually
            Console.Write("\r" + new string(' ', 6) + "\r"); // erase line
        }
    }
}