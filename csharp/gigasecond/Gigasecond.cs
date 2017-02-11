using System;

public class Gigasecond
{
	public static DateTime Date(DateTime date)
	{
		return date + TimeSpan.FromSeconds(Math.Pow(10,9));
	}
}
