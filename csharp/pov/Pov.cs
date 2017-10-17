using System.Collections.Generic;
using System.Linq;

static class Pov
{
    public static Graph<T> CreateGraph<T>(T v, IEnumerable<Graph<T>> c) =>
        new Graph<T>(v, c);
    public static Graph<T> FromPOV<T>(T v, Graph<T> g)
    {
        var g2 = g.Find(v);
        if (g2 == null) return null;
        if (g2.Parent == null) return g2;
        var r = new Graph<T>(v, g2.Children);
        var h = g2.Parent.Duplicate();
        h.Children.Remove(g2);
        r.AddChild(FromPOV(h.Value, h));
        return r;
    }
    public static T[] TracePathBetween<T>(T v1, T v2, Graph<T> g)
    {
        List<T> path;
        g = FromPOV(v1, g);
        if (g == null) return null;
        g = g.Find(v2, out path);
        if (g == null) return null;
        return path.ToArray();
    }
}
class Graph<T>
{
    private int depth = 0;
    private Graph<T> parent = null;
    public Graph<T> Parent
    {
        get { return parent; }
        set
        {
            parent = value;
            if (value != null) depth = value.depth + 1;
        }
    }
    public T Value;
    public List<Graph<T>> Children = new List<Graph<T>>();
    public Graph(T v, IEnumerable<Graph<T>> c)
    {
        Value = v;
        Children.AddRange(c.Where(g => g != null));
        foreach (var ch in Children) ch.Parent = this;
    }
    public void AddChild(Graph<T> c) => (c.Parent = this).Children.Add(c);
    public Graph<T> Find(T v)
    {
        List<T> trash;
        return Find(v, out trash);
    }
    public Graph<T> Find(T v, out List<T> path)
    {
        path = new List<T>();
        path.Add(Value);
        if (Value.Equals(v)) return this;
        foreach (var c in Children)
        {
            List<T> trash;
            var r = c.Find(v, out trash);
            if (r == null) continue;
            path.AddRange(trash);
            return r;
        }
        return null;
    }
    public Graph<T> Duplicate(int depth = 0)
    {
        var root = this;
        while (root.depth > depth) root = root.Parent;
        var result = new Graph<T>(root.Value, new Graph<T>[0]);
        foreach (var c in root.Children)
            result.AddChild(c.Duplicate(depth + 1));
        return depth == 0 ? result.Find(Value) : result;
    }
    public override bool Equals(object obj)
    {
        var other = obj as Graph<T>;
        return other != null && Value.Equals(other.Value) &&
            Children.SequenceEqual(other.Children);
    }
    public override int GetHashCode() => Value.GetHashCode();
    public override string ToString()
    {
        var result = Value.ToString();
        if (Children.Any())
        {
            result = "(" + result + ": ";
            foreach (var c in Children) result += c.ToString() + " ";
            result += ")";
        }
        return result;
    }
}
