using System.Linq;

class Luhn
{
	private long Number { get; set; }

	public Luhn(long i)
	{
		Number = i;
	}

	public int Checksum { get { return Addends.Sum(); } }

	public int[] Addends
	{
		get
		{
			var addends = Number.ToString().ToCharArray().Select(ch => ch - '0').ToArray();
			for (int i = addends.Length - 2; i >= 0; i -= 2)
			{
				addends[i] *= 2;
				if (addends[i] > 9) addends[i] -= 9;
			}
			return addends;
		}
	}

	public int CheckDigit { get { return (int)(Number % 10); } }

	public bool Valid { get { return Checksum % 10 == 0; } }

	public static long Create(long i)
	{
		var l = new Luhn(i * 10 + 0);
		while (!l.Valid)
		{
			l.Number++;
		}
		return l.Number;
	}
}
