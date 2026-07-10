using System;


public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    //option 1
    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    //option 2
    public void DisplayAll()
    {
    foreach (Entry entry in _entries)
        {
        entry.Display();
        }
    }
    //option 3
    public void SaveToFile(string file)
    {
        using (StreamWriter output = new StreamWriter(file))
        {
            foreach (Entry entry in _entries)
            {
                output.WriteLine($"{entry._date}|{entry._promptText}|{entry._entryText}");
            }
        }
    }

    //option 4
    public void LoadFromFile(string file)
    {
        _entries.Clear();     

        string [] lines = File.ReadAllLines(file);

        foreach (string line in lines)
        {
            string[] parts = line.Split("|");

            Entry entry = new Entry();

            entry._date = parts[0];
            entry._promptText = parts[1];
            entry._entryText = parts[2];

            _entries.Add(entry);
        }
  
    }
     
}