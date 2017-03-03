using System.Collections.Generic;
using System.Linq;

namespace Exercism.bracket_push
{
    public class BracketPush
    {
        private static Dictionary<char, char> open = new Dictionary<char, char>
        {
            ['['] = ']',
            ['('] = ')',
            ['{'] = '}',
        };
        public static bool Matched(string input)
        {
            var sInput = new Stack<char>(input.ToCharArray().Reverse());
            var sClose = new Stack<char>();
            while (sInput.Count > 0)
            {
                var x = sInput.Pop();
                if (open.ContainsKey(x)) sClose.Push(open[x]);
                else if (sClose.Count > 0 && sClose.Peek() == x) sClose.Pop();
            }
            return sClose.Count == 0;
        }
    }
}