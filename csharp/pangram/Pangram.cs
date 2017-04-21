using System.Collections.Generic;
using System.Linq;

public static class Pangram
{
    private static HashSet<char> chars = new HashSet<char>(Enumerable.Range('a', 26).Select(x => (char)x));
    public static bool IsPangram(string str) => new HashSet<char>(str.ToLower().ToCharArray()).Intersect(chars).Count() == 26;
}
