using System;
using System.Collections.Generic;

public class BracketPush
    {
        private static Dictionary<char, char> open = new Dictionary<char, char>
        { ['['] = ']', ['('] = ')', ['{'] = '}', };
        private static HashSet<char> close = new HashSet<char>{']','}',')'};
        public static bool IsPaired(string input)
        {
            var sInput = new Queue<char>(input);
            var sClose = new Stack<char>();
            while (sInput.Count > 0)
            {
                var x = sInput.Dequeue();
                if (open.ContainsKey(x)) sClose.Push(open[x]);
                else if (close.Contains(x))
                {
                    if (sClose.Count > 0 && sClose.Peek() == x) sClose.Pop();
                    else return false;
                }
            }
            return sClose.Count == 0;
        }
    }
