using System.Collections.Generic;

public class BracketPush
    {
        private static Dictionary<char, char> open = new Dictionary<char, char>
        { ['['] = ']', ['('] = ')', ['{'] = '}', };
        public static bool Matched(string input)
        {
            var sInput = new Queue<char>(input);
            var sClose = new Stack<char>();
            while (sInput.Count > 0)
            {
                var x = sInput.Dequeue();
                if (open.ContainsKey(x)) sClose.Push(open[x]);
                else if (sClose.Count > 0 && sClose.Peek() == x) sClose.Pop();
            }
            return sClose.Count == 0;
        }
    }
