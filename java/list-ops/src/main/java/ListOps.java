import java.util.*;
import java.util.function.*;

public abstract class ListOps {
    public static <T> int length(Collection<T> list) {
        int result = 0;
        for (T t : list) result++;
        return result;
    }
    public static <T> List<T> reverse(Collection<T> list) {
        LinkedList<T> result = new LinkedList<>();
        for (T t : list) result.push(t);
        return new ArrayList<>(result);
    }
    public static <T1, T2> List<T2> map(Collection<T1> list, Function<T1, T2> f) {
        List<T2> result = new ArrayList<>();
        for (T1 t : list) result.add(f.apply(t));
        return result;
    }
    public static <T> List<T> filter(Collection<T> list, Predicate<T> f) {
        List<T> result = new ArrayList<>();
        for (T t : list) if (f.test(t)) result.add(t);
        return result;
    }
    @SuppressWarnings("unchecked")
    public static <T> List<T> concat(Collection<T>... lists) {
        List<T> result = new ArrayList<>();
        for (Collection<T> list : lists) for (T t : list) result.add(t);
        return result;
    }
    public static <T1, T2> T2 reduce(Collection<T1> list, T2 seed, BiFunction<T2, T1, T2> f, BiFunction<T2, T2, T2> m) {
        for (T1 t : list) seed = f.apply(seed, t);
        return seed;
    }
}
