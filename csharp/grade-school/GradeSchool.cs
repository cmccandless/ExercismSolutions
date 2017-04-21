using System.Collections.Generic;
using System.Linq;

public class School
{
    private Dictionary<int, List<string>> byGrade = new Dictionary<int, List<string>>();

    public List<string> Roster() => byGrade.Values.SelectMany(v => v).OrderBy(x => x).ToList();

    public List<string> Grade(int grade) => byGrade.ContainsKey(grade) ? byGrade[grade].OrderBy(x => x).ToList() : new List<string>();

    public void Add(string name, int grade)
    {
        if (!byGrade.ContainsKey(grade)) byGrade[grade] = new List<string>();
        byGrade[grade].Add(name);
    }
}
