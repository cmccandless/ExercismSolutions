using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class SgfTree
{
	public readonly IDictionary<string, string[]> Data;
	public readonly SgfTree[] Children;

	public SgfTree(IDictionary<string, string[]> data, params SgfTree[] children)
	{
		Data = data;
		Children = children;
	}

	public override string ToString()
	{
		return "(;" + string.Join(";",
			Data.Keys.Select(key => key + string.Join(string.Empty,
				Data[key].Select(dat => '[' + dat + ']')))) +
				string.Join(string.Empty,
				Children.Select(child => '(' + child.ToString() + ')')) + ')';
	}
}
public static class SgfParser
{
	private static Dictionary<char, char> brackets = new Dictionary<char, char>
	{
		{'(',')'},
		{'[',']'},
	};
	private enum State { Root, Node, Child, Property, Value }
	public static SgfTree ParseTree(string data)
	{
		if (data.Equals(string.Empty)) throw new ArgumentException();
		var q = new Queue<char>(data);
		var state = new Stack<State>();
		state.Push(State.Root);
		var str = string.Empty;
		string key = null;
		var values = new List<string>();
		var dict = new Dictionary<string, string[]>();
		var children = new List<SgfTree>();
		var end = new Stack<char>();
		var escaped = false;
		while (q.Any())
		{
			var c = q.Peek();
			if (!escaped)
			{
				if (brackets.ContainsKey(c)) end.Push(brackets[c]);
				else if (!end.Any()) throw new ArgumentException();
				else if (c == end.Peek()) end.Pop();
			}
			switch (state.Peek())
			{
				case State.Root:
					if (c != '(') throw new Exception();
					state.Pop();
					state.Push(State.Node);
					break;
				case State.Node:
					if (c == '(')
					{
						state.Push(State.Child);
						end.Pop();
						continue;
					}
					else if (c == ';') state.Push(State.Property);
					else if (children.Count == 0) throw new ArgumentException();
					break;
				case State.Child:
					var s = c.ToString();
					q.Dequeue();
					var endOnParens = c == '(';
					while (q.Any())
					{
						c = q.Peek();
						if (brackets.ContainsKey(c)) end.Push(brackets[c]);
						else if (end.Any() && c == end.Peek()) end.Pop();
						if ((endOnParens && end.Count == 1) ||
							(!endOnParens && q.Count == 1))
						{
							if (endOnParens)
							{
								if (!s.StartsWith("(")) throw new ArgumentException();
								s += c;
							}
							else s = "(" + s + ")";
							children.Add(ParseTree(s));
							state.Pop();
							break;
						}
						s += c;
						q.Dequeue();
					}
					break;
				case State.Property:
					if (c == '[')
					{
						if (values.Count == 0)
						{
							key = str;
							str = string.Empty;
						}
						state.Push(State.Value);
					}
					else if (";(".Contains(c))
					{
						if (key != null && !key.Equals(string.Empty))
						{
							dict[key] = values.ToArray();
							values.Clear();
							key = string.Empty;
						}
						state.Pop();
						state.Push(State.Child);
						if (c == '(') end.Pop();
						continue;
					}
					else if (char.IsUpper(c)) str += c;
					else
					{
						if (key != null && !key.Equals(string.Empty))
						{
							dict[key] = values.ToArray();
							values.Clear();
							key = string.Empty;
						}
						state.Pop();
					}
					break;
				case State.Value:
					if (!escaped && c == ']')
					{
						values.Add(str);
						str = string.Empty;
						state.Pop();
					}
					else if (escaped)
					{
						switch(c)
						{
							case 'n':
							case 't':
								str += ' ';
								break;
							default:
								str += c;
								break;
						}
					}
					else if (c != '\\') str += c;
					break;
			}
			escaped = c == '\\';
			q.Dequeue();
		}
		return new SgfTree(dict, children.ToArray());
	}
}