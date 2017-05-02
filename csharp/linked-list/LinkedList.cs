
class Deque<T>
{
    private Node Head { get; set; }
    private Node Tail { get; set; }
    public T Pop()
    {
        var result = Tail.Value;
        if (Tail.Previous == null) Head = Tail = null;
        else
        {
            Tail = Tail.Previous;
            Tail.Next = null;
        }
        return result;
    }
    public void Push(T item)
    {
        var node = new Node(item) { Previous = Tail };
        if (Tail != null) Tail.Next = node;
        Tail = node;
        if (Head == null) Head = Tail;
    }
    public T Shift()
    {
        var result = Head.Value;
        if (Head.Next == null) Tail = Head = null;
        else
        {
            Head = Head.Next;
            Head.Previous = null;
        }
        return result;
    }
    public void Unshift(T item)
    {
        var node = new Node(item) { Next = Head };
        if (Head != null) Head.Previous = node;
        Head = node;
        if (Tail == null) Tail = Head;
    }
    private class Node
    {
        public T Value { get; private set; }
        public Node Next { get; set; }
        public Node Previous { get; set; }
        public Node(T value)
        {
            Value = value;
        }
    }
}
