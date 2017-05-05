using System.Collections.Generic;
using System.Linq;

public static class OcrNumbers
{
    private static Dictionary<int, char> Ocr = new Dictionary<int, char>()
    {
        [0xAF] = '0', [0x09] = '1', [0x9E] = '2', [0x9B] = '3', [0x39] = '4',
        [0xB3] = '5', [0xB7] = '6', [0x89] = '7', [0xBF] = '8', [0xBB] = '9',
    };

    public static Queue<T> ToQueue<T>(this IEnumerable<T> a) => new Queue<T>(a);

    private static IEnumerable<T> Pop<T>(Queue<T> q) => new[] { q.Dequeue(), q.Dequeue(), q.Dequeue() };

    private static IEnumerable<Queue<char>> GetLetters(this string input)
    {
        var lines = input.Split('\n').Select(ToQueue).Take(3).ToArray();
        while (lines[0].Count > 2) yield return lines.SelectMany(Pop).ToQueue();
    }

    private static int HasSegment(char a, char b) => a == b ? 1 : 0;

    private static int Accumulate(int r, int x) => (r << 1) | x;

    private static char ToChar(this int x) => Ocr.ContainsKey(x) ? Ocr[x] : '?';

    private static char Convert(IEnumerable<char> letter) => 
        letter.Zip("*_*|_||_|", HasSegment).Aggregate(0, Accumulate).ToChar();

    public static string Convert(string input) => new string(input.GetLetters().Select(Convert).ToArray());
}
