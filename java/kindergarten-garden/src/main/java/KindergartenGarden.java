import java.util.*;
import java.util.stream.*;

public class KindergartenGarden {
    private String[] students = { "Alice", "Bob", "Charlie", "David", 
        "Eve", "Fred", "Ginny", "Harriet", 
        "Ileana", "Joseph", "Kincaid", "Larry"};
    Map<String, List<Plant>> plantsByStudent = new HashMap<>();
    public KindergartenGarden(String garden, String[] students) {
        this.students = Arrays.stream(students)
            .sorted()
            .toArray(String[]::new);
        parseGarden(garden.split("\\n"));
    }

    public KindergartenGarden(String garden) {
        parseGarden(garden.split("\\n"));
    }
    
    private static List<Plant> getPlants(String[] lines, int i) {
        return Arrays.asList(
            lines[0].charAt(i),
            lines[0].charAt(i + 1),
            lines[1].charAt(i),
            lines[1].charAt(i + 1))
            .stream()
            .map(Plant::getPlant)
            .collect(Collectors.toList());
    }
    
    private void parseGarden(String[] lines) {
        for (int i = 0; i < lines[0].length(); i += 2) 
            plantsByStudent.put(students[i / 2], getPlants(lines, i));
    }

    public List<Plant> getPlantsOfStudent(String student) {
        return plantsByStudent.getOrDefault(student, new ArrayList<Plant>());
    }
}
