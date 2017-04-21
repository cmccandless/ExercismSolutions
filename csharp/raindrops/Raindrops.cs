using System.Collections.Generic;
using System.Text;

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
        var result = new StringBuilder();
        foreach (var k in rainSpeak.Keys)
        {
            if (i % k == 0) result.Append(rainSpeak[k]);
        }
        return result.Length == 0 ? i.ToString() : result.ToString();
    }
}
