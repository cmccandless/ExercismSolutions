using System.Linq;

class Matrix
{
    private int[][] Table;
    public int Rows => Table.Length;
    public int Cols => Table[0].Length;
    public Matrix(string input)
    {
        Table = (from row in input.Split('\n')
                 select (from x in row.Split(' ')
                         select int.Parse(x)).ToArray()).ToArray();
    }
    public int[] Row(int index) => Table[index];
    public int[] Col(int index) => (from row in Table
                                    select row[index]).ToArray();
}
