using System;
using System.Linq;

public class Robot
{
    private static Random rand = new Random();

    public string Name { get; private set; }

    public Robot() { Reset(); }

    public void Reset() => Name = $"{rand.NextStr('A', 'Z', 2)}{rand.NextStr('0', '9', 3)}";
}

public static class Ext
{
    public static string NextStr(this Random rand, char start, char stop, int count) =>
        string.Join("", new byte[count].Select(_ => (char)rand.Next(start, stop + 1)));
}