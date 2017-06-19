import java.util.regex.*;

public class RunLengthEncoding {
    private static Pattern pattEnc = Pattern.compile("^((.)\\2*)(.*)$");
    private static Pattern pattDec = Pattern.compile("^(\\d*)(.)(.*)$");
    
    private static String lenToStr(int n) {
        return (n > 1 ? Integer.toString(n) : "");
    }
    
    public String encode(String data) {
        Matcher m = pattEnc.matcher(data);
        return m.find() ?
            lenToStr(m.group(1).length()) + m.group(2) + encode(m.group(3)) :
            data;
    }
    
    private static int tryParseInt(String s) {
        return s.isEmpty() ? 1 : Integer.parseInt(s);
    }
    
    private static String repeat(String s, int n) {
        return new String(new char[n]).replaceAll("\0", s);
    }

    public String decode(String encodedData) {
        Matcher m = pattDec.matcher(encodedData);
        return m.find() ? 
            repeat(m.group(2), tryParseInt(m.group(1))) + decode(m.group(3)) :
            encodedData;
    }
}
