using System;
using System.Collections.Generic;
using System.Linq;

public class Scrabble
{
	private static string scoreStr = @"A, E, I, O, U, L, N, R, S, T       1
D, G                               2
B, C, M, P                         3
F, H, V, W, Y                      4
K                                  5
J, X                               8
Q, Z                               10";

	private static Dictionary<char, int> ScoreDict = new Dictionary<char,int>();

	static Scrabble()
	{
		foreach (var line in scoreStr.Split('\n'))
		{
			var parts = line.Split(new[]{", "}, StringSplitOptions.None);
			var scoreParts = parts.Last().Split(new[]{" "}, StringSplitOptions.RemoveEmptyEntries);
			var score = int.Parse(scoreParts[1]);
			parts[parts.Length - 1] = scoreParts[0];
			foreach (var ch in parts)
			{
				ScoreDict[ch[0]] = score;
				ScoreDict[ch.ToLower()[0]] = score;
			}
		}
	}

	public static int Score(string word)
	{
		return word == null ? 0 :word.Trim().Sum(ch => ScoreDict[ch]);
	}
}

