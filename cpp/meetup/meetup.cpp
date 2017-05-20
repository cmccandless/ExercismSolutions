#include "meetup.h"

namespace meetup
{

	scheduler::scheduler(months_of_year m, int y) : month(m), year(y) { }

	date scheduler::teenth(boost::date_time::weekdays day) const
	{
		auto d = date(year, month, 13);
		while (d.day_of_week() != day) d += days(1);
		return d;
	}

	date scheduler::nth(boost::date_time::weekdays day, int n) const
	{
		return first_day_of_the_week_in_month(day, month).get_date(year) + days((n-1)*7);
	}

	date scheduler::last(boost::date_time::weekdays day) const
	{
		return last_day_of_the_week_in_month(day, month).get_date(year);
	}

	date scheduler::monteenth() const { return teenth(Monday); }
	date scheduler::tuesteenth() const { return teenth(Tuesday); }
	date scheduler::wednesteenth() const { return teenth(Wednesday); }
	date scheduler::thursteenth() const { return teenth(Thursday); }
	date scheduler::friteenth() const { return teenth(Friday); }
	date scheduler::saturteenth() const { return teenth(Saturday); }
	date scheduler::sunteenth() const { return teenth(Sunday); }
	date scheduler::first_monday() const { return nth(Monday); }
	date scheduler::first_tuesday() const { return nth(Tuesday); }
	date scheduler::first_wednesday() const { return nth(Wednesday); }
	date scheduler::first_thursday() const { return nth(Thursday); }
	date scheduler::first_friday() const { return nth(Friday); }
	date scheduler::first_saturday() const { return nth(Saturday); }
	date scheduler::first_sunday() const { return nth(Sunday); }
	date scheduler::second_monday() const { return nth(Monday, 2); }
	date scheduler::second_tuesday() const { return nth(Tuesday, 2); }
	date scheduler::second_wednesday() const { return nth(Wednesday, 2); }
	date scheduler::second_thursday() const { return nth(Thursday, 2); }
	date scheduler::second_friday() const { return nth(Friday, 2); }
	date scheduler::second_saturday() const { return nth(Saturday, 2); }
	date scheduler::second_sunday() const { return nth(Sunday, 2); }
	date scheduler::third_monday() const { return nth(Monday, 3); }
	date scheduler::third_tuesday() const { return nth(Tuesday, 3); }
	date scheduler::third_wednesday() const { return nth(Wednesday, 3); }
	date scheduler::third_thursday() const { return nth(Thursday, 3); }
	date scheduler::third_friday() const { return nth(Friday, 3); }
	date scheduler::third_saturday() const { return nth(Saturday, 3); }
	date scheduler::third_sunday() const { return nth(Sunday, 3); }
	date scheduler::fourth_monday() const { return nth(Monday, 4); }
	date scheduler::fourth_tuesday() const { return nth(Tuesday, 4); }
	date scheduler::fourth_wednesday() const { return nth(Wednesday, 4); }
	date scheduler::fourth_thursday() const { return nth(Thursday, 4); }
	date scheduler::fourth_friday() const { return nth(Friday, 4); }
	date scheduler::fourth_saturday() const { return nth(Saturday, 4); }
	date scheduler::fourth_sunday() const { return nth(Sunday, 4); }
	date scheduler::last_monday() const { return last(Monday); }
	date scheduler::last_tuesday() const { return last(Tuesday); }
	date scheduler::last_wednesday() const { return last(Wednesday); }
	date scheduler::last_thursday() const { return last(Thursday); }
	date scheduler::last_friday() const { return last(Friday); }
	date scheduler::last_saturday() const { return last(Saturday); }
	date scheduler::last_sunday() const { return last(Sunday); }
}