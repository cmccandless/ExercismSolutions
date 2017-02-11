using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class BinarySearchTree
{
	public int Value { get; set; }
	private BinarySearchTree[] children = new BinarySearchTree[2];
	public BinarySearchTree Left
	{
		get
		{
			return children[0];
		}
		set
		{
			children[0] = value;
		}
	}
	public BinarySearchTree Right
	{
		get
		{
			return children[1];
		}
		set
		{
			children[1] = value;
		}
	}

	public IEnumerable<int> AsEnumerable()
	{
		//return children.Where(c => c != null).SelectMany(c => c.AsEnumerable()).Concat(new[] { Value });
		var result = new[] { Value }.AsEnumerable();
		if (Left != null) result = Left.AsEnumerable().Concat(result);
		if (Right != null) result = result.Concat(Right.AsEnumerable());
		return result;
	}

	public BinarySearchTree(params int[] values)
	{
		Value = values[0];
		if (values.Length == 1) return;
		var vals = values.Skip(1);
		foreach (var v in vals) Add(v);
	}

	public BinarySearchTree Add(int x)
	{
		var index = x <= Value ? 0 : 1;
		if (children[index] == null) children[index] = new BinarySearchTree(x);
		else children[index].Add(x);

		return this;
	}
}
