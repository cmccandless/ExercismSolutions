using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class BowlingGame
{
	private List<Frame> Frames = new List<Frame> { new Frame(1) };
	public void Roll(int pins)
	{
		if (pins < 0) pins -= 300;
		var f = Frames.Last().Roll(pins);
		if (f.Number > Frames.Count) Frames.Add(f);
	}
	public int? Score()
	{
		if (Frames.Count < 10) return null;
		var f = Frames[9];
		if (f.IsSpare || f.IsStrike)
		{
			if (Frames.Count < 11 || 
				(f.IsStrike && Frames[10].IsStrike && Frames.Count < 12)) 
				return null;
		}
		else if (Frames.Count > 10) return null;
		return Frames.First().Sum();
	}
	private class Frame
	{
		public bool IsStrike { get { return Ball1.Value == 10; } }
		public bool IsSpare
		{
			get
			{
				return !IsStrike && Ball1.Value +
					(Ball2.HasValue ? Ball2.Value : 0) == 10;
			}
		}
		public int? Ball1 = null;
		public int? Ball2 = null;
		public Frame Next = null;
		public int Number;
		public Frame(int number) { this.Number = number; }
		public int? Value
		{
			get
			{
				var val = Ball1 + (Ball2.HasValue ? Ball2.Value : 0);
				if (val > 10 || val < 0) return null;
				if (Next != null && Number < 10)
				{
					if (IsStrike || IsSpare)
						val += Next.Ball1;
					if (IsStrike)
					{
						if (!Next.IsStrike) val += (Next.Ball2.HasValue ? Next.Ball2.Value : 0);
						else if (Next.Next != null) val += Next.Next.Ball1.Value;
					}
				}
				return val;
			}
		}
		public Frame Roll(int pins)
		{
			if (Ball1 == null)
			{
				Ball1 = pins;
				if (pins == 10) Ball2 = 0;
				return this;
			}
			if (Ball2 == null)
			{
				Ball2 = pins;
				return this;
			}
			if (Next == null) Next = new Frame(Number + 1);
			return Next.Roll(pins);
		}
		public int? Sum()
		{
			return Value + (Next == null ? 0 : Next.Sum());
		}
		public override string ToString()
		{
			return string.Format("{0}:{1}({2},{3}{4}{5})",
				Number, Value, Ball1, Ball2,
				IsStrike ? ",Strike" : string.Empty,
				IsSpare ? ",Spare" : string.Empty);
		}
	}
}
