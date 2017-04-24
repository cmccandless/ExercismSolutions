using System;
using System.Collections.Generic;
using System.Linq;

public enum Plant
{
    Clover = 'C',
    Grass = 'G',
    Radishes = 'R',
    Violets = 'V',
    None = '.',
}

class Garden
{
    public Garden(string[] children, string plants)
    {
        Children = children.OrderBy(c => c).ToArray();
        SetPlants(plants);
    }

    private static string[] DefaultChildren = new[]
    {
        "Alice", "Bob", "Charlie", "David",
        "Eve", "Fred", "Ginny", "Harriet",
        "Ileana", "Joseph", "Kincaid", "Larry",
    };
    private string[] Children = DefaultChildren;
    private Dictionary<string, Plant[]> Plants = new Dictionary<string, Plant[]>();
    public static Garden DefaultGarden(string plants) => new Garden(DefaultChildren, plants);

    private void SetPlants(string plants)
    {
        var lines = plants.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
        for (int r = 0; r < lines.Length; r++)
        {
            var line = lines[r];
            for (int c = 0; c < line.Length; c++)
            {
                var child = Children[(int)Math.Floor(c / 2.0)];
                if (!Plants.ContainsKey(child)) Plants[child] = new Plant[4];
                Plants[child][r * 2 + (c % 2)] = (Plant)line[c];
            }
        }
    }

    public Plant[] GetPlants(string child) => 
        Plants.ContainsKey(child) ? Plants[child] : new Plant[0];
}
