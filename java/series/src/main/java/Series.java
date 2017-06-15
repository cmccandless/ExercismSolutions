import java.util.*;
import java.util.stream.*;

public class Series {
    private List<Integer> digits;
    public Series(String s) {
        digits = s.chars().map(i -> i - '0').boxed().collect(Collectors.toList());
    }
    public List<Integer> getDigits() {
        return digits;
    }
    public List<List<Integer>> slices(int n) {
        if (n > digits.size()) throw new IllegalArgumentException();
        return IntStream.rangeClosed(0, digits.size() - n)
            .mapToObj(i -> IntStream.range(i, i + n)
                .map(j -> digits.get(j))
                .boxed()
                .collect(Collectors.toList()))
            .collect(Collectors.toList());
    }
}
