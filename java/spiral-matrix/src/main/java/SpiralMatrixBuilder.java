public class SpiralMatrixBuilder {
	private int[][] roll(int[][] ms, int size) {
		if (size == 0) return new int[0][];
		int n = ms.length;	
		if (n == 0) return roll(new int[][]{new int[]{size * size}}, size);
		else if (n == size) return ms;
		int[][] nms = new int[n+1][];
		for (int i=0; i<=n; i++) nms[i] = new int[n+1];
		if (n % 2 == size % 2) {
			int s = ms[0][0] - 1;
			// Copy existing values from ms to nms
			for (int i = 0; i < n; i++) System.arraycopy(ms[i], 0, nms[i], 1, n);
			// Generate new left side of nms
			for (int i = 0; i < n; i++) nms[i][0] = s - i;
			// Generate new bottom side of nms
			s = nms[n - 1][0] - 1;
			for (int i = 0; i <= n; i++) nms[n][i] = s - i;
		}
		else {
			int s = ms[n-1][n-1] - 1;
			// Copy existing values from ms to nms
			for (int i = 0; i < n; i++) System.arraycopy(ms[i], 0, nms[i + 1], 0, n);
			// Generate new right side of nms
			for (int i = 0; i <= n; i++) nms[n - i][n] = s - i;
			// Generate new top side of nms
			s = nms[1][n] - 1;
			for (int i = 0; i <= n; i++) nms[0][n - i] = s - i;
		}
		return roll(nms, size);
	}
	
	public int[][] buildMatrixOfSize(int size) {
		return roll(new int[0][], size);
	}
}