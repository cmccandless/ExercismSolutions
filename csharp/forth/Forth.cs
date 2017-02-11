using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercism.forth
{
	public enum ForthError { DivisionByZero, StackUnderflow, InvalidWord, UnknownWord }
	class ForthException : Exception
	{
		public ForthError Error;
		public ForthException(ForthError error) { this.Error = error; }
	}
	static class Forth
	{
		private static bool IsNumber(string s)
		{
			if (s.StartsWith("-")) s = s.Substring(1);
			if (s.Equals(string.Empty)) return false;
			foreach (var c in s)
				if (!char.IsDigit(c)) return false;
			return true;
		}
		private static HashSet<char> nonSeparators = new HashSet<char>("+-*/:;");
		private static char[] separators = (from i in Enumerable.Range(0, 128)
										  let c = (char)i
										  where !nonSeparators.Contains(c) && !char.IsLetterOrDigit(c)
										  select c).ToArray();
		public static string Eval(string expr)
		{
			if (expr.Equals(string.Empty)) return expr;
			var inputStack = new Stack<string>(expr.ToUpper().Split(separators).Reverse());
			var s = new Stack<int>();
			var defines = new Dictionary<string, string[]>();
			while (inputStack.Any())
			{
				var x = inputStack.Pop();
				if (IsNumber(x)) { s.Push(int.Parse(x)); continue; }
				if (defines.ContainsKey(x))
				{
					foreach (var w in defines[x].Reverse()) inputStack.Push(w);
					continue;
				}
				try
				{
					switch (x)
					{
						case "+": s.Push(s.Pop() + s.Pop()); break;
						case "-": s.Push(-s.Pop() + s.Pop()); break;
						case "*": s.Push(s.Pop() * s.Pop()); break;
						case "/":
							if (s.Peek() == 0) throw new ForthException(ForthError.DivisionByZero);
							s.Push((int)((1 / (double)s.Pop()) * s.Pop()));
							break;
						case "DUP": s.Push(s.Peek()); break;
						case "DROP": s.Pop(); break;
						case "SWAP":
							foreach (var t in new[] { s.Pop(), s.Pop() }) s.Push(t);
							break;
						case "OVER":
							foreach (var t in new[] { s.Pop(), s.Peek() }) s.Push(t);
							break;
						case ":":
							var key = inputStack.Pop();
							if (IsNumber(key)) throw new ForthException(ForthError.InvalidWord);
							var values = new List<string>();
							x = inputStack.Pop();
							while (!x.Equals(";"))
							{
								values.Add(x);
								x = inputStack.Pop();
							}
							defines[key] = values.ToArray();
							break;
						default: throw new ForthException(ForthError.UnknownWord);
					}
				}
				catch (InvalidOperationException)
				{
					throw new ForthException(ForthError.StackUnderflow);
				}
			}
			return string.Join(" ", s.Reverse());
		}
	}
}
