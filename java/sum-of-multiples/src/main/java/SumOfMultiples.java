import java.util.*;
import java.util.stream.*;

class SumOfMultiples {
    private int sum;
    SumOfMultiples(int number, int[] set) {
        sum = Arrays.stream(set)
            .mapToObj(i -> IntStream.iterate(i, j -> j + i)
                .limit((int)((number - 0.5) / i))
                .collect(HashSet<Integer>::new,
                    HashSet::add,
                    HashSet::addAll))
            .collect(HashSet<Integer>::new,
                HashSet::addAll,
                HashSet::addAll)
            .stream()
            .peek(System.out::println)
            .mapToInt(i -> i)
            .sum();
    }
    
    int getSum() {
        return sum;
    }

}
