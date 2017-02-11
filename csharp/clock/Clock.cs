using System;

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

	public override string ToString()
	{
		return string.Format("{0:00}:{1:00}", Hours, Minutes);
	}

	public Clock Add(int minutes)
	{
		return new Clock(Hours, Minutes + minutes);
	}

	public Clock Subtract(int minutes)
	{
		return Add(-minutes);
	}

	public override bool Equals(object obj)
	{
		return obj is Clock && (obj as Clock).Hours.Equals(Hours) && (obj as Clock).Minutes.Equals(Minutes);
	}
	public override int GetHashCode()
	{
		return base.GetHashCode();
	}
}
