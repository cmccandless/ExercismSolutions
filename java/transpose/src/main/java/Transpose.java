import java.util.*;
import java.util.stream.*;

public class Transpose {
	public String transpose(String str) {
		char[][] from = Arrays.stream(str.split("\n"))
			.map(s -> s.toCharArray())
			.toArray(char[][]::new);
		int m = from.length;
		int n = Arrays.stream(from)
			.mapToInt(a -> a.length)
			.max()
			.getAsInt();
		char[][] to = new char[n][];
		for (int i = 0; i < to.length; i++) 
			to[i] = new String(new char[m]).replace("\0", " ").toCharArray();
		for (int i = 0; i < m; i ++) {
			for (int j = 0; j < from[i].length; j++) {
				to[j][i] = from[i][j];
			}
		}
		return Arrays.stream(to)
			.map(line -> new String(line))
			.collect(Collectors.joining("\n"))
			.replaceAll("\\s+$", "");
	}
}