using System.Collections.Generic;
using System.Linq;

public class SumOfMultiples
{
    private static IEnumerable<int> MultsLessThan(int n, int mult)
    {
        var result = new List<int>();
        for (int x = n; x < mult; x += n) result.Add(x);
        return result;
    }

    public static int To(int[] nums, int mult) => new HashSet<int>(nums.SelectMany(n => MultsLessThan(n, mult))).Sum();
}
