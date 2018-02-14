import java.util.*;
import java.util.stream.*;

public final class School {
    private class Student {
        public String name;
        public int grade;
        public Student(String n, int g) {
            name = n;
            grade = g;
        }
    }
    private List<Student> all = new ArrayList<>();
    public int numberOfStudents() {
        return all.size();
    }
    public void add(String name, int g) {
        all.add(new Student(name, g));
    }
    public List<String> grade(int g) {
        return all.stream()
            .filter(s -> s.grade == g)
            .map(s -> s.name)
            .sorted()
            .collect(Collectors.toList());
    }
    public Map<Integer, List<String>> studentsByGradeAlphabetical() {
        return all.stream()
            .map(s -> s.grade)
            .distinct()
            .collect(HashMap::new,
                (a, g) -> a.put(g, grade(g)),
                Map::putAll);
    }
}
