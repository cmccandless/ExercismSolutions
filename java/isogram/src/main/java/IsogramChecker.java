public final class IsogramChecker {
    public static boolean isIsogram(String word) {
        return __isIsogram(word.toLowerCase().replaceAll("[^a-z]", ""));
    }
    private static boolean __isIsogram(String word) {
        return word.chars().distinct().count() == word.length();
    }
}