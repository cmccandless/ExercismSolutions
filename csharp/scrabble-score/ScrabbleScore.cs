using System.Collections.Generic;
using System.Linq;

public class ScrabbleScore
{
    private class ScoreDictionary
    {
        private Dictionary<char, int> scores = new Dictionary<char, int>();
        public int this[char key] => scores[key];
        public int this[string key] { set { foreach (var ch in key) scores[ch] = value; } }
    }
    
    private static ScoreDictionary Scores = new ScoreDictionary
    {
        ["AEIOULNRST"] = 1, ["DG"] = 2, ["BCMP"] = 3,
        ["FHVWY"] = 4, ["K"] = 5, ["JX"] = 8, ["QZ"] = 10,
    };

    public static int Score(string word) => word?.Trim().ToUpper().Sum(ch => Scores[ch]) ?? 0;
}
