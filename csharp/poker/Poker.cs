using System;
using System.Collections.Generic;
using System.Linq;

public static class Poker
{
	private static readonly List<string> types = 
		new List<string>{"11111","2111","221","S","F","32","41","SF"};
	private const string straights = "2345678910111213142345";
	private static string CardSuit(string card) => card.Substring(card.Length - 1);
	private static int CardValue(string card) =>
		int.Parse(card.Substring(0, card.Length - 1)
		              .Replace("J", "11")
		              .Replace("Q", "12")
		              .Replace("K", "13")
		              .Replace("A", "14"));
	private static bool IsStraight(int[] values)
	{
		if (values.Length != 5) return false;
		// var nums = new[]{2,3,4,5,6,7,8,9,10,11,12,13,14,2,3,4,5};
		var nums = new[]{5,4,3,2,14,13,12,11,10,9,8,7,6,5,4,3,2};
		for (int i = 0; i < nums.Length - 4; i++)
		{
			int j = 0;
			for (; j < 5 && values[j] == nums[i+j]; j++);
			if (j == 5) return true;
		}
		return false;
	}
	public static string[] BestHands(string[] hands) =>
		(from hand in hands
		 let cards = hand.Split(" ")
		 let flush = cards.Select(CardSuit).Distinct().Count() == 1
		 let cardsByValue = (from card in cards
		 		   group card by CardValue(card) into grp
		 		   let grping = (value: grp.Key, count: grp.Count())
				   orderby grping.count descending, grping.value descending
		 		   select grping).ToArray()
		 let values = (from tup in cardsByValue
		               orderby tup.value descending
		 		       select tup.value).ToArray()
		 let straight = IsStraight(values)
		 let counts = string.Join("", from tup in cardsByValue
		                              select tup.count)
		 let _class = types.IndexOf(!(straight || flush) ? counts : 
		 			                  $"{(straight ? "S" : "")}{(flush ? "F" : "")}")
		 let valuesR = string.Join("", values)
		 group (hand: hand, values: valuesR) by _class into grp
		 orderby grp.Key descending
         from tup in grp
		 group tup.hand by tup.values into grp
		 orderby grp.Key descending
         select grp.ToArray()).First();
}