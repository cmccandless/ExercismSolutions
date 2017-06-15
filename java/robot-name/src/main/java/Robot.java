import java.util.Random;

public final class Robot {
    private static final Random r = new Random();
    private String name;
    public Robot() {
        reset();
    }
    private static char randChar(char min, int max) {
        return (char)(r.nextInt(max) + min);
    }
    public void reset() {
        name = new StringBuilder()
            .append(randChar('A', 26))
            .append(randChar('A', 26))
            .append(randChar('0', 10))
            .append(randChar('0', 10))
            .append(randChar('0', 10))
            .toString();
    }
    public String getName() {
        return name;
    }
}