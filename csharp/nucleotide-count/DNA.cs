using System;
using System.Collections.Generic;

public class DNA
{
	public Dictionary<char, int> NucleotideCounts;

	public int Count(char ch)
	{
		if (!NucleotideCounts.ContainsKey(ch)) throw new InvalidNucleotideException(ch.ToString());
		return NucleotideCounts[ch];
	}

	public DNA(string dna)
	{
		NucleotideCounts = new Dictionary<char, int>()
			{
				{'A',0},
				{'C',0},
				{'G',0},
				{'T',0},
			};
		foreach (var ch in dna)
		{
			if (!NucleotideCounts.ContainsKey(ch)) throw new InvalidNucleotideException(ch.ToString());
			NucleotideCounts[ch]++;
		}
	}
}

public class InvalidNucleotideException : Exception
{
	public InvalidNucleotideException(string msg) : base(msg)
	{

	}
}
