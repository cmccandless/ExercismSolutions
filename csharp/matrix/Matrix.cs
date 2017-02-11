using System.Linq;

class Matrix
{
	private int[][] Table;
	public int Rows { get { return Table.Length; } }
	public int Cols { get { return Table[0].Length; } }
	public Matrix(string input)
	{
		Table = (from row in input.Split('\n')
				 select (from x in row.Split(' ')
						 select int.Parse(x)).ToArray()).ToArray();
	}
	public int[] Row(int index) { return Table[index]; }
	public int[] Col(int index)
	{
		return (from row in Table
				select row[index]).ToArray();
	}
}
