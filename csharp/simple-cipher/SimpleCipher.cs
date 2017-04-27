using System;
using System.Linq;

class Cipher
{
    private const int A = 'a';
    private const int ZPLUS1 = 'z' + 1;
    private const int TWOA = A * 2;
    private const int N = 26;
    private const int NPLUSA = N + A;

    private static Random rand = new Random();
    public readonly string Key;
    public Cipher(string key = null)
    {
        Key = key ?? RandomKey();
        if (!ValidKey(Key)) throw new ArgumentException();
    }

    public static char RandomLetter(byte _ = 0) => (char)rand.Next(A, ZPLUS1);

    public static string RandomKey() => new string(new byte[100].Select(RandomLetter).ToArray());

    private static bool ValidKey(string key) => key.Length > 0 && key.All(char.IsLower);

    private char Encode(char ch, int i) => (char)(A + ((ch - TWOA + Key[i % Key.Length]) % N));

    public string Encode(string value) => new string(value.Select(Encode).ToArray());

    private char Decode(char ch, int i) => (char)(((((ch - A) % N) + NPLUSA - Key[i % Key.Length]) % N) + A);

    public string Decode(string value) => new string(value.Select(Decode).ToArray());
}
