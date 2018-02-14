import java.util.*;

public class BowlingGame {
	private static String ERROR_NEG = "Negative roll is invalid";
	private static String ERROR_PINCOUNT = 
		"Pin count exceeds pins on the lane";
	private static String ERROR_INCOMPLETE = 
		"Score cannot be taken until the end of the game";
	private static String ERROR_GAMEOVER = "Cannot roll after game is over";
	private LinkedList<Integer> rolls = new LinkedList<>();
	public void roll(int pins) { rolls.offer(pins); }
	private static void validateBall(int ball) {
		if (ball < 0) throw new IllegalStateException(ERROR_NEG);
		if (ball > 10) throw new IllegalStateException(ERROR_PINCOUNT);
	}
	public int score() {
		int f, sum = 0;
		for (f = 1; !rolls.isEmpty(); f++) {
			if (f > 10) throw new IllegalStateException(ERROR_GAMEOVER);
			int r = rolls.pop();
			validateBall(r);
			sum += r;
			if (rolls.isEmpty()) break;
			int r2 = rolls.pop();
			if (r != 10) validateBall(r + r2);
			if (r == 10) { //STRIKE
				if (rolls.isEmpty())
					throw new IllegalStateException(ERROR_INCOMPLETE);
				int r3 = rolls.peek();
				if (f == 10) {
					validateBall(r3);
					if (r2 != 10) validateBall(r2 + r3);
				}
				sum += r2 + r3;
				if (f == 10) rolls.pop();
				else rolls.push(r2);
			} else if (r + r2 == 10) { //SPARE
				if (rolls.isEmpty()) 
					throw new IllegalStateException(ERROR_INCOMPLETE);
				sum += r2 + (f == 10 ? rolls.pop() : rolls.peek());
			} else sum += r2;
		}
		if (f < 11) throw new IllegalStateException(ERROR_INCOMPLETE);
		return sum;
	}
}
