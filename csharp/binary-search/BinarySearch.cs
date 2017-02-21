namespace Exercism.binary_search
{
    public class BinarySearch
    {
        public static int Search(int[] input, int x)
        {
            switch (input.Length)
            {
                case 0: return -1;
                case 1: return input[0] == x ? 0 : -1;
                default:
                    var p = 0;
                    var q = input.Length - 1;
                    var i = -1;
                    while (q > p)
                    {
                        i = (q - p) / 2 + p;
                        if (input[i] == x) return i;
                        else if (input[i] < x) p = i + 1;
                        else q = i - 1;
                    }
                    return i >= 0 && input[p] == x ? p : -1;
            }
        }
    }
}