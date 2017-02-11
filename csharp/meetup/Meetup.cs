using System;
using System.Linq;

public enum Schedule
{
	First,
	Second,
	Third,
	Fourth,
	Teenth,
	Last,
}

public class Meetup
{
	private int Month { get; set; }
	private int Year { get; set; }

	public Meetup(int month, int year)
	{
		this.Month = month;
		this.Year = year;
	}

	public DateTime Day(DayOfWeek dayOfWeek, Schedule schedule)
	{
		var daysInMonth = DateTime.DaysInMonth(Year,Month);
		switch(schedule)
		{
			case Schedule.First:
			case Schedule.Second:
			case Schedule.Third:
			case Schedule.Fourth:
				return (from i in Enumerable.Range(1,daysInMonth)
						let d = new DateTime(Year, Month, i)
						where d.DayOfWeek == dayOfWeek
						select d).ToArray()[(int)schedule];
			case Schedule.Teenth:
				return Enumerable.Range(13, 7)
					.Select(i => new DateTime(Year, Month, i))
					.First(d => d.DayOfWeek == dayOfWeek);
			default:
			case Schedule.Last:
				return (from i in Enumerable.Range(1, daysInMonth)
						let d = new DateTime(Year, Month, i)
						where d.DayOfWeek == dayOfWeek
						select d).Last();
		}
	}
}