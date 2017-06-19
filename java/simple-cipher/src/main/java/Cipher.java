import java.util.*;
import java.util.stream.*;

public final class Cipher {
    private static final int A = 'a';
    private static final int TWOA = A * 2;
    private static final int N = 26;
    private static final int NPLUSA = N + A;
    
    private static Random rand = new Random();
    private String key;
    public Cipher() {
        this.key = randomKey();
    }
    public Cipher(String key) {
        this.key = key;
        if (!validKey(key)) throw new IllegalArgumentException();
    }
    public String getKey() { return key;}
    private char getKeyChar(int i) {
        return key.charAt(i % key.length());
    }
    private static char randomLetter(int i) {
        return (char)(A + rand.nextInt(N));
    }
    private static String join(Stream<Character> s) {
        return s.collect(StringBuilder::new, 
                StringBuilder::append, 
                StringBuilder::append)
            .toString();
    }
    private static String randomKey() {
        return join(IntStream.range(0,100)
            .mapToObj(Cipher::randomLetter));
    }
    private static boolean isLowerCase(String s) {
        return s.codePoints()
            .mapToObj(c -> (char)c)
            .allMatch(Character::isLowerCase);
    }
    private static boolean validKey(String key) {
        return !key.isEmpty() && isLowerCase(key);
    }
    private char encode(char ch, int i) {
        return (char)(A + ((ch - TWOA + getKeyChar(i)) % N));
    }
    public String encode(String data) {
        return join(IntStream.range(0,data.length())
            .mapToObj(i -> encode(data.charAt(i),i)));
    }
    private char decode(char ch, int i) {
        return (char)(((((ch - A) % N) + NPLUSA - getKeyChar(i)) % N) + A);
    }
    public String decode(String data) {
        return join(IntStream.range(0,data.length())
            .mapToObj(i -> decode(data.charAt(i),i)));
    }
}