import java.util.stream.*;

public final class Atbash {
    private static char encode(int decoded) {
        return (char)(Character.isLetter(decoded) ? 0xDB - decoded : decoded);
    }
    private static String withSpace(int i, char c) {
        return (i != 0 && (i % 5) == 0 ? " " : "") + encode(c);
    }
    // Assumes <decoded> is all lowercase alphanumeric
    private static String __encode(String decoded) {
        return IntStream.range(0,decoded.length())
            .collect(StringBuilder::new,
                (s, i) -> s.append(withSpace(i,decoded.charAt(i))),
                StringBuilder::append)
            .toString();
    }
    public String encode(String decoded) {
        return __encode(decoded.toLowerCase().replaceAll("[^a-z\\d]",""));
    }
    public String decode(String encoded) {
        return encoded.replaceAll("\\s","")
            .chars()
            .collect(StringBuilder::new,
                (s, c) -> s.append(encode(c)),
                StringBuilder::append)
            .toString();
    }
}
