import java.util.*;
import java.util.regex.*;

class ProteinTranslator {

    List<String> translate(String rnaSequence) {
        Matcher m = Pattern.compile("[A-Z]{3}").matcher(rnaSequence);
        List<String> proteins = new ArrayList<>();
        while (m.find()) {
            switch(m.group()) {
                case "AUG":
                    proteins.add("Methionine");
                    break;
                case "UUU":
                case "UUC":
                    proteins.add("Phenylalanine");
                    break;
                case "UUA":
                case "UUG":
                    proteins.add("Leucine");
                    break;
                case "UCU":
                case "UCC":
                case "UCA":
                case "UCG":
                    proteins.add("Serine");
                    break;
                case "UAU":
                case "UAC":
                    proteins.add("Tyrosine");
                    break;
                case "UGU":
                case "UGC":
                    proteins.add("Cysteine");
                    break;
                case "UGG":
                    proteins.add("Tryptophan");
                    break;
                default:
                    return proteins;
            }
        }
        return proteins;
    }
}
