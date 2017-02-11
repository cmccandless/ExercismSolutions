using System.Collections.Generic;
using System.Linq;

namespace Exercism.graph
{
	public class Graph : IEnumerable<Node>
	{
		public List<Node> Nodes = new List<Node>();
		public List<Edge> Edges = new List<Edge>();
		public List<Attr> Attrs = new List<Attr>();

		public IEnumerator<Node> GetEnumerator()
		{
			return Nodes.GetEnumerator();
		}
		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return Nodes.GetEnumerator();
		}
		public void Add(Node node)
		{
			Nodes.Add(node);
		}
		public void Add(Edge edge)
		{
			Edges.Add(edge);
		}
		public void Add(string attrName, string attrValue)
		{
			Attrs.Add(new Attr(attrName, attrValue));
		}
		public override bool Equals(object obj)
		{
			var other = obj as Graph;
			return other != null && other.Nodes.Union(Nodes).Equals(Nodes) &&
				other.Edges.Union(Edges).Equals(Edges) &&
				other.Attrs.Union(Attrs).Equals(Attrs);
		}
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
	}
	public class Node : IEnumerable<Attr>
	{
		public readonly string Label;
		public List<Attr> Attrs = new List<Attr>();
		public Node(string label)
		{
			Label = label;
		}
		public void Add(string attrName, string attrValue)
		{
			Attrs.Add(new Attr(attrName, attrValue));
		}
		public IEnumerator<Attr> GetEnumerator()
		{
			return Attrs.GetEnumerator();
		}
		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return Attrs.GetEnumerator();
		}
		public override bool Equals(object obj)
		{
			var other = obj as Node;
			return other != null && other.Label.Equals(Label) && other.Attrs.Union(Attrs).Equals(Attrs);
		}
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
	}
	public class Edge : IEnumerable<Attr>
	{
		public readonly string Start;
		public readonly string End;
		public List<Attr> Attrs = new List<Attr>();
		public Edge(string start, string end)
		{
			Start = start;
			End = end;
		}
		public override bool Equals(object obj)
		{
			var other = obj as Edge;
			return other != null && other.Start.Equals(Start) && other.End.Equals(End) && other.Attrs.Union(Attrs).Equals(Attrs);
		}
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
		public void Add(string attrName, string attrValue)
		{
			Attrs.Add(new Attr(attrName, attrValue));
		}
		public IEnumerator<Attr> GetEnumerator()
		{
			return Attrs.GetEnumerator();
		}
		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return Attrs.GetEnumerator();
		}
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
		public override bool Equals(object obj)
		{
			var other = obj as Attr;
			return other != null && other.Name.Equals(Name) && other.Value.Equals(Value);
		}
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
	}
}