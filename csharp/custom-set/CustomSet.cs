using System.Collections.Generic;

public class CustomSet<T> : IEnumerable<T>
{
	private int length { get { return set.Count; } }
	private Dictionary<int, T> set;

	public CustomSet() { this.set = new Dictionary<int, T>(); }

	public CustomSet(T x) : this() { this.Insert(x); }

	public CustomSet(IEnumerable<T> xs)
		: this()
	{
		foreach (var x in xs) this.Insert(x);
	}

	public bool IsEmpty() { return length == 0; }

	public bool Contains(T x) { return set.ContainsKey(x.GetHashCode()); }

	public CustomSet<T> Insert(T x)
	{
		set[x.GetHashCode()] = x;
		return this;
	}

	public override bool Equals(object obj)
	{
		var other = obj as CustomSet<T>;
		if (other == null) return false;
		return this.Union(other).length == this.length;
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	IEnumerator<T> IEnumerable<T>.GetEnumerator()
	{
		return set.Values.GetEnumerator();
	}

	System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
	{
		return set.Values.GetEnumerator();
	}

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
			if (other.Contains(v)) result.set.Remove(v.GetHashCode());
		return result;
	}
}
