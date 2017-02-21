using System.Collections.Generic;
using System.Linq;

namespace Exercism.beer_song
{
    public static class Beer
    {
        public static string Verse(int verse) =>
            Verse(verse, Bottles(verse));

        private static string Verse(int verse, string bottles) =>
            $"{bottles} on the wall, {bottles.ToLower()}.\n" +
            $"{Action(verse)}, {Bottles(verse - 1).ToLower()} on the wall.\n";

        private static string Bottles(int verse) => verse == 0 ?
            "No more bottles of beer" :
            $"{(verse + 100) % 100} bottle{(verse != 1 ? "s" : string.Empty)} of beer";

        private static string Action(int verse) => verse == 0 ?
            "Go to the store and buy some more" :
            $"Take {(verse == 1 ? "it" : "one")} down and pass it around";

        public static string Sing(int start, int stop) =>
            $"{string.Join("\n", Verses(start, stop))}\n";

        private static IEnumerable<string> Verses(int start, int stop) =>
            Enumerable.Range(stop, start - stop + 1).Reverse().Select(Verse);
    }
}