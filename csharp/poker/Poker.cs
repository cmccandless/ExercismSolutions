using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Poker
{
	private static Dictionary<char, int> values = new Dictionary<char, int>
	{
		{'2',2},{'3',3},{'4',4},{'5',5},{'6',6},{'7',7},{'8',8},{'9',9},
		{'T',10},{'J',11},{'Q',12},{'K',13},{'A',14},
	};

	private static int[] next = new[] { 0, 0, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 2 };

	private const string suits = "HDSC";

	private static int Score(string hand)
	{
		var cards = (from card in hand.Split()
					 let value = values[card[0]]
					 orderby value
					 select new Card() { Value = value, Suit = card[1] }).ToArray();
		var score = 0;
		var highCard = cards.Last().Value;
		var straight = cards.Count(c => suits.Select(s =>
			new Card() { Value = next[c.Value], Suit = s }).Any(c2 => cards.Contains(c2))) == 4;
		var flush = cards.All(c => c.Suit.Equals(cards[0].Suit));
		var byValue = (from card in cards
					   group card by card.Value into grp
					   orderby grp.Count() descending, grp.Key descending
					   select new { Value = grp.Key, Count = grp.Count() }).ToArray();
		if (straight && flush)
		{
			score = 8;
			if (cards[3].Value != values['K']) highCard = byValue[1].Value;
		}
		else if (byValue[0].Count == 4) { score = 7; highCard = byValue[0].Value; }
		else if (byValue[0].Count == 3 && byValue[1].Count == 2) { score = 6; highCard = byValue[0].Value; }
		else if (flush) { score = 5; }
		else if (straight)
		{
			score = 4;
			if (cards[3].Value != values['K']) highCard = byValue[1].Value;
		}
		else if (byValue[0].Count > 1)
		{
			switch(byValue[0].Count)
			{
				case 3: score = 3; break;
				case 2: score = byValue[1].Count == 2 ? 2 : 1; break;
			}
			highCard = byValue[0].Value;
		}
		return (score << 4) + highCard;
	}

	public static string[] BestHands(string[] hands)
	{
		return (from hand in hands
				group hand by Score(hand) into grp
				orderby grp.Key descending
				select grp).First().ToArray();
	}

	private class Card
	{
		public int Value;
		public char Suit;
		public override bool Equals(object obj)
		{
			var other = obj as Card;
			return other != null && this.Value == other.Value && this.Suit == other.Suit;
		}
		public override int GetHashCode() { return base.GetHashCode(); }
		public override string ToString() { return Value.ToString() + Suit; }
	}
}
