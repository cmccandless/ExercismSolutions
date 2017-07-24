import java.lang.Enum;
import java.util.*;
import java.util.stream.*;

public class Poker {
	private static Map<Character, Integer> values = new HashMap() {{
		put('2',2);
		put('3',3);
		put('4',4);
		put('5',5);
		put('6',6);
		put('7',7);
		put('8',8);
		put('9',9);
		put('T',10);
		put('J',11);
		put('Q',12);
		put('K',13);
		put('A',14);
	}};
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
	private static List<Integer> getCounts(List<String> cards) {
		return cards.stream()
			.map(s -> s.charAt(0))
			.collect(Collectors.groupingBy(x -> x, Collectors.counting()))
			.values()
			.stream()
			.sorted()
			.collect(Collectors.toList());
	}
	private static boolean isStraight(List<String> cards) {
		return false;
	}
	private static boolean isFlush(List<String> cards) {
		return false;
	}
	private static HandType classify(List<String cards, List<Integer> counts) {
		String countStr = counts.stream()
			.map(c -> c.toString())
			.collect(Collectors.joining(","));
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
	private static List<String> toCards(String hand) {
		return Arrays.stream(hand.split(" "))
			.sorted()
			.collect(Collectors.toList());
	}
	private static int compareCards(String card1, String card2) {
		return Integer.compare(values.get(card1.charAt(1)) - 
							   values.get(card2.charAt(1)));
	}
	private static int compareHands(String hand1, String hand2) {
		List<String> cards1, cards2;
		List<Integer> counts1, counts2;
		HandType type1, type2;
		cards1 = toCards(hand1);
		counts1 = getCounts(cards1);
		type1 = classify(cards1, counts1);
		cards2 = toCards(hand2);
		counts2 = getCounts(cards2);
		type2 = classify(cards2, counts2);
		int c = Enum.compareTo(type1, type2);
		if (c == 0) {
			switch (type1) {
				case HIGHCARD:
					for (int i = cards1.size() - 1; i >= 0; i--) {
						int c2 = compareCards(cards1.get(i), cards2.get(i));
						if (c2 == 0) continue;
					}
					break;
				case PAIR:
				case TWOPAIR:
				case THREEKIND:
				case STRAIGHT:
				case FLUSH:
				case FULLHOUSE:
				case FOURKIND:
				case STRAIGHTFLUSH:
			}
		}
		else if (c < 0) {
			return -1;
		}
		else {
			return 1;
		}
		return 0;
	}
	public List<String> getBestHands() {
		List<String> results = new ArrayList();
		for (String hand : hands) {
			if (results.isEmpty()) results.add(hand);
			else {
				switch (compareHands(results.get(0), hand)) {
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