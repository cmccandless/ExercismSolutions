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

class KindergartenGarden
{
    private static string[] DefaultChildren = new[]
    {
        "Alice", "Bob", "Charlie", "David",
        "Eve", "Fred", "Ginny", "Harriet",
        "Ileana", "Joseph", "Kincaid", "Larry",
    };
    public static KindergartenGarden DefaultGarden(string plants) => new KindergartenGarden(plants, DefaultChildren);

    public KindergartenGarden(string plants, string[] children = null)
    {
        Children = (children ?? DefaultChildren).OrderBy(c => c).ToArray();
        SetPlants(plants);
    }
    private string[] Children;
    private Dictionary<string, Plant[]> _plants = new Dictionary<string, Plant[]>();

    public Plant[] Plants(string child) => 
        _plants.ContainsKey(child) ? _plants[child] : new Plant[0];

    private void SetPlants(string plants)
    {
        var lines = plants.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
        for (int r = 0; r < lines.Length; r++)
        {
            var line = lines[r];
            for (int c = 0; c < line.Length; c++)
            {
                var child = Children[(int)Math.Floor(c / 2.0)];
                if (!_plants.ContainsKey(child)) _plants[child] = new Plant[4];
                _plants[child][r * 2 + (c % 2)] = (Plant)line[c];
            }
        }
    }
}
