public final class PhoneNumber {
    private final static String wrongLengthExceptionMessage = 
        "Number must be 10 or 11 digits";
    private final static String numberIs11DigitsButDoesNotStartWith1ExceptionMessage =
        "Can only have 11 digits if number starts with '1'";
    private final static String illegalCharacterExceptionMessage =
        "Illegal character in phone number. Only digits, spaces, parentheses, hyphens or dots accepted.";
    private String number;
    public PhoneNumber(String num) {
        if (num.matches(".*(?:\\p{Alpha}|[^\\d. \\-()]).*"))
            throw new IllegalArgumentException(illegalCharacterExceptionMessage);
        number = num.replaceAll("[^\\d]","");
        if (number.length() / 2 != 5) 
            throw new IllegalArgumentException(wrongLengthExceptionMessage);
        if (number.length() > 10) {
            if (number.charAt(0) != '1')
                throw new IllegalArgumentException(numberIs11DigitsButDoesNotStartWith1ExceptionMessage);
            number = number.substring(1);
        }
    }
    public String getNumber() {
        return number;
    }
}