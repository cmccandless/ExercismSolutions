import java.util.*;
import java.util.stream.IntStream;

public class LargestSeriesProductCalculator {
    private long[] series;
    public LargestSeriesProductCalculator(String series) {
        if (series == null)
            throw new IllegalArgumentException("String to search must be non-null.");
        if (!series.chars().allMatch(Character::isDigit))
            throw new IllegalArgumentException("String to search may only contains digits.");
        this.series = series.chars()
            .mapToLong(c -> (long)(c - '0'))
            .toArray();
    }
    
    public long calculateLargestProductForSeriesLength(int length) {
        if (length > series.length) 
            throw new IllegalArgumentException("Series length must be less than or equal to the length of the string to search.");
        if (length < 0)
            throw new IllegalArgumentException("Series length must be non-negative.");
        return IntStream.range(0,series.length - length + 1)
            .mapToLong(i -> IntStream.range(0,length)
                .mapToLong(j -> series[j + i])
                .reduce((long)1, (a, b) -> a * b))
            .max()
            .getAsLong();
    }

}
