public class BinarySearch
{
    private int[] array;
    public BinarySearch(int[] array) => this.array = array;

    public int Find(int x) => 
        array.Length == 0 ? -1 : 
        Find(x, 0, array.Length - 1, array.Length / 2);

    private int Find(int x, int p, int q, int i) =>
        array[i].Equals(x) ? i :
        q <= p ? -1 :
        array[i].CompareTo(x) < 0 ? Find(x, i + 1, q, (q + i + 1) / 2) :
        Find(x, p, i - 1, (i - 1 + p) / 2);
}
