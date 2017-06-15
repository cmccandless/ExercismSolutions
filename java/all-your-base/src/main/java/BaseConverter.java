import java.util.*;

final class BaseConverter {
    private int base10;
    public BaseConverter(int inputBase, int[] digits) {
        if (inputBase < 2)
            throw new IllegalArgumentException("Bases must be at least 2.");
        if (digits.length == 0)
            throw new IllegalArgumentException("You must supply at least one digit.");
        if (digits.length > 1 && digits[0] == 0)
            throw new IllegalArgumentException("Digits may not contain leading zeros.");
        for (int i = 0; i < digits.length; i++) {
            if (digits[i] < 0)
                throw new IllegalArgumentException("Digits may not be negative.");
            if (digits[i] >= inputBase)
                throw new IllegalArgumentException("All digits must be strictly less than the base.");
        }   
        base10 = toBase10(inputBase, digits);
    }
    public int[] convertToBase(int outputBase) {
        return fromBase10(base10, outputBase);
    }
    public static int toBase10(int inputBase, int[] digits) {
        return Arrays.stream(digits).reduce(0, (a, r) -> a * inputBase + r);
    }
    public static int[] fromBase10(int n, int outputBase) {
        if (outputBase < 2)
            throw new IllegalArgumentException("Bases must be at least 2.");
        List<Integer> digits = new ArrayList();
        for (; n > 0; n /= outputBase) digits.add(0, n % outputBase);
        return digits.isEmpty() ?
            new int[] { 0 } :
            digits.stream().mapToInt(i -> (int)i).toArray();
    }
}
