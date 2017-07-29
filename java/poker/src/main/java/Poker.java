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
	public Poker(List<String> hands) { this.hands = hands; }
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
    private static int compareGroups(Map.Entry<Character, Long> a, 
                                     Map.Entry<Character, Long> b) {
        int c = -a.getValue().compareTo(b.getValue());
        return c != 0 ? c :
            -Integer.compare(values.get(a.getKey()), values.get(b.getKey()));
    }
    private static Long[] entryToArray(Map.Entry<Character, Long> e) {
        return new Long[]{(long)values.get(e.getKey()), e.getValue()};
    }
	private static List<Long[]> getCounts(List<String> cards) {
		return cards.stream()
			.map(s -> s.charAt(0))
			.collect(Collectors.groupingBy(x -> x, Collectors.counting()))
			.entrySet()
			.stream()
            .sorted(Poker::compareGroups)
            .map(Poker::entryToArray)
			.collect(Collectors.toList());
	}
	private static boolean isStraight(List<Long[]> counts) {
        int[] values = Arrays.stream(countsToString(counts, 0).split(","))
            .mapToInt(n -> Integer.parseInt(n))
            .sorted()
            .toArray();
        return values.length == 5 && 
            (values[4] - values[0] == 4 ||
            (values[4] == 14 && values[0] == 2 && values[3] - values[0] == 3));
	}
	private static boolean isFlush(List<String> cards) {
		return cards.stream()
            .map(s -> s.charAt(1))
            .collect(Collectors.groupingBy(x -> x, Collectors.counting()))
            .size() == 1;
	}
    private static String countsToString(List<Long[]> counts, int i) {
        return counts.stream()
            .map(c -> c[i].toString())
            .collect(Collectors.joining(","));
    }
	private static HandType classify(List<String> cards, List<Long[]> counts) {
        String countStr = "";
        if (isStraight(counts)) countStr = "S";
        if (isFlush(cards)) countStr += "F";
        if (countStr.isEmpty()) countStr = countsToString(counts, 1);
        switch(countStr) {
            case "SF": return HandType.STRAIGHTFLUSH;
            case "4,1": return HandType.FOURKIND;
            case "3,2": return HandType.FULLHOUSE;
            case "F": return HandType.FLUSH;
            case "S": return HandType.STRAIGHT;
            case "3,1,1": return HandType.THREEKIND;
            case "2,2,1": return HandType.TWOPAIR;
            case "2,1,1,1": return HandType.PAIR;
            default: return HandType.HIGHCARD;
        }
	}
	private static List<String> handToCards(String hand) {
		return Arrays.stream(hand.split(" "))
			.sorted()
			.collect(Collectors.toList());
	}
	private static int compareHands(String hand1, String hand2) {
		List<String> cards1 = handToCards(hand1);
		List<Long[]> counts1 = getCounts(cards1);
		HandType type1 = classify(cards1, counts1);
        
        List<String> cards2 = handToCards(hand2);
		List<Long[]> counts2 = getCounts(cards2);
		HandType type2 = classify(cards2, counts2);
        
		int c = type1.compareTo(type2);
        for (int i = 0; c == 0 && i < counts1.size(); i++)
            c = counts1.get(i)[0].compareTo(counts2.get(i)[0]);
        return c;
	}
	public List<String> getBestHands() {
		List<String> results = new ArrayList();
		for (String hand : hands) {
			if (results.isEmpty()) {
                results.add(hand);
                continue;
            }
            switch (compareHands(results.get(0), hand)) {
                case 0: results.add(hand); break;
                case -1:  results = Arrays.asList(hand); break;
            }
		}
		return results;
	}
}