using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercism.zipper
{
	class Zipper<T>
	{
		public T Value { get { return pointer == null ? default(T) : pointer.Value; } }
		private BinTree<T> pointer;
		private Zipper(BinTree<T> tree)
		{
			pointer = tree;
		}
		public static Zipper<T> FromTree(BinTree<T> tree)
		{
			return new Zipper<T>(tree);
		}
		public Zipper<T> Up()
		{
			return pointer.Parent == null ? null : new Zipper<T>(pointer.Parent);
		}
		public Zipper<T> Right() 
		{
			return pointer.Right == null ? null : new Zipper<T>(pointer.Right);
		}
		public Zipper<T> Left()
		{
			return pointer.Left == null ? null : new Zipper<T>(pointer.Left);
		}
		public Zipper<T> SetValue(T v)
		{
			pointer.Value = v;
			return this;
		}
		public Zipper<T> SetRight(BinTree<T> tree)
		{
			pointer.Right = tree;
			return this;
		}
		public Zipper<T> SetLeft(BinTree<T> tree)
		{
			pointer.Left = tree;
			return this;
		}
		public BinTree<T> ToTree()
		{
			return pointer.Parent == null ? new BinTree<T>(pointer) : this.Up().ToTree();
		}
	}
	class BinTree<T>
	{
		public T Value;
		public BinTree<T> Parent;
		private BinTree<T> left;
		public BinTree<T> Left
		{
			get { return left; }
			set
			{
				if (left != null) left.Parent = null;
				left = value;
				if (left != null) left.Parent = this;
			}
		}
		private BinTree<T> right;
		public BinTree<T> Right
		{
			get { return right; }
			set
			{
				if (right != null) right.Parent = null;
				right = value;
				if (right != null) right.Parent = this;
			}
		}
		public BinTree(T v, BinTree<T> left, BinTree<T> right)
		{
			this.Value = v;
			this.Left = left;
			this.Right = right;
			this.Parent = null;
		}
		public BinTree(BinTree<T> tree, int direction = 0)
		{
			this.Value = tree.Value;
			if (direction >= 0)
			{
				if (tree.left != null) this.left = new BinTree<T>(tree.left,1);
				if (tree.right != null) this.right = new BinTree<T>(tree.right,1);
			}
			else
			{
				this.left = tree.left;
				this.right = tree.right;
			}
			if (direction <= 0) 
			{
				if (tree.Parent != null) this.Parent = new BinTree<T>(tree.Parent, -1);
			}
			else this.Parent = tree.Parent;
		}
		public override string ToString()
		{
			var result = Value.ToString();
			var leftNull = Left != null;
			var rightNull = Right != null;
			if (leftNull || rightNull) result += ':';
			if (leftNull) result += " L(" + Left.ToString() + ")";
			if (rightNull) result += " R(" + Right.ToString() + ")";
			return result;
		}
		public override bool Equals(object obj)
		{
			var other = obj as BinTree<T>;
			if (other == null) return false;
			if (!this.Value.Equals(other.Value)) return false;
			if (this.Left == null && other.Left != null) return false;
			if (this.Left != null && !this.Left.Equals(other.Left)) return false;
			if (this.Right == null && other.Right != null) return false;
			if (this.Right != null && !this.Right.Equals(other.Right)) return false;
			return true;
		}
		public override int GetHashCode()
		{
			return this.ToString().GetHashCode();
		}
	}
}
