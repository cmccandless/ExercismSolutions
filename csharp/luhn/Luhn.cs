using System.Collections.Generic;

/*
public class Luhn
{
	private long Number { get; set; }

	public Luhn(long i)
	{
		Number = i;
	}

	public int Checksum => Addends.Sum(); 

	public int[] Addends
	{
		get
		{
			var addends = Number.ToString().Select(ch => ch - '0').ToArray();
			for (int i = addends.Length - 2; i >= 0; i -= 2)
			{
				addends[i] *= 2;
				if (addends[i] > 9) addends[i] -= 9;
			}
			return addends;
		}
	}

	public int CheckDigit => (int)(Number % 10); 

	public bool Valid => Number > 0 && Checksum % 10 == 0;

    public static bool IsValid(string s)
    {
        try { return new Luhn(long.Parse(s.Replace(" ", ""))).Valid; }
        catch (FormatException) { return false; }
    }

	public static long Create(long i)
	{
		var l = new Luhn(i * 10 + 0);
		while (!l.Valid) l.Number++;
		return l.Number;
	}
}/**/

public static class Luhn
{
    private static int Sum(List<int> digits)
    {
        var result = 0;
        var doDouble = false;
        for (int i = digits.Count - 1; i >= 0; i--)
        {
            if (doDouble)
            {
                digits[i] *= 2;
                if (digits[i] > 9) digits[i] -= 9;
            }
            result += digits[i];
            doDouble = !doDouble;
        }
        return result;
    }

    public static bool IsValid(string number)
    {
        var digits = new List<int>();
        foreach (var ch in number)
        {
            if (ch == ' ') continue;
            else if (char.IsDigit(ch)) digits.Add(ch - '0');
            else return false;
        }
        return digits.Count > 1 && Sum(digits) % 10 == 0;
    }
}
