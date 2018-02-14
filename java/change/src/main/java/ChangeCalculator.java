import java.util.*;
import java.util.stream.*;

final class ChangeCalculator {
    private List<Integer> coins;
    public ChangeCalculator(List<Integer> coins) {
        this.coins = coins;
    }
    private void validate(int targetValue) {
        if (targetValue < 0)
            throw new IllegalArgumentException("Negative totals are not allowed.");
        if (
            !coins.isEmpty() &&
            targetValue > 0 &&
            targetValue % coins.get(0) != 0
        ) {
            String fmt = "The total %d cannot be represented in the given currency.";
            throw new IllegalArgumentException(String.format(fmt, targetValue));
        }
    }
    public List<Integer> computeMostEfficientChange(int targetValue) {
        validate(targetValue);
        List<List<Integer>> m = new ArrayList<>();
        m.add(new ArrayList<>());
        for (int t = 1; t <= targetValue; t++) m.add(null);
        for (int c = 0; c < coins.size(); c++) {
            for (int t = 1; t < m.size(); t++) {
                int coin = coins.get(c);
                List<Integer> sx = Arrays.asList(coin);
                if (coin == t) {
                    m.set(t, sx);
                } else {
                    for (int t2 = 1; t2 < t; t2++) {
                        if (
                            coin + t2 == t &&
                            m.get(t2) != null &&
                            (
                                m.get(t) == null ||
                                m.get(t2).size() + 1 < m.get(t).size()
                            )
                        ) {
                            m.set(
                                t,
                                Stream.concat(
                                    m.get(t2).stream(),
                                    sx.stream()
                                ).collect(Collectors.toList())
                            );
                        }
                    }
                }
            }
        }
        return m.get(targetValue);
    }
}
