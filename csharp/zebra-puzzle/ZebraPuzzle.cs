using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercism.zebra_puzzle
{
    public enum Nationality { Norwegian, Japanese, Englishman, Ukrainian, Spaniard }
    public enum Drink { Water, OrangeJuice, Tea, Milk, Coffee }
    public enum Pet { Zebra, Dog, Snails, Horse, Fox }
    public enum Smoke { OldGold, Parliaments, Kools, LuckyStrike, Chesterfields }
    public enum Color { Green, Blue, Red, Ivory, Yellow }
    public static class Position
    {
        public static int First = 0;
        public static int Second = 1;
        public static int Middle = 2;
        public static int Fourth = 3;
        public static int Last = 4;
    }
    internal class Person
    {
        public Nationality Nation;
        public Color Color;
        public Drink Drink;
        public Smoke Smoke;
        public Pet Pet;
    }
    public static class ZebraPuzzle
    {
        private static int[][] perms =
            Permutations.AllPermutations(new[] { 0, 1, 2, 3, 4 }).ToArray();

        private static IEnumerable<Person> solution { get; } = Solve().FirstOrDefault();

        public static Nationality? WhoDrinks(Drink drink) =>
            solution.FirstOrDefault(p => p.Drink == drink)?.Nation;

        public static Nationality? WhoOwns(Pet pet) =>
            solution.FirstOrDefault(p => p.Pet == pet)?.Nation;

        private static Dictionary<T, int> AsDict<T>(int[] a) =>
            a.Zip(Enum.GetValues(typeof(T)).Cast<T>(), (v, k) => new { k, v })
            .ToDictionary(x => x.k, x => x.v);

        private static string Multi(params int[] a) => string.Join("", a);

        private static bool NextTo(int a, int b) => Math.Abs(a - b) == 1;

        internal static IEnumerable<IEnumerable<Person>> Solve()
        {
            return from nations in perms.Select(AsDict<Nationality>)
                   where nations[Nationality.Norwegian] == Position.First

                   join colors in from c in perms.Select(AsDict<Color>)
                                  where c[Color.Green] == c[Color.Ivory] + 1
                                  where c[Color.Blue] == Position.Second
                                  select c
                   on nations[Nationality.Englishman] equals colors[Color.Red]

                   join smokes in perms.Select(AsDict<Smoke>)
                   on Multi(colors[Color.Yellow],
                       nations[Nationality.Japanese])
                   equals Multi(smokes[Smoke.Kools],
                       smokes[Smoke.Parliaments])

                   join pets in perms.Select(AsDict<Pet>)
                   on Multi(nations[Nationality.Spaniard],
                       smokes[Smoke.OldGold])
                   equals Multi(pets[Pet.Dog],
                       pets[Pet.Snails])

                   where NextTo(smokes[Smoke.Chesterfields], pets[Pet.Fox]) &&
                       NextTo(smokes[Smoke.Kools], pets[Pet.Horse])

                   join drinks in from d in perms.Select(AsDict<Drink>)
                                  where d[Drink.Milk] == Position.Middle
                                  select d
                   on Multi(colors[Color.Green],
                       nations[Nationality.Ukrainian],
                       smokes[Smoke.LuckyStrike])
                   equals Multi(drinks[Drink.Coffee],
                       drinks[Drink.Tea],
                       drinks[Drink.OrangeJuice])

                   select from kn in nations
                          join kc in colors on kn.Value equals kc.Value
                          join kd in drinks on kn.Value equals kd.Value
                          join ks in smokes on kn.Value equals ks.Value
                          join kp in pets on kn.Value equals kp.Value
                          select new Person
                          {
                              Nation = kn.Key,
                              Color = kc.Key,
                              Drink = kd.Key,
                              Smoke = ks.Key,
                              Pet = kp.Key
                          };
        }
    }
}

public static class Permutations
{
    public static IEnumerable<T[]> AllPermutations<T>(T[] set) where T : IComparable
    {
        set = set.ToArray();
        yield return set.ToArray();
        while (NextPermutation(set)) yield return set.ToArray();
    }

    //http://stackoverflow.com/a/11208543
    public static bool NextPermutation<T>(T[] set) where T : IComparable
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
}