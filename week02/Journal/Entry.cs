public class Entry

{
    public string _date;
    public string _prompText;
    public string _entryText;

    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_prompText}");
        Console.WriteLine($"Entry: {_entryText}");
        Console.WriteLine();

    }
    public string TofileString()
    {
        return $"{_date}~|~{_prompText}~|~(_entryText)";
    }

    public static Entry FromFileString(string line)
    {
        string[] parts = line.Split("~|~");
        if (parts.Length == 3)
        {
            Entry entry = new Entry();
            entry._date = parts[0];
            entry._prompText = parts[1];
            entry._entryText = parts[2];
            return entry;

        }
        return null;
    }

}