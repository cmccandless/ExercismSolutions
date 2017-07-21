public class RotationalCipher {
	private int n;
	public RotationalCipher(int n) {
		this.n = n;
	}
	private char rotateChar(int ch) {
		if (!Character.isLetter((char)ch)) return (char)ch;
		int base = ch < 'a' ? 'A' : 'a';
		return (char)(((ch - base + n) % 26) + base);
	}
	public String rotate(String input) {
		return input.codePoints()
			.mapToObj(this::rotateChar)
			.collect(StringBuilder::new,
				StringBuilder::append,
				StringBuilder::append)
			.toString();
	}
}
