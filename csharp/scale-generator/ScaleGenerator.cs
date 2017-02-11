using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ScaleGenerator
{
	private static List<string> majorKeys = new List<string> { "A", "A#", "B", "C", "C#", "D", 
		"D#", "E", "F", "F#", "G", "G#", };
	private static List<string> minorKeys = new List<string> { "A", "Bb", "B", "C", "Db", 
		"D", "Eb", "E", "F", "Gb", "G", "Ab", };
	public static string[] Pitches(string tonic, string intervals)
	{
		var keys = majorKeys;
		if (!new[] { "A", "a", "B", "b", "C", "c#", "D", "d#", 
			"E", "e", "F#", "f#", "G", "g#", }.Contains(tonic)) keys = minorKeys;
		var t = tonic[0].ToString().ToUpper();
		if (tonic.Length > 1) t += tonic[1];
		var i = keys.IndexOf(t);
		var scale = new List<string> { keys[i] };
		foreach (var interval in intervals)
		{
			switch (interval)
			{
				case 'M': i += 2; break;
				case 'm': i += 1; break;
				case 'A': i += 3; break;
			}
			scale.Add(keys[i % keys.Count]);
		}
		return scale.Take(scale.Count - 1).ToArray();
	}
}
