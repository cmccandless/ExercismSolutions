using System.Linq;

public class Proverb
{
    private static string[] words = { "nail", "shoe", "horse", "rider", "message", "battle", "kingdom" };

    public static string Line(int n) => n < 7 ?
        $"For want of a {words[n - 1]} the {words[n]} was lost." :
        "And all for the want of a horseshoe nail.";

    public static string AllLines() => string.Join("\n", Enumerable.Range(1, 7).Select(Line));
}
