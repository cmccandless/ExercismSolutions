using System.Linq;

static class Trinary
{
    private static bool Invalid(char ch) => ch > '2' || ch < '0';

    public static int ToDecimal(string trinary) =>
        trinary.Any(Invalid) ? 0 : trinary.Aggregate(0, (a, x) => a * 3 + x - '0');
}