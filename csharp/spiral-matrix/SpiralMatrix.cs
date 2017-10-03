using System;
using System.Linq;

public class SpiralMatrix
{
    public static int[,] GetMatrix(int size)
    {
        var m = new int[size, size];
        (int x, int y) dir = (1, 0), pos = (0, 0);
        (int x, int y) rotate((int x, int y) d) => d.x == 0 ? (-d.y, 0) : (0, d.x);
        (int x, int y) step((int x, int y) p, (int x, int y) d) => (x: p.x + d.x, y: p.y + d.y);
        for (int count = 1; count <= size * size; count++)
        {
            m[pos.y, pos.x] = count;
            var p2 = step(pos, dir);
            try
            {
                if (m[p2.y, p2.x] != 0) throw new IndexOutOfRangeException();
                pos = p2;
            }
            catch (IndexOutOfRangeException)
            {
                dir = rotate(dir);
                pos = step(pos, dir);
            }
        }
        return m;
    }
}
