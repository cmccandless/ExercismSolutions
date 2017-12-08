class Markdown {
    String parse(String markdown) {
        StringBuilder result = new StringBuilder();
        boolean activeList = false;
        for (String line : markdown.split("\n")) {
            String theLine = parseHeader(line);
            if (theLine == null) theLine = parseListItem(line);
            if (theLine == null) theLine = parseParagraph(line);
            if (theLine.startsWith("<li>") == !activeList) {
                result.append(activeList ? "</ul>" : "<ul>");
                activeList = !activeList;
            }
            result.append(theLine);
        }
        if (activeList) result.append("</ul>");
        return result.toString();
    }

    private String parseHeader(String markdown) {
        int count = 0;
        for (; count < markdown.length() && markdown.charAt(count) == '#'; count++);
        return count != 0 ? 
            wrap(markdown.substring(count + 1), String.format("h%d", count)) :
            null;
    }

    private String parseListItem(String markdown) {
        return markdown.startsWith(("*")) ? 
            wrap(parseSomeSymbols(markdown.substring(2)), "li") : 
            null;
    }

    private String parseParagraph(String markdown) {
        return wrap(parseSomeSymbols(markdown), "p");
    }

    private String parseWrapped(String markdown, String oldTag, String newTag) {
        return markdown.replaceAll(String.format("%s(.+)%1$s", oldTag), wrap("$1", newTag));
    }

    private String parseSomeSymbols(String markdown) {
        return parseWrapped(parseWrapped(markdown, "__", "strong"), "_", "em");
    }

    private String wrap(String text, String tag) {
        return String.format("<%s>%s</%1$s>", tag, text);
    }
}
