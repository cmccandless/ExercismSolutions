using System;
using System.Collections.Generic;
using System.Linq;

public class BookStore
{
    private const int BASE_COST = 8;
    private static double[] discount = new[] { 1, 1, .95, .9, .8, .75 };

    public static double CalculateTotalCost(List<int> list) =>
        BASE_COST * Math.Min(CalcMethod1(list), CalcMethod2(list));

    private static double SumSet(IEnumerable<int> s) => Math.Round(s.Count() * discount[s.Count()], 2);

    private static double CalcMethod1(List<int> list)
    {
        var stack = new Stack<int>(list.OrderBy(x => x));
        var sets = new List<List<int>>();
        var prev = 0;
        var index = 0;
        while (stack.Any())
        {
            var i = stack.Pop();
            if (i != prev)
            {
                index = 0;
                prev = i;
            }
            if (index >= sets.Count) sets.Add(new List<int>());
            sets[index++].Add(i);
        }
        return sets.Select(SumSet).Sum();
    }
    public static double CalcMethod2(List<int> list)
    {
        var stack = new Stack<int>(from x in list
                                   group x by x into grp
                                   orderby grp.Count()
                                   from y in grp
                                   select y);
        var sets = new List<HashSet<int>>();
        while (stack.Any())
        {
            var i = stack.Pop() - 1;
            var set = sets.FirstOrDefault(s => !s.Contains(i));
            if (set == null)
            {
                set = new HashSet<int>();
                sets.Add(set);
            }
            set.Add(i);
            sets = sets.OrderBy(s => s.Count).ToList();
        }
        return sets.Select(SumSet).Sum();
    }
}
