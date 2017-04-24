using System;

public class Clock
{
    private const int MAX_HOURS = 24;
    private const int MAX_MINUTES = 60;
    private const int MAX_TIME = MAX_HOURS * MAX_MINUTES;

    private int time;
    private int Time
    {
        get => time;
        set
        {
            time = value % MAX_TIME;
            if (time < 0) time += MAX_TIME;
        }
    }

    public int Minutes
    {
        get => Time % 60;
        set => Time = Time - Minutes + value;
    }

    public int Hours
    {
        get => Time / 60;
        set => Time = value * MAX_MINUTES + Minutes;
    }

    public Clock(int hours, int minutes = 0)
    {
        Hours = hours;
        Minutes = minutes;
    }

    public Clock Add(int minutes) => new Clock(Hours, Minutes + minutes);

    public Clock Subtract(int minutes) => Add(-minutes);

    public override bool Equals(object obj) => obj is Clock && Time.Equals((obj as Clock)?.Time);

    public override int GetHashCode() => base.GetHashCode();

    public override string ToString() => $"{Hours:00}:{Minutes:00}";
}
