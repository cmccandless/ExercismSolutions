using System.Collections.Generic;
using System.Linq;

namespace Exercism.binary_search_tree
{
    class BinarySearchTree
    {
        public int Value { get; }
        public BinarySearchTree Parent { get; set; } = null;
        private BinarySearchTree[] children = new BinarySearchTree[2];
        public BinarySearchTree Left
        {
            get { return children[0]; }
            set { children[0] = value; }
        }
        public BinarySearchTree Right
        {
            get { return children[1]; }
            set { children[1] = value; }
        }

        public IEnumerable<int> AsEnumerable()
        {
            IEnumerable<int> result = new[] { Value };
            if (Left != null) result = Left.AsEnumerable().Concat(result);
            if (Right != null) result = result.Concat(Right.AsEnumerable());
            return result;
        }
        
        public BinarySearchTree(params int[] values)
        {
            Value = values[0];
            foreach (var v in values.Skip(1)) Add(v);
        }

        public BinarySearchTree Add(int x)
        {
            var index = x <= Value ? 0 : 1;
            if (children[index] == null) children[index] = new BinarySearchTree(x) { Parent = this };
            else children[index].Add(x);
            return this;
        }
    }
}