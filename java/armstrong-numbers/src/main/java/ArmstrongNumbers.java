class ArmstrongNumbers {

	boolean isArmstrongNumber(int numberToCheck) {
		return armstrongSum(Integer.toString(numberToCheck)) == numberToCheck;
	}

	int armstrongSum(String numberToCheck) {
		return numberToCheck.chars()
			.map(i -> (int)Math.pow(i - '0', numberToCheck.length()))
			.sum();
	}
}
