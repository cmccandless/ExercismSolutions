using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public static class ParallelLetterFrequency
{
    public static Dictionary<char, int> Calculate(IEnumerable<string> lines)
    {
        var dict = new ConcurrentDictionary<char, int>();
        var tasks = lines.Select(line => Task.Run(() =>
        {
            foreach (var ch in line.ToLower().Where(char.IsLetter))
                dict.AddOrUpdate(ch, 1, (_, c) => c + 1);
        })).ToList();
        foreach (var task in tasks) task.Wait();
        return dict.Where(kvp => kvp.Value != 0).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
    }
}
