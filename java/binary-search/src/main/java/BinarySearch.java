import java.util.List;

public class BinarySearch<T extends Comparable> {
    private List<T> list;
    public BinarySearch(List<T> list) {
        this.list = list;
    }
    public int indexOf(T x) {
        if (list.isEmpty()) return -1;
        int p = 0, q = list.size() - 1;
        while (q > p) {
            int r = (q - p) / 2 + p;
            T t = list.get(r);
            int c = t.compareTo(x);
            if (c == 0) return r;
            else if (c == 1) q = r - 1;
            else p = r + 1;
        }
        return list.get(p).equals(x) ? p : -1;
    }
}
