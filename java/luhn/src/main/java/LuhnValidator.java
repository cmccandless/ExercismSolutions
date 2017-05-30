import java.util.stream.*;

final class LuhnValidator {
    static int parseChar(String s, int i) {
        return (i % 2 != 0 ? 2 : 1) * (s.charAt(s.length() - 1 - i) - '0');
    }
    static int bound(int i) {
        return i > 9 ? i - 9 : i;
    }
    boolean isValid(String candidate) {
        return isStrippedValid(candidate.replaceAll(" ", ""));
    }
    boolean isStrippedValid(String candidate) {
        if (candidate.equals("0")) return false;
        if (!candidate.chars().allMatch(Character::isDigit)) return false;
        return IntStream.range(0, candidate.length())
            .map(i -> bound(parseChar(candidate, i)))
            .sum() % 10 == 0;
    }
}
