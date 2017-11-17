import java.util.stream.*;

class IsbnVerifier {
    private int parseDigit(char digit, int i) {
        if (digit == 'X' && i == 1) return 10;
        return i * Integer.parseInt(Character.toString(digit));
    }

    boolean isValid(String stringToVerify) {
        String clean = stringToVerify.replace("-", "");
        try {
            return clean.length() == 10 &&
                   IntStream.range(0, 10)
                            .map(i -> parseDigit(clean.charAt(i), 10 - i))
                            .sum() % 11 == 0;
        } catch (NumberFormatException ex) {
            return false;
        }
    }

}
