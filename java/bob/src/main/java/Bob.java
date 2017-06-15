public final class Bob {
    private static boolean isSilence(String phrase) {
        return phrase.replaceAll("\\s","").isEmpty();
    }
    private static boolean isShouting(String phrase) {
        return phrase.chars().anyMatch(c -> Character.isLetter((char)c)) && 
            phrase.toUpperCase().equals(phrase);
    }
    private static boolean isQuestion(String phrase) {
        return phrase.endsWith("?");
    }
    public String hey(String phrase) {
        return isSilence(phrase) ? "Fine. Be that way!" :
        isShouting(phrase) ? "Whoa, chill out!" :
        isQuestion(phrase) ? "Sure." :
        "Whatever.";
    }
}