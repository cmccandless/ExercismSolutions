using System.Linq;

public static class Bob
{
    private static string[] responses = new string[]
    {
        "Sure.",
        "Whoa, chill out!",
        "Fine. Be that way!",
        "Whatever.",
    };

    internal static string Hey(string query)
    {
        query = query.Trim();
        return responses[
            query.Equals(string.Empty) ? 2 :
            query.Any(ch => char.IsLetter(ch)) && query.ToUpper().Equals(query) ? 1 :
            query.EndsWith("?") ? 0 : 3];
    }
}
