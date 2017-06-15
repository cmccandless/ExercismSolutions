import java.util.*;

public final class PrimeFactorsCalculator {
    public List<Long> calculatePrimeFactorsOf(long n) {
        long limit = (long)Math.sqrt(n) + 2;
        Set<Long> np = new HashSet();
        List<Long> result = new ArrayList();
        for (long i = 2; i <= limit && n > 1; i++) {
            if (np.contains(i)) continue;
            if (n % i != 0) {
                for (long j = i + i; j < limit; j+= i) np.add(j);
                continue;
            }
            n /= i;
            result.add(i);
            if (n != 1) {
                List<Long> f = calculatePrimeFactorsOf(n);
                if (f.isEmpty()) result.add(n);
                else result.addAll(f);
            }
            break;
        }
        return result;
    }
}