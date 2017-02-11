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
		Plants = Children.ToDictionary(c => c, _ => new int[4].Select(i => Plant.None).ToArray());
		SetPlants(plants);
	}

	private static string[] DefaultChildren = new[]
			{
				"Alice", "Bob", "Charlie", "David", 
				"Eve", "Fred", "Ginny", "Harriet", 
				"Ileana", "Joseph", "Kincaid", "Larry", 
			};
	private string[] Children = DefaultChildren;
	private Dictionary<string, Plant[]> Plants;
	public static Garden DefaultGarden(string plants)
	{
		return new Garden(DefaultChildren, plants);
	}

	private void SetPlants(string plants)
	{
		var lines = plants.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
		for (int r = 0; r < lines.Length; r++)
		{
			var line = lines[r];
			for (int c = 0; c < line.Length; c++)
			{
				var child = Children[(int)Math.Floor(c / 2.0)];
				Plants[child][r * 2 + (c % 2)] = (Plant)line[c];
			}
		}
	}

	public Plant[] GetPlants(string child)
	{
		return Plants.ContainsKey(child) ?
			Plants[child].Where(p => p != Plant.None).ToArray() :
			new Plant[0];
	}
}
