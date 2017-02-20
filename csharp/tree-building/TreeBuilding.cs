using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercism.tree_building
{
    public class TreeBuildingRecord
    {
        public int ParentId { get; set; }
        public int RecordId { get; set; }
    }

    public class Tree
    {
        public int Id { get; set; }
        public int ParentId { get; set; }

        public List<Tree> Children { get; set; } = new List<Tree>();

        public bool IsLeaf => Children.Count == 0;

        public override string ToString() => $"({ParentId}){Id}({string.Join(",", Children)})";
    }

    public static class TreeBuilder
    {
        private static T Except<T>(this T o, Func<T, bool> lambda, string msg = "")
        {
            if (lambda(o)) throw new Exception(msg);
            return o;
        }

        private static HashSet<int> GetIds(this IEnumerable<TreeBuildingRecord> records) =>
            new HashSet<int>(records.Select(r => r.RecordId));

        private static IEnumerable<TreeBuildingRecord>
            ValidateRecords(this IEnumerable<TreeBuildingRecord> records) =>
            new List<TreeBuildingRecord>(records).ValidateRecords(records.GetIds());

        private static IEnumerable<TreeBuildingRecord>
            ValidateRecords(this List<TreeBuildingRecord> records, HashSet<int> ids) =>
            records.Select(rec => rec.RecordId == 0 ?
                    rec.Except(r => r.ParentId != 0, "Root cannot have parent.") :
                    rec.Except(r => r.RecordId < r.ParentId, "Parent ID higher than node ID.")
                        .Except(r => r.RecordId == r.ParentId, "Direct cycle.")
                        .Except(r => !ids.Contains(r.RecordId - 1), "Non-continuous."));

        private static Tree FromRecord(TreeBuildingRecord record) =>
            new Tree { ParentId = record.ParentId, Id = record.RecordId };

        private static Tree AssignChildren(this IEnumerable<Tree> trees) =>
            trees.Select(tree =>
            {
                var childs = trees.Where(t => t.ParentId == tree.Id && t.Id != tree.Id);
                tree.Children.AddRange(childs.OrderBy(c => c.Id));
                return tree;
            }).ToList().First(t => t.Id == 0);

        private static int Count(this Tree tree) => 1 + tree.Children.Sum(c => c.Count());

        public static Tree BuildTree(IEnumerable<TreeBuildingRecord> records) =>
            records.ValidateRecords()
            .Select(FromRecord).ToList()
            .AssignChildren()
            .Except(t => t.Count() != records.Count(), "Indirect cycle.");
    }
}