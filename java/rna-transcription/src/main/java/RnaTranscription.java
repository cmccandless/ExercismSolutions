public class RnaTranscription {
    public static char transcribe(int codon) {
        return transcribe((char)codon);
    }
    public static char transcribe(char codon) {
        switch(codon)
        {
            case 'G': return 'C';
            case 'C': return 'G';
            case 'T': return 'A';
            case 'A': return 'U';
            default: 
                String err = codon + " is not a valid RNA codon.";
                throw new IllegalArgumentException(err);
        }
    }
    public String transcribe(String dnaStrand) {
        return dnaStrand.chars()
            .mapToObj(RnaTranscription::transcribe)
            .collect(StringBuilder::new, StringBuilder::append, StringBuilder::append)
            .toString();
    }
}
