import java.util.*;
import java.util.stream.*;

public final class Crypto {
    private String normalizedPlaintext;
    private int size;
    public Crypto(String s) {
        normalizedPlaintext = s.toLowerCase().replaceAll("[^a-z\\d]", "");
        size = (int)Math.ceil(Math.sqrt(normalizedPlaintext.length()));
    }
    public String getNormalizedPlaintext() {
        return normalizedPlaintext;
    }
    public int getSquareSize() {
        return size;
    }
    public List<String> getPlaintextSegments() {
        Queue<Character> q = normalizedPlaintext.codePoints()
            .mapToObj(c -> (char)c)
            .collect(LinkedList::new,
                Queue::offer,
                LinkedList::addAll);
        List<String> result = new ArrayList();
        while (!q.isEmpty()) {
            StringBuilder s = new StringBuilder();
            for (int i = 0; i < size && !q.isEmpty(); i++) {
                s.append(q.poll());
            }
            result.add(s.toString());
        }
        return result;
    }
    public String getCipherText() {
        // char result[][] = new char[size][];
        final int n = (int)(normalizedPlaintext.length() / (double)size + 0.5);
        char result[][] = IntStream.range(0,size)
            .mapToObj(i -> new char[n])
            .toArray(char[][]::new);
        
        return "";
    }
    public String getNormalizedCipherText() {
        return "";
    }
}