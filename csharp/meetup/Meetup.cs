using System;

public enum Schedule { First, Second, Third, Fourth, Teenth, Last, }

public class Meetup
{
    private int Month, Year;
    public Meetup(int month, int year) { Month = month; Year = year; }

    public DateTime Day(DayOfWeek dayOfWeek, Schedule schedule)
    {
        int nth = 0, start, stop, inc = 1;
        var daysInMonth = DateTime.DaysInMonth(Year, Month);
        switch (schedule)
        {
            case Schedule.First:
            case Schedule.Second:
            case Schedule.Third:
            case Schedule.Fourth:
                start = 1;
                stop = daysInMonth;
                nth = (int)schedule;
                break;
            case Schedule.Teenth:
                start = 13;
                stop = 19;
                break;
            default:
            case Schedule.Last:
                start = daysInMonth;
                stop = 1;
                inc = -1;
                break;
        }
        for (var counter = 0; start != stop + inc; start += inc)
        {
            var d = new DateTime(Year, Month, start);
            if (d.DayOfWeek == dayOfWeek && counter++ == nth) return d;
        }
        return default(DateTime);
    }
}