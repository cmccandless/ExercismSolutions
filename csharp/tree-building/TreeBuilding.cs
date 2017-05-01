using System;
using System.Collections.Generic;
using System.Linq;
using RecordCollection = System.Collections.Generic.IEnumerable<TreeBuildingRecord>;

public class TreeBuildingRecord
{
    public int ParentId, RecordId;

    public bool IsRoot => RecordId == 0;

    public TreeBuildingRecord Validate(HashSet<int> ids) =>
        IsRoot ? ValidateRootRecord() : ValidateNonRootRecord(ids);

    private TreeBuildingRecord ValidateRootRecord() =>
        this.Assert(r => r.ParentId == 0, "Root cannot have parent.");

    private TreeBuildingRecord ValidateNonRootRecord(HashSet<int> ids) =>
        this.Assert(r => r.RecordId != r.ParentId, "Direct cycle.")
            .Assert(r => r.RecordId > r.ParentId, "Parent ID higher than node ID.")
            .Assert(r => ids.Contains(r.RecordId - 1), "Non-continuous.");
}

public class Tree
{
    public int Id, ParentId;

    public static Tree FromRecord(TreeBuildingRecord record) =>
        new Tree { Id = record.RecordId, ParentId = record.ParentId, };

    public List<Tree> Children { get; set; } = new List<Tree>();

    public bool IsLeaf => Children.Count == 0;

    public int Count => 1 + Children.Sum(c => c.Count);

    public bool IsParentOf(Tree t) => t.ParentId == Id && t.Id != Id;
}

public static class TreeBuilder
{
    public static T Assert<T>(this T o, Func<T, bool> lambda, string msg = "")
    {
        if (lambda(o)) return o;
        throw new ArgumentException(msg);
    }

    private static HashSet<int> GetIds(this RecordCollection records) =>
        new HashSet<int>(records.Select(r => r.RecordId));

    private static RecordCollection ValidateRecords(this RecordCollection records, HashSet<int> ids) =>
        records.Select(r => r.Validate(ids));

    private static Tree AssignTo(this List<Tree> trees, Tree tree)
    {
        tree.Children.AddRange(trees.Where(tree.IsParentOf).OrderBy(t => t.Id));
        return tree;
    }

    private static Tree AssignChildren(this List<Tree> trees) =>
        trees.Select(trees.AssignTo).First(t => t.Id == 0);

    public static Tree BuildTree(this RecordCollection records) =>
        records.Assert(r => r.Any(), "Empty input collection.")
        .ValidateRecords(records.GetIds())
        .Select(Tree.FromRecord).ToList()
        .AssignChildren()
        .Assert(t => t.Count == records.Count(), "Indirect cycle.");
}
