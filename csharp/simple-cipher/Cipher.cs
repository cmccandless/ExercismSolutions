using System;
using System.Linq;

class Cipher
{
	private static Random rand = new Random();
	public Cipher(string key = null)
	{
		Key = key ?? string.Concat(new int[100].Select(i => (char)rand.Next('a','z')));
		if (!Key.Any() || Key.Any(ch => ch > 'z' || ch < 'a')) throw new ArgumentException();
	}

	public string Key { get; set; }

	public string Encode(string value)
	{
		return string.Concat(value.Select((ch, i) => 
			(char)('a' + ((ch - 2 * 'a' + Key[i % Key.Length]) % 26))
			));
	}

	public string Decode(string value)
	{
		return string.Concat(value.Select((ch, i) => 
			(char)(((((ch - 'a') % 26) + 26 + 'a' - Key[i % Key.Length])%26)+'a')
			));
	}
}
