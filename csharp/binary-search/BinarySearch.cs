public class BinarySearch
{
    public static int Search(int[] a, int x) => 
        a.Length == 0 ? -1 : 
        Search(a, x, 0, a.Length - 1, a.Length / 2);

    public static int Search(int[] a, int x, int p, int q, int i) =>
        a[i] == x ? i :
        q <= p ? -1 :
        a[i] < x ? Search(a, x, i + 1, q, (q + i + 1) / 2) :
        Search(a, x, p, i - 1, (i - 1 + p) / 2);
}
