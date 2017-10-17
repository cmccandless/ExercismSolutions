using System;
using System.Collections.Generic;
using System.Linq;

public static class Wordy
{
    private static int DequeueInt(this Queue<string> q) =>
            int.Parse(q.Dequeue().Replace("?", ""));

        public static int Answer(string question)
        {
            var result = 0;
            var q = new Queue<string>(question.Split(' '));
            while (q.Any())
            {
                var x = q.Dequeue();
                switch (x)
                {
                    case "What": break;
                    case "is": result = q.DequeueInt(); break;
                    case "plus": result += q.DequeueInt(); break;
                    case "minus": result -= q.DequeueInt(); break;
                    case "multiplied": q.Dequeue(); result *= q.DequeueInt(); break;
                    case "divided": q.Dequeue(); result /= q.DequeueInt(); break;
                    default: throw new ArgumentException();
                }
            }
            return result;
        }
}