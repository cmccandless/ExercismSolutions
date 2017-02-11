using System.Collections.Generic;

public class Raindrops
{
	private static Dictionary<int, string> rainSpeak = new Dictionary<int, string>()
	{
		{ 3, "Pling"},
		{ 5, "Plang"},
		{ 7, "Plong"},
	};
	public static string Convert(int i)
	{
		var result = string.Empty;
		foreach(var k in rainSpeak.Keys)
		{
			if (i%k==0) result += rainSpeak[k];
		}
		return result.Equals(string.Empty) ? i.ToString() : result; ;
	}
}
