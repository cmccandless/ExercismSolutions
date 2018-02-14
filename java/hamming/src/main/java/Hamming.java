import java.util.stream.IntStream;

public class Hamming {
    private String left, right;
    Hamming(String leftStrand, String rightStrand) {
        if (leftStrand.length() != rightStrand.length())
            throw new IllegalArgumentException();
        left = leftStrand;
        right = rightStrand;
    }
    int getHammingDistance() {
        return (int)IntStream.range(0,left.length())
            .filter(i -> left.charAt(i) != right.charAt(i))
            .count();
    }
}
