using System;

public class Robot
{
	private static Random rand = new Random();

	public string Name { get; set; }

	public Robot()
	{
		Reset();
	}

	public void Reset()
	{
		Name = string.Join(string.Empty, new[]
		{
			(char)('A' + rand.Next(25)),
			(char)('A' + rand.Next(25)),
			(char)('0' + rand.Next(9)),
			(char)('0' + rand.Next(9)),
			(char)('0' + rand.Next(9)),
		});
	}
}
