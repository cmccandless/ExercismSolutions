using System.Collections.Generic;
using System.Linq;

public class BowlingGame
{
    private List<Frame> Frames = new List<Frame> { new Frame(1) };
    public void Roll(int pins)
    {
        if (pins < 0) pins -= 300;
        var f = Frames.Last().Roll(pins);
        if (f.Number > Frames.Count) Frames.Add(f);
    }
    private bool HasMinFrames => Frames.Count >= 10;
    private bool CheckSpare => Frames[9].IsSpare && Frames.Count == 11;
    private bool CheckStrike => Frames[9].IsStrike && !(Frames[9].Next?.IsStrike ?? true) || Frames.Count == 12;
    private bool CheckNormal => Frames[9].IsNormal && Frames.Count == 10;
    public int? Score() => HasMinFrames && (CheckSpare || CheckStrike || CheckNormal) ? Frames.First().Sum() : null;
    private class Frame
    {
        public bool IsStrike => Ball1 == 10;
        public bool IsSpare => !IsStrike && Ball1 + (Ball2 ?? 0) == 10;
        public bool IsNormal => !IsSpare && !IsStrike;
        public int? Ball1 = null;
        public int? Ball2 = null;
        public Frame Next = null;
        public int Number;
        public Frame(int number) { Number = number; }
        private int? _value => Ball1 + (Ball2 ?? 0);
        private bool InvalidTotal => _value > 10 || _value < 0;
        private bool ValidNormal => IsNormal || Next == null || Number >= 10;
        private int? _extendedValue => _value + Next.Ball1 + (IsSpare ? 0 : Next.IsStrike ? Next.Next.Ball1 ?? 0 : Next.Ball2);
        public int? Value => InvalidTotal ? null : ValidNormal ? _value : _extendedValue;
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
        public int? Sum() => Value + (Next == null ? 0 : Next.Sum());
        private string SpecialStr => IsStrike ? ",Strike" : IsSpare ? ",Spare" : string.Empty;
        public override string ToString() => $"{Number}:{Value}({Ball1},{Ball2}{SpecialStr})";
    }
}
