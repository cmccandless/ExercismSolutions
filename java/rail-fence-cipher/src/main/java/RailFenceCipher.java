import java.util.*;
import java.util.stream.*;

public class RailFenceCipher {
    private int nRails;

    public RailFenceCipher(int rails) {
        nRails = rails;
    }

    public String getEncryptedData(String text) {
        if (nRails < 2) return text;
        
        StringBuilder rails[] = new StringBuilder[nRails];
        for (int i = 0; i < nRails; i++) {
            rails[i] = new StringBuilder();
        }

        int cap = 2 * nRails - 2;
        for (int i = 0; i < text.length(); i++) {
            int index = i % cap;
            if (index >= nRails)
                index = 2 * nRails - index - 2;
            rails[index].append(text.charAt(i));
        }

        return Arrays.stream(rails)
            .map(sb -> sb.toString())
            .collect(Collectors.joining());
    }

    public String getDecryptedData(String encrypted) {
        if (nRails < 2) return encrypted;

        int railCounts[] = new int[nRails];
        int cap = 2 * nRails - 2;
        for (int i = 0; i < encrypted.length(); i++) {
            int index = i % cap;
            if (index >= nRails)
                index = 2 * nRails - index - 2;
            railCounts[index] += 1;
        }

        @SuppressWarnings("unchecked")
        Queue<Character> rails[] = new Queue[nRails];
        int start = 0;
        for (int r = 0; r < nRails; r++) {
            rails[r] = new LinkedList<>();
            int stop = start + railCounts[r];
            for (;start < stop; start++)
                rails[r].offer(encrypted.charAt(start));
        }

        StringBuilder decoded = new StringBuilder();
        for (int i = 0; i < encrypted.length(); i++) {
            int index = i % cap;
            if (index >= nRails)
                index = 2 * nRails - index - 2;
            decoded.append(rails[index].poll());
        }

        return decoded.toString();
    }
}
