import java.util.*;
import java.util.stream.*;

public final class Crypto {
    private String normalizedPlaintext;
    private int size, count;
    public Crypto(String s) {
        normalizedPlaintext = s.toLowerCase().replaceAll("[^a-z\\d]", "");
        size = (int)Math.ceil(Math.sqrt(normalizedPlaintext.length()));
        count = (int)Math.ceil(normalizedPlaintext.length() / (double)size);
    }
    public String getNormalizedPlaintext() { return normalizedPlaintext; }
    public int getSquareSize() { return size; }
    private String getSegment(String s, int i) {
        return s.substring(i * size, Math.min(s.length(), (i + 1) * size));
    }
    public List<String> getPlaintextSegments() {
        return IntStream.range(0, count)
            .mapToObj(i -> getSegment(normalizedPlaintext, i))
            .collect(Collectors.toList());
    }
    private static String tryCharAt(String s, int i) {
        char c;
        try { c = s.charAt(i); }
        catch (StringIndexOutOfBoundsException ex) { c = ' '; }
        return Character.toString(c);
    }
    private static String join(Stream<String> ss) {
        return join(ss, "");
    }
    private static String join(Stream<String> ss, String delim) {
        return ss.collect(Collectors.joining(delim));
    }
    private Stream<String> getCipherTextSegments() {
        List<String> segments = getPlaintextSegments();
        final int n = segments.size();
        return IntStream.range(0, size)
            .mapToObj(i -> IntStream.range(0, n)
                .mapToObj(j -> tryCharAt(segments.get(j), i)))
            .map(Crypto::join)
            .map(s -> s.replaceAll("\\s+$", ""));
    }
    public String getCipherText() {
        return join(getCipherTextSegments());
    }
    public String getNormalizedCipherText() {
        return join(getCipherTextSegments(), " ");
    }
}