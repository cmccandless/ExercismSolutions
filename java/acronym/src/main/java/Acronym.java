final class Acronym {
    private String phrase;
    Acronym(String phrase) {
        this.phrase = phrase.chars()
            .mapToObj(c -> (char)c)
            .filter(c -> Character.isLetter(c) || c == ' ' || c == '-')
            .collect(StringBuilder::new,
                StringBuilder::append,
                StringBuilder::append)
            .toString();
    }

    String get() {
        StringBuilder s = new StringBuilder();
        for (String word : phrase.split("[-\\s]+"))
        {
            if (word.toUpperCase().equals(word)) s.append(word.charAt(0));
            else
            {
                for (int i=0;i<word.length();i++)
                {
                    if (i == 0 || Character.isUpperCase(word.charAt(i)))
                        s.append((char)word.charAt(i));
                }
            }
        }
        return s.toString().toUpperCase();
    }

}
