public class Journal

{

    public List<Entry> _entries = new List<Entry>();
    
    public void AddEntry(Entry newEntry)

    {
        _entries.Add(newEntry);

    }

    public void DisplayAll()

    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No journal entries yet.");
        }
        else
        {
            foreach (Entry entry in _entries)
            {
                entry.Display();
            }
        }

    }

    public void SaveToTile(string file)

    {
        using (StreamWriter outputFile = new StreamWriter(file))

        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine(entry.TofileString());
            }
        }
        Console.WriteLine($"Journal saved to '{file}'.");


    }
       public void LosdFromFile(string file)
    {
        if (File.Exists(file))
        {
            _entries.Clear();
            string[] lines = File.ReadAllLines(file);
            foreach (string line in lines)
            {
                Entry entry = Entry.FromFileString(line);
                if (entry != null)
                {
                    _entries.Add(entry);
                }
            }
            Console.WriteLine($"Journal loaded from '{file}'.");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}