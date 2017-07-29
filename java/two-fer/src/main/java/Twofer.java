public class Twofer {
	private Boolean isNullOrWhitespace(String s) {
		return s == null || s.trim().isEmpty();
	}
	
    public String twofer(String name) {
        return String.format("One for %s, one for me.", isNullOrWhitespace(name) ? "you" : name);
    }
}