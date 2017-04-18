using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercism.crypto_square
{
    class Crypto
    {
        public readonly string NormalizePlaintext;
        public readonly int Size;
        public Crypto(string str)
        {
            NormalizePlaintext = string.Join(string.Empty, str.ToLower().Where(char.IsLetterOrDigit));
            Size = (int)Math.Ceiling(Math.Sqrt(NormalizePlaintext.Length));
        }

        private string Cipher(string delimiter = " ") =>
            string.Join(delimiter, from j in Enumerable.Range(0, Size)
                                   select string.Join(string.Empty, from i in Enumerable.Range(0, Size)
                                                                    let index = i * Size + j
                                                                    where NormalizePlaintext.Length > index
                                                                    select NormalizePlaintext[index]));

        public string[] PlaintextSegments() => new Queue<char>(NormalizePlaintext).Segments(Size).ToArray();

        public string Ciphertext() => Cipher("");

        public string NormalizeCiphertext() => Cipher();
    }

    static class Ext
    {
        public static T[] DequeueM<T>(this Queue<T> q, int n, bool exact = false) =>
            new byte[exact || q.Count >= n ? n : q.Count].Select(_ => q.Dequeue()).ToArray();

        public static IEnumerable<string> Segments(this Queue<char> q, int size)
        {
            while (q.Any()) yield return string.Join(string.Empty, q.DequeueM(size));
        }
    }
}