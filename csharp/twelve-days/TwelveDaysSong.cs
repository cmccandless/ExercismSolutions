using System.Linq;

public class TwelveDaysSong
{
    private enum Ordinal
    {
        first = 1,
        second = 2,
        third = 3,
        fourth = 4,
        fifth = 5,
        sixth = 6,
        seventh = 7,
        eighth = 8,
        ninth = 9,
        tenth = 10,
        eleventh = 11,
        twelfth = 12,
    }

    private static string[] verses = new string[]
    {
        "",
        "a Partridge in a Pear Tree.",
        "two Turtle Doves",
        "three French Hens",
        "four Calling Birds",
        "five Gold Rings",
        "six Geese-a-Laying",
        "seven Swans-a-Swimming",
        "eight Maids-a-Milking",
        "nine Ladies Dancing",
        "ten Lords-a-Leaping",
        "eleven Pipers Piping",
        "twelve Drummers Drumming",
    };

    public string Sing() => Verses(1, 12);

    public string Verse(int verse) => BuildVerse(verse);

    public string Verses(int start, int end) =>
        string.Join(string.Empty,
            Enumerable.Range(start, end - start + 1)
            .Select(i => BuildVerse(i) + "\n"));

    private string BuildVerse(int verse)
    {
        var parts = Enumerable.Range(1, verse)
            .Select(i => verses[i])
            .Reverse()
            .ToArray();
        if (verse > 1) parts[parts.Length - 1] = $"and {parts[parts.Length - 1]}";
        return $"On the {((Ordinal)verse)} day of Christmas my true love gave to me, " +
            string.Join(", ", parts) + "\n";
    }
}
