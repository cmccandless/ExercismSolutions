using System;

namespace Exercism.clock
{
    class Clock
    {
        private int _hours;
        private int _minutes;
        public int Hours
        {
            get { return _hours; }
            set { _hours = (value + 24) % 24; }
        }
        public int Minutes
        {
            get { return _minutes; }
            set
            {
                if (value < 0)
                {
                    var hours = (1 - (int)Math.Ceiling(value / 60.0));
                    Hours -= hours;
                    value = 60 * hours + value;
                }
                if (value > 59)
                {
                    Hours += (int)Math.Floor(value / 60.0);
                    value = value % 60;
                }
                _minutes = value;
            }
        }
        public Clock(int hours, int minutes = 0)
        {
            Hours = hours;
            Minutes = minutes;
        }

        public Clock Add(int minutes) => new Clock(Hours, Minutes + minutes);

        public Clock Subtract(int minutes) => Add(-minutes);

        public bool Equals(Clock other) => Hours.Equals(other?.Hours) && Minutes.Equals(other?.Minutes);

        public override bool Equals(object obj) => Equals(obj as Clock);

        public override int GetHashCode() => base.GetHashCode();

        public override string ToString() => $"{Hours:00}:{Minutes:00}";
    }
}
