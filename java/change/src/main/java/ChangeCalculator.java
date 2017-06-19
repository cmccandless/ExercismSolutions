import java.util.*;
import java.util.stream.*;

final class ChangeCalculator {
    private List<Integer> coins;
    public ChangeCalculator(List<Integer> coins) {
        this.coins = coins;
    }
    private void validate(int targetValue) {
        if (targetValue < 0) throw new IllegalArgumentException("Negative totals are not allowed.");
        if (!coins.isEmpty() && targetValue > 0 && targetValue % coins.get(0) != 0) {
            String msg = String.format("The total %d cannot be represented in the given currency.", targetValue);
            throw new IllegalArgumentException(msg);
        }
    }
    private static <T> int size(List<T> a) {
        return a == null ? 0x7FFFFFFF : a.size();
    }
    private void setPosition(int targetValue, int coin, List<Integer>[][] m, int t, int c) {
        List<Integer> sx = Arrays.asList(coin);
        if (t == coin) m[t][c] = sx;
        else if (size(m[t][c]) > size(m[t][c - 1])) m[t][c] = m[t][c - 1];
        for (int t2 = 0; t2 < t; t2++) {
            if (t2 + coin != t) continue;
            if (size(m[t][c]) > (long)size(m[t2][c]) + 1)
                m[t][c] = Stream.concat(m[t2][c].stream(),sx.stream())
                    .collect(Collectors.toList());
        }
    }
    private void setRow(int targetValue, List<Integer>[][] m, int t) {
        for (int c = 1; c <= coins.size(); c++)
            setPosition(targetValue, coins.get(c - 1), m, t, c);
    }
    public List<Integer> computeMostEfficientChange(int targetValue) {
        validate(targetValue);
        List<Integer> m[][] = new List[targetValue + 1][coins.size() + 1];
        for (int c = 0; c <= coins.size(); c++) m[0][c] = new ArrayList<Integer>();
        for (int t = 1; t <= targetValue; t++) setRow(targetValue, m, t);
        return m[targetValue][coins.size()];
    }
}
