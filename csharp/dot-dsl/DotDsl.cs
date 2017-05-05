using System.Collections.Generic;

public class Graph : AttrCollection, IEnumerable<Node>
{
    public List<Node> Nodes = new List<Node>();
    public List<Edge> Edges = new List<Edge>();

    public new IEnumerator<Node> GetEnumerator() => Nodes.GetEnumerator();

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => Nodes.GetEnumerator();

    public void Add(Node node) => Nodes.Add(node);

    public void Add(Edge edge) => Edges.Add(edge);

    public override bool Equals(object obj) => GetHashCode().Equals(obj?.GetHashCode());

    public override int GetHashCode()
    {
        unchecked
        {
            var hash = (int)2166136261;
            var m = 16777619;
            hash = (hash * m) ^ base.GetHashCode();
            foreach (var n in Nodes) hash = (hash * m) ^ n.GetHashCode();
            foreach (var e in Edges) hash = (hash * m) ^ e.GetHashCode();
            return hash;
        }
    }
}

public class AttrCollection : IEnumerable<Attr>
{
    public List<Attr> Attrs = new List<Attr>();

    protected AttrCollection() { }

    public void Add(string attrName, string attrValue) => Attrs.Add(new Attr(attrName, attrValue));

    public IEnumerator<Attr> GetEnumerator() => Attrs.GetEnumerator();

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => Attrs.GetEnumerator();

    public override int GetHashCode()
    {
        unchecked
        {
            var hash = (int)2166136261;
            var m = 16777619;
            foreach (var a in Attrs) hash = (hash * m) ^ a.GetHashCode();
            return hash;
        }
    }

    public override bool Equals(object obj) => GetHashCode().Equals(obj?.GetHashCode());

    public override string ToString() => $"{{{string.Join(", ", Attrs)}}}";
}

public class Node : AttrCollection
{
    public readonly string Label;

    public Node(string label)
    {
        Label = label;
    }

    public override bool Equals(object obj) => Equals(obj as Node);

    public bool Equals(Node other) => base.Equals(other) && Label.Equals(other?.Label);

    public override int GetHashCode()
    {
        unchecked
        {
            var hash = (int)2166136261;
            var m = 16777619;
            hash = (hash * m) ^ base.GetHashCode();
            hash = (hash * m) ^ Label.GetHashCode();
            return hash;
        }
    }

    public override string ToString() => $@"{Label} {base.ToString()}";
}

public class Edge : AttrCollection
{
    public readonly string Start, End;

    public Edge(string start, string end)
    {
        Start = start;
        End = end;
    }

    public override bool Equals(object obj) => GetHashCode().Equals(obj?.GetHashCode());

    public override int GetHashCode()
    {
        unchecked
        {
            var hash = (int)2166136261;
            var m = 16777619;
            hash = (hash * m) ^ base.GetHashCode();
            hash = (hash * m) ^ Start.GetHashCode();
            hash = (hash * m) ^ End.GetHashCode();
            return hash;
        }
    }

    public override string ToString() => $@"({Start} : {End}) {base.ToString()}";
}

public class Attr
{
    public readonly string Name;
    public string Value;

    public Attr(string name, string value)
    {
        Name = name;
        Value = value;
    }

    public override bool Equals(object obj) => GetHashCode().Equals(obj?.GetHashCode());

    public override int GetHashCode()
    {
        unchecked
        {
            var hash = (int)2166136261;
            var m = 16777619;
            hash = (hash * m) ^ Name.GetHashCode();
            hash = (hash * m) ^ Value.GetHashCode();
            return hash;
        }
    }

    public override string ToString() => $"{Name} = {Value}";
}