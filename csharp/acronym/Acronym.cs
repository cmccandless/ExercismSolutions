using System.Collections.Generic;
using System.Linq;

public static class Acronym
{
    public class EnumItem<T> { public T Value; public int Index; }
    private static IEnumerable<EnumItem<T>> Enumerate<T>(this IEnumerable<T> col, int start = 0) =>
        col.Select(x => new EnumItem<T> { Value = x, Index = start++ });
    public static string Abbreviate(string phrase)
    {
        return string.Join("", from word in phrase.Split(' ', '-', ':')
                               where word.Length > 0
                               let notAc = !word.Equals(word.ToUpper())
                               from x in word.Enumerate()
                               where x.Index == 0 || (notAc && char.IsUpper(x.Value))
                               select x.Value).ToUpper();
    }
}
