import java.util.stream.IntStream;

class ReverseString {
  
    String reverse(String str) {
        return IntStream.range(0, str.length())
                        .mapToObj(i -> str.charAt(str.length() - i - 1))
                        .collect(StringBuilder::new,
                                 StringBuilder::append,
                                 StringBuilder::append)
                        .toString();
    }
  
}
