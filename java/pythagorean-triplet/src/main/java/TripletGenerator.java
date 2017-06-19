import java.util.*;
import java.util.stream.*;

public final class TripletGenerator {
    private int min = 1, max = 1, sum;
    private boolean sumSet = false;
    public TripletGenerator() { }
    private TripletGenerator(TripletGenerator other) {
        min = other.min;
        max = other.max;
        sum = other.sum;
        sumSet = other.sumSet;
    }
    public TripletGenerator withFactorsLessThanOrEqualTo(int n) {
        TripletGenerator other = new TripletGenerator(this);
        other.max = n;
        return other;
    }
    public TripletGenerator withFactorsGreaterThanOrEqualTo(int n) {
        TripletGenerator other = new TripletGenerator(this);
        other.min = n;
        return other;
    }
    public TripletGenerator thatSumTo(int n) {
        TripletGenerator other = new TripletGenerator(this);
        other.sum = n;
        other.sumSet = true;
        return other;
    }
    private boolean keep(PythagoreanTriplet t) {
        return t.isPythagorean() && (!sumSet || t.calculateSum() == sum);
    }
    public List<PythagoreanTriplet> build() {
        return IntStream.rangeClosed(min, max)
            .mapToObj(a -> IntStream.rangeClosed(a, max)
                .mapToObj(b -> IntStream.rangeClosed(b, max)
                    .mapToObj(c -> new PythagoreanTriplet(a,b,c))
                    .filter(this::keep))
                .flatMap(s -> s))
            .flatMap(s -> s)
            .collect(Collectors.toList());
    }
}