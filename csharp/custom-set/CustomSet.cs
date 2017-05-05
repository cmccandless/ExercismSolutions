using System.Collections.Generic;

public class CustomSet<T> : IEnumerable<T>
{
    public int Length => set.Count;
    private Dictionary<int, T> set;

    public CustomSet() { set = new Dictionary<int, T>(); }

    public CustomSet(T x) : this() { Insert(x); }

    public CustomSet(IEnumerable<T> xs)
        : this()
    {
        foreach (var x in xs) Insert(x);
    }

    public bool IsEmpty() => Length == 0;

    public bool Contains(T x) => set.ContainsKey(x.GetHashCode());

    public CustomSet<T> Insert(T x)
    {
        set[x.GetHashCode()] = x;
        return this;
    }

    public void Remove(T x) => set.Remove(x.GetHashCode());

    public override bool Equals(object obj) => Equals(obj as CustomSet<T>);
    public bool Equals(CustomSet<T> other) => Length.Equals(other?.Length) && Union(other).Length == Length;

    public override int GetHashCode() => base.GetHashCode();

    IEnumerator<T> IEnumerable<T>.GetEnumerator() => set.Values.GetEnumerator();

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => set.Values.GetEnumerator();

    public CustomSet<T> Union(CustomSet<T> other)
    {
        var result = new CustomSet<T>(this);
        foreach (var v in other) result.Insert(v);
        return result;
    }

    public bool IsSubsetOf(CustomSet<T> other)
    {
        foreach (var v in this)
            if (!other.Contains(v)) return false;
        return true;
    }

    public bool IsDisjointFrom(CustomSet<T> other)
    {
        foreach (var v in this)
            if (other.Contains(v)) return false;
        return true;
    }

    public CustomSet<T> Intersection(CustomSet<T> other)
    {
        var result = new CustomSet<T>();
        foreach (var v in this)
            if (other.Contains(v)) result.Insert(v);
        return result;
    }

    public CustomSet<T> Difference(CustomSet<T> other)
    {
        var result = new CustomSet<T>(this);
        foreach (var v in this)
            if (other.Contains(v)) result.Remove(v);
        return result;
    }
}
