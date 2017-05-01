using System.Collections.Generic;
using System.Linq;

public static class ScaleGenerator
{
    private static List<string> majorKeys = new List<string>
    { "A", "A#", "B", "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", };

    private static List<string> minorKeys = new List<string>
    { "A", "Bb", "B", "C", "Db", "D", "Eb", "E", "F", "Gb", "G", "Ab", };

    private static HashSet<string> validMajorTonics = new HashSet<string>
    { "A", "a", "B", "b", "C", "c#", "D", "d#","E", "e", "F#", "f#", "G", "g#", };

    private static Dictionary<char, int> step = new Dictionary<char, int>
    { ['m'] = 1, ['M'] = 2, ['A'] = 3, };

    private static bool IsMajorScale(this string tonic) => validMajorTonics.Contains(tonic);

    public static string[] Pitches(string tonic, string intervals)
    {
        var keys = tonic.IsMajorScale() ? majorKeys : minorKeys;
        var t = tonic[0].ToString().ToUpper();
        if (tonic.Length > 1) t += tonic[1];
        var i = keys.IndexOf(t);
        var scale = new List<string> { keys[i] };
        foreach (var interval in intervals)
        {
            i += step[interval];
            scale.Add(keys[i % keys.Count]);
        }
        return scale.Take(scale.Count - 1).ToArray();
    }
}
