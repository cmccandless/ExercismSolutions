using System;
using System.Collections.Generic;
using System.Linq;

public enum ConnectWinner { None, Black, White }
public class Connect
{
    private readonly char[][] board;
    private static char[] CreateRow(string line) =>
        line.Replace(" ", "").ToCharArray();
    public Connect(string[] board) =>
        this.board = board.Select(CreateRow).ToArray();
    public ConnectWinner Result()
    {
        var visited = new HashSet<(int, int)>();
        var s = new Stack<(int, int, char)>();
        for (int y = 0; y < board.Length; y++) s.Push((0, y, 'X'));
        for (int x = 0; x < board[0].Length; x++) s.Push((x, 0, 'O'));
        while (s.Any())
        {
            var (x, y, token) = s.Pop();
            try 
            { 
                if (board[y][x] != token || visited.Contains((x, y))) continue;
            }
            catch (IndexOutOfRangeException) 
            {
                continue;
            }
            switch (token)
            {
                case 'X':
                    if (x == board[y].Length - 1) return ConnectWinner.Black;
                    break;
                case 'O':
                    if (y == board.Length - 1) return ConnectWinner.White;
                    break;
            }
            visited.Add((x, y));
            for (int m = -1; m < 2; m++)
                for (int n = -1; n < 2; n++)
                {
                    if (m == n) continue;
                    s.Push((x + m, y + n, token));
                }
        }
        return ConnectWinner.None;
    }
}