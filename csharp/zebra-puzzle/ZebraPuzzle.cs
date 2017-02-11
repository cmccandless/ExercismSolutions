using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum Nationality { Norwegian, Japanese, Englishman, Ukrainian, Spaniard }
public enum Drink { Water, OrangeJuice, Tea, Milk, Coffee }
public enum Pet { Zebra, Dog, Snails, Horse, Fox }
public enum Position { First, Second, Middle, Fourth, Last }
public enum Smoke { OldGold, Parliaments, Kools, LuckyStrike, Chesterfields }
public enum Color { Green, Blue, Red, Ivory, Yellow }
public class ZebraPuzzle
{
	private const int HOUSES = 5;
	private static Person[] Solution = Solve();
	public static Func<Pet, Nationality> WhoOwns =
		pet => Solution.FirstOrDefault(p => p.Pet == pet).Nationality;
	public static Func<Drink, Nationality> WhoDrinks = 
		d => Solution.FirstOrDefault(p => p.Drink == d).Nationality;
	private static Person[] Solve()
	{
		var perms = AllPermutations(new[] { 0, 1, 2, 3, 4 }).ToArray();
		foreach (var pNations in perms)
		{
			var nations = pNations.Select(i => (Nationality)i).ToList();
			if (nations[(int)Position.First] != Nationality.Norwegian) continue;
			foreach (var pColors in perms)
			{
				var colors = pColors.Select(i => (Color)i).ToList();
				if (colors[nations.IndexOf(Nationality.Englishman)] != Color.Red) continue;
				if (colors.IndexOf(Color.Green) != colors.IndexOf(Color.Ivory) + 1) continue;
				if (colors[(int)Position.Second] != Color.Blue) continue;
				foreach (var pSmokes in perms)
				{
					var smokes = pSmokes.Select(i => (Smoke)i).ToList();
					if (smokes[colors.IndexOf(Color.Yellow)] != Smoke.Kools) continue;
					if (smokes[nations.IndexOf(Nationality.Japanese)] != Smoke.Parliaments) continue;
					foreach (var pDrinks in perms)
					{
						var drinks = pDrinks.Select(i => (Drink)i).ToList();
						if (colors[drinks.IndexOf(Drink.Coffee)] != Color.Green) continue;
						if (nations[drinks.IndexOf(Drink.Tea)] != Nationality.Ukrainian) continue;
						if (drinks[(int)Position.Middle] != Drink.Milk) continue;
						if (smokes[drinks.IndexOf(Drink.OrangeJuice)] != Smoke.LuckyStrike) continue;
						foreach (var pPets in perms)
						{
							var pets = pPets.Select(i => (Pet)i).ToList();
							if (pets[nations.IndexOf(Nationality.Spaniard)] != Pet.Dog) continue;
							if (smokes[pets.IndexOf(Pet.Snails)] != Smoke.OldGold) continue;
							if (Math.Abs(smokes.IndexOf(Smoke.Chesterfields) -
								pets.IndexOf(Pet.Fox))!=1) continue;
							if (Math.Abs(smokes.IndexOf(Smoke.Kools) - 
								pets.IndexOf(Pet.Horse))!=1) continue;
							return (from i in perms[0]
									select new Person()
									{
										Nationality = nations[i],
										Pet = pets[i],
										Drink = drinks[i],
										Smoke = smokes[i],
										Position = (Position)i,
										Color = colors[i]
									}).ToArray();
						}
					}
				}
			}
		}
		return null;
	}
	private static IEnumerable<T[]> AllPermutations<T>(T[] set) where T : IComparable
	{
		set = set.ToArray();
		yield return set.ToArray();
		while (NextPermutation(set)) yield return set.ToArray();
	}
	//http://stackoverflow.com/a/11208543
	private static bool NextPermutation<T>(T[] set) where T : IComparable
	{
		/*
		 Knuths
		 1. Find the largest index j such that a[j] < a[j + 1]. If no such index exists, the permutation is the last permutation.
		 2. Find the largest index l such that a[j] < a[l]. Since j + 1 is such an index, l is well defined and satisfies j < l.
		 3. Swap a[j] with a[l].
		 4. Reverse the sequence from a[j + 1] up to and including the final element a[n].

		 */
		var largestIndex = -1;
		for (var i = set.Length - 2; i >= 0; i--)
		{
			//if (numList[i] < numList[i + 1])
			if (set[i].CompareTo(set[i + 1]) < 0)
			{
				largestIndex = i;
				break;
			}
		}

		if (largestIndex < 0) return false;

		var largestIndex2 = -1;
		for (var i = set.Length - 1; i >= 0; i--)
		{
			//if (numList[largestIndex] < numList[i])
			if (set[largestIndex].CompareTo(set[i]) < 0)
			{
				largestIndex2 = i;
				break;
			}
		}

		var tmp = set[largestIndex];
		set[largestIndex] = set[largestIndex2];
		set[largestIndex2] = tmp;

		for (int i = largestIndex + 1, j = set.Length - 1; i < j; i++, j--)
		{
			tmp = set[i];
			set[i] = set[j];
			set[j] = tmp;
		}

		return true;
	}
	private class Person
	{
		public Color Color;
		public Nationality Nationality;
		public Pet Pet;
		public Position Position;
		public Smoke Smoke;
		public Drink Drink;
	}
}
