using System;
using System.Collections.Generic;
using System.Linq;

public class TreeBuildingRecord
{
	public int ParentId { get; set; }
	public int RecordId { get; set; }
}

public class Tree
{
	public int Id { get; set; }
	public int ParentId { get; set; }

	public List<Tree> Children { get; set; }

	public bool IsLeaf { get { return Children.Count == 0; } }
}

public static class TreeBuilder
{
	public static Tree BuildTree(IEnumerable<TreeBuildingRecord> records)
	{
		var treesById = (from record in records
							 orderby record.RecordId
							 select new Tree { Children = new List<Tree>(), Id = record.RecordId, ParentId = record.ParentId}).ToArray();
		var root = treesById.First();

		// Check for no root or root has parent
		if (root.Id != 0 || root.ParentId != 0) throw new Exception();

		var treesByParent = new Queue<Tree>(treesById.OrderBy(t=>t.ParentId));
		for (int i = 0; i < treesById.Length;i++)
		{
			var tree = treesById[i];

			// Check for parent id higher than id or non-continuous
			if (tree.ParentId > tree.Id || tree.Id != i) throw new Exception();

			while (treesByParent.Any() && treesByParent.First().ParentId.Equals(tree.Id))
			{
				var t = treesByParent.Dequeue();

				// Check for direct cycle
				if (i > 0 && t.Id == tree.Id) throw new Exception();

				if (t.Id != tree.Id) tree.Children.Add(t);
			}
		}

		// Check for indirect cycle
		foreach (var tree in treesById)
		{
			var q = new Queue<Tree>(tree.Children);
			while (q.Any())
			{
				var t = q.Dequeue();
				if (tree.ParentId.Equals(t.Id)) throw new Exception();
				foreach (var c in t.Children) q.Enqueue(c);
			}
		}
		return root;
	}
}