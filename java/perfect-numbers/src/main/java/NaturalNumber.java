import java.util.*;
import java.util.stream.*;

final class NaturalNumber {
    private Classification c;
    public NaturalNumber(int n) {
        if (n < 1) throw new IllegalArgumentException("You must supply a natural number (positive integer)");
        int s = IntStream.range(1, n)
            .filter(i -> n % i == 0)
            .sum();
        c = s == n ? Classification.PERFECT :
            s < n ? Classification.DEFICIENT :
            Classification.ABUNDANT;
    }
    public Classification getClassification() {
        return c;
    }
}
