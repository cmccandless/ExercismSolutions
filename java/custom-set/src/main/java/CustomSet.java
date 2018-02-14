import java.util.*;
import java.util.stream.*;

public final class CustomSet<T extends Comparable<T>> {
    private T data = null;
    private CustomSet<T> left, right;
    public CustomSet() { }
    public CustomSet(Iterable<T> c) {
        for (T t : c) add(t);
    }
    private CustomSet<T> getLeft() {
        if (left == null) left = new CustomSet<>();
        return left;
    }
    private CustomSet<T> getRight() {
        if (right== null) right = new CustomSet<>();
        return right;
    }
    public boolean isEmpty() {
        return data == null;
    }
    public boolean contains(T x) {
        if (data == null) return false;
        int h = x.hashCode(), d = data.hashCode();
        return h == d || 
            (h < d ? 
                left != null && left.contains(x) : 
                right != null && right.contains(x));
    }
    public Stream<T> stream() {
        if (data == null) return new ArrayList<T>().stream();
        Stream<T> s = Stream.of(data);
        if (left != null) s = Stream.concat(left.stream(), s);
        if (right != null) s = Stream.concat(s, right.stream());
        return s;
    }
    public boolean isSubset(CustomSet<T> other) {
        return other.stream().allMatch(this::contains);
    }
    public boolean isDisjoint(CustomSet<T> other) {
        return other.stream().allMatch(t -> !contains(t));
    }
    public boolean equals(CustomSet<T> other) {
        return isSubset(other) && other.isSubset(this);
    }
    public void add(T x) {
        int h = x.hashCode();
        if (data == null) data = x;
        int d = data.hashCode();
        if (h == d) data = x;
        else (h < d ? getLeft() : getRight()).add(x);
    }
    public CustomSet<T> getIntersection(CustomSet<T> other) {
        return stream()
            .filter(other::contains)
            .collect(CustomSet::new,
                CustomSet::add,
                (a, b) -> a.getUnion(b));
    }
    public CustomSet<T> getDifference(CustomSet<T> other) {
        return stream()
            .filter(t -> !other.contains(t))
            .collect(CustomSet::new,
                CustomSet::add,
                (a, b) -> a.getUnion(b));
    }
    public CustomSet<T> getUnion(CustomSet<T> other) {
        return new CustomSet<>(Stream.concat(stream(),
            other.stream()).collect(Collectors.toList()));
    }
}
