import java.util.Arrays;
import java.util.function.*;

public final class PrimeCalculator {
    final class IterateResult {
        public int result, count;
        public IterateResult(int r, int c) {
            result = r;
            count = c;
        }
    }
    private IterateResult iterate(boolean[] np, int p, int ostart,  int ostop, Function<Integer, Boolean> c,Function<Integer, Integer> istart) {
        for (int i = ostart; i < ostop; i++) {
            if (np[i]) continue;
            if (c.apply(++p)) return new IterateResult(i, p);
            for (int j = istart.apply(i); j < np.length; j+= i) np[j] = true;
        }
        return new IterateResult(-1, p);
    }
    private boolean[] expand(boolean[] np, int s, int p) {
        np = Arrays.copyOf(np,np.length * 2);
        iterate(np, p, 2, s, _p -> false, i -> (s / i) * i);
        return np;
    }
    public int nth(int n) {
        if (n < 1) throw new IllegalArgumentException();
        boolean[] np = new boolean[1024];
        int p = 0, start = 2;
        while (np.length < Integer.MAX_VALUE) {
            IterateResult r = iterate(np, p, start, np.length, _p -> _p == n, i -> i + i);
            if (r.result > 1) return r.result;
            np = expand(np, start = np.length, p = r.count);
        }
        return -1;
    }
}