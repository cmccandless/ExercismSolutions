using System.Collections.Generic;

public class Flattener
{
    public static IEnumerable<object> Flatten(List<object> list)
    {
        var sin = new Stack<object>(list);
        var sout = new Stack<object>();
        while (sin.Count > 0)
        {
            var x = sin.Pop();
            if (x is List<object>)
            {
                foreach (var y in x as List<object>) sin.Push(y);
            }
            else if (x != null) sout.Push(x);
        }
        return sout;
    }
}
