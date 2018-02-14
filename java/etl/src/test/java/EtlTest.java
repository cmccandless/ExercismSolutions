import org.junit.Test;
// import org.junit.Ignore;

import java.util.*;

import static org.junit.Assert.assertEquals;


public class EtlTest {
    private final Etl etl = new Etl();

    @Test
    public void testTransformOneValue() {
        Map<Integer, List<String>> old = new HashMap<>();
        old.put(1, Arrays.asList("A"));
        old = Collections.unmodifiableMap(old);

        Map<String, Integer> expected = new HashMap<>();
        expected.put("a", 1);
        expected = Collections.unmodifiableMap(expected);

        assertEquals(expected, etl.transform(old));
    }

    // @Ignore("Remove to run test")
    @Test
    public void testTransformMoreValues() {
        Map<Integer, List<String>> old = new HashMap<>();
        old.put(1, Arrays.asList("A", "E", "I", "O", "U"));
        old = Collections.unmodifiableMap(old);

        Map<String, Integer> expected = new HashMap<>();
        expected.put("a", 1);
        expected.put("e", 1);
        expected.put("i", 1);
        expected.put("o", 1);
        expected.put("u", 1);
        expected = Collections.unmodifiableMap(expected);

        assertEquals(expected, etl.transform(old));
    }

    // @Ignore("Remove to run test")
    @Test
    public void testMoreKeys() {
        Map<Integer, List<String>> old = new HashMap<>();
        old.put(1, Arrays.asList("A", "E"));
        old.put(2, Arrays.asList("D", "G"));
        old = Collections.unmodifiableMap(old);

        Map<String, Integer> expected = new HashMap<>();
        expected.put("a", 1);
        expected.put("e", 1);
        expected.put("d", 2);
        expected.put("g", 2);
        expected = Collections.unmodifiableMap(expected);

        assertEquals(expected, etl.transform(old));
    }

    // @Ignore("Remove to run test")
    @Test
    public void testFullDataset() {
        Map<Integer, List<String>> old = new HashMap<>();
        old.put(1, Arrays.asList("A", "E", "I", "O", "U", "L", "N", "R", "S", "T"));
        old.put(2, Arrays.asList("D", "G"));
        old.put(3, Arrays.asList("B", "C", "M", "P"));
        old.put(4, Arrays.asList("F", "H", "V", "W", "Y"));
        old.put(5, Arrays.asList("K"));
        old.put(8, Arrays.asList("J", "X"));
        old.put(10, Arrays.asList("Q", "Z"));
        old = Collections.unmodifiableMap(old);

        Map<String, Integer> expected = new HashMap<>();
        expected.put("a", 1);
        expected.put("b", 3);
        expected.put("c", 3);
        expected.put("d", 2);
        expected.put("e", 1);
        expected.put("f", 4);
        expected.put("g", 2);
        expected.put("h", 4);
        expected.put("i", 1);
        expected.put("j", 8);
        expected.put("k", 5);
        expected.put("l", 1);
        expected.put("m", 3);
        expected.put("n", 1);
        expected.put("o", 1);
        expected.put("p", 3);
        expected.put("q", 10);
        expected.put("r", 1);
        expected.put("s", 1);
        expected.put("t", 1);
        expected.put("u", 1);
        expected.put("v", 4);
        expected.put("w", 4);
        expected.put("x", 8);
        expected.put("y", 4);
        expected.put("z", 10);
        expected = Collections.unmodifiableMap(expected);

        assertEquals(expected, etl.transform(old));
    }
}
