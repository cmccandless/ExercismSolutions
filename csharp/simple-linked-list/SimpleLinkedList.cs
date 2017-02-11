using System.Collections.Generic;
using System.Linq;

class SimpleLinkedList<T> : IEnumerable<T>
{
	public T Value { get; set; }
	public SimpleLinkedList<T> Next { get; set; }
	public SimpleLinkedList(T value)
	{
		Value = value;
	}
	public SimpleLinkedList(IEnumerable<T> values)
		: this(values.First())
	{
		if (values.Skip(1).Any()) Next = new SimpleLinkedList<T>(values.Skip(1));
	}
	private SimpleLinkedList(T value, SimpleLinkedList<T> next)
		: this(value)
	{
		Next = next;
	}
	public IEnumerable<T> AsEnumerable()
	{
		return Next != null ? new[] { Value }.Concat(Next.AsEnumerable()) : new[] { Value };
	}
	public SimpleLinkedList<T> Add(T value)
	{
		var target = this;
		while (target.Next != null) target = target.Next;
		target.Next = new SimpleLinkedList<T>(value);

		return this;
	}
	public SimpleLinkedList<T> Reverse(SimpleLinkedList<T> previous = null)
	{
		var newThis = new SimpleLinkedList<T>(Value, previous);
		return Next == null ? newThis : Next.Reverse(newThis);
	}

	public IEnumerator<T> GetEnumerator()
	{
		return this.AsEnumerable().GetEnumerator();
	}

	System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
	{
		return this.AsEnumerable().GetEnumerator();
	}
}
