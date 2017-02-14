using System;
using System.Collections.Generic;
using System.Linq;

public enum Bucket { One, Two }
public class TwoBuckets
{
	private readonly int[] sizes;
	private readonly Bucket startBucket;
	private Bucket otherBucket { get { return (Bucket)(1 - (int)startBucket); } }
	public TwoBuckets(int sizeOne, int sizeTwo, Bucket startBucket)
	{
		sizes = new[] { sizeOne, sizeTwo };
		this.startBucket = startBucket;
	}
	public Move Solve(int goal)
	{
		var move = new Move(null, startBucket, new[] { startBucket == Bucket.One ? sizes[0] : 0, startBucket == Bucket.Two ? sizes[1] : 0 }, sizes, goal, Move.Type.FillG);
		var q = new Queue<Move>(new[] { move });

		while (q.Any() && !move.Success)
		{
			move.GenerateNext();
			foreach (var n in move.Next) q.Enqueue(n);
			move = q.Dequeue();
		}

		return move;
	}
}
public class Move
{
	public readonly Move Parent;
	public enum Type { FillG, FillO, EmptyO, PourGO, PourOG }
	public Type MoveType;
	public int Moves;
	public int Goal;
	public bool Success => contents[(int)GoalBucket] == Goal; 
	public Bucket GoalBucket;
	private int[] contents;
	private int[] size;
	public int OtherBucketContents => contents[1 - (int)GoalBucket];
	public Move[] Next = new Move[0];
	public Move(Move parent, Bucket startBucket, int[] contents, int[] size, int goal, Type type, int moves = 1)
	{
		Parent = parent;
		Moves = moves;
		MoveType = type;
		Goal = goal;
		GoalBucket = startBucket;
		this.contents = contents;
		this.size = size;
	}
	public void GenerateNext()
	{
		Next = (from type in Enum.GetValues(typeof(Type)).Cast<Type>()
				where Condition(type)
				select new Move(this, GoalBucket, Perform(type), size, Goal, type, Moves + 1)).ToArray();
	}
	private bool Condition(Type type)
	{
		var g = (int)GoalBucket;
		var o = 1 - g;
		switch (type)
		{
			case Type.PourOG: return this.contents[o] > 0 && this.contents[g] < size[g];
			case Type.FillG: return this.contents[g] < size[g];
			case Type.PourGO: return this.contents[o] < size[o] && this.contents[g] + this.contents[o] != size[o];
			case Type.FillO: return this.contents[o] < size[o];
			case Type.EmptyO: return this.contents[o] > 0;
			default: return false;
		}
	}
	private int[] Perform(Type type)
	{
		var contents = this.contents.ToArray();
		var g = (int)GoalBucket;
		var o = 1 - g;
		switch (type)
		{
			case Type.FillG: contents[g] = size[g]; break;
			case Type.FillO: contents[o] = size[o]; break;
			case Type.EmptyO: contents[o] = 0; break;
			case Type.PourOG:
				var t = o;
				o = g;
				g = t;
				goto case Type.PourGO;
			case Type.PourGO:
				var cs = Math.Max(0, contents[g] - size[o] + contents[o]);
				var co = Math.Min(size[o], contents[g] + contents[o]);
				contents[g] = cs;
				contents[o] = co;
				break;
		}
		return contents;
	}
	public override string ToString() =>
        $"{MoveType}: {contents[0]}/{size[0]},{contents[1]}/{size[1]}";

	public string MoveString()
	{
		return (Parent == null ?
			string.Format("GOAL {0}/{1},{2}/{3} -\n",
			GoalBucket == Bucket.One ? Goal.ToString() : "?", size[0], 
			GoalBucket == Bucket.Two ? Goal.ToString() : "?", size[1]) :
			Parent.MoveString()) + "\n" + ToString();
	}
}
