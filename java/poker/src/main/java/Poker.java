import java.util.*;
import java.util.stream.*;

public class Poker {
	private List<String> hands;
	public Poker(List<String> hands) {
		this.hands = hands;
	}
	private enum HandType {
		HIGHCARD,
		PAIR,
		TWOPAIR,
		THREEKIND,
		STRAIGHT,
		FLUSH,
		FULLHOUSE,
		FOURKIND,
		STRAIGHTFLUSH,
	}
	private static String getCounts(List<String> cards) {
		return cards.stream()
			.map(s -> s.charAt(0))
			.collect(Collectors.groupingBy(x -> x, Collectors.counting()))
			.values()
			.stream()
			.sorted()
			.map(c -> c.toString())
			.collect(Collectors.joining(","));
	}
	private static boolean isStraight(List<String> cards) {
		return false;
	}
	private static boolean isFlush(List<String> cards) {
		return false;
	}
	private static HandType classify(String hand) {
		List<String> cards = Arrays.stream(hand.split(" "))
			.sorted()
			.collect(Collectors.toList());
		String counts = getCounts(cards);
		boolean straight = isStraight(cards);
		boolean flush = isFlush(cards);
		if (straight && flush) return HandType.STRAIGHTFLUSH;
		if (counts.equals("1,4")) return HandType.FOURKIND;
		if (counts.equals("2,3")) return HandType.FULLHOUSE;
		if (flush) return HandType.FLUSH;
		if (straight) return HandType.STRAIGHT;
		if (counts.equals("1,2,2")) return HandType.TWOPAIR;
		if (counts.equals("1,1,1,2")) return HandType.PAIR;
		return HandType.HIGHCARD;
	}
	private static int compare(String hand1, String hand2) {
		return 0;
	}
	public List<String> getBestHands() {
		List<String> results = new ArrayList();
		for (String hand : hands) {
			if (results.isEmpty()) results.add(hand);
			else {
				switch (compare(results.get(0), hand)) {
					case 0:
						results.add(hand);
						break;
					case 1: 
						results = Arrays.asList(hand);
						break;
				}
			}
		}
		return results;
	}
}