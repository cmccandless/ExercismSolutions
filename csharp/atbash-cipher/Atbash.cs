using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercism.atbash
{
    class Atbash
    {
        private const byte LEN = 5;

        private static char Encode(char ch) => 
            char.IsNumber(ch) ? ch : (char)(219 - ch);

        private static int CountGroups(IEnumerable<char> col) => 
            (int)Math.Ceiling(col.Count() / (double)LEN);

        private static string SplitIntoFives(IEnumerable<char> encoded) =>
            string.Join(" ", from i in Enumerable.Range(0, CountGroups(encoded))
                             select encoded.Substring(i * LEN, LEN));
        
        public static string Encode(string value) =>
            SplitIntoFives(value.ToLower().Where(char.IsLetterOrDigit).Select(Encode));
    }
    static partial class IEnumerableExtensions
    {
        public static IEnumerable<T> Slice<T>(this IEnumerable<T> col, int start, int stop) =>
            col.Skip(start).Take(stop - start);

        public static string Substring(this IEnumerable<char> str, int start, int length) =>
            string.Join(string.Empty, str.Slice(start, start + length));
    }
}