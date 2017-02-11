using System;
using System.Linq;

class Crypto
	{
		private string Text { get; set; }
		public Crypto(string str)
		{
			Text = str;
		}

		public string NormalizePlaintext
		{
			get
			{
				return string.Join(string.Empty, Text.ToLower().Where(ch => char.IsLetterOrDigit(ch)));
			}
		}

		public int Size
		{
			get
			{
				return (int)Math.Ceiling(Math.Sqrt(NormalizePlaintext.Length));
			}
		}

		public string[] PlaintextSegments()
		{
			var size = Size;
			return string.Join(string.Empty,
				NormalizePlaintext.Select((ch, i) => ch.ToString() + (i > 0 && ((i+1) % size) == 0 ? " " : string.Empty)))
				.Split(new[]{" "}, StringSplitOptions.RemoveEmptyEntries);
		}

		public string Ciphertext()
		{
			var plainText = PlaintextSegments();
			return string.Join(string.Empty, 
				Enumerable.Range(0, Size)
				.SelectMany(i => plainText.Select(w => i < w.Length ? w[i].ToString() : string.Empty)));
		}

		public string NormalizeCiphertext()
		{
			var plainText = PlaintextSegments();
			return string.Join(" ",
				Enumerable.Range(0, Size)
				.Select(i => string.Join(string.Empty, 
					plainText.Select(w => i < w.Length ? w[i].ToString() : string.Empty))));
		}
	}
