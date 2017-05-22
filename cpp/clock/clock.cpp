#include "clock.h"

namespace date_independent
{
	clock::clock(int hour, int minute) : minutes(hour * 60 + minute) { }

	clock date_independent::clock::at(int hour, int minute) 
	{ 
		minute += hour * 60;
		while (minute < 0) minute += 1440;
		minute %= 1440;
		return clock(0, minute);
	}
	clock::operator string() const
	{
		auto ss = stringstream();
		auto h = minutes / 60;
		auto m = minutes % 60;
		ss << setw(2) << setfill('0') << h << ':' << setw(2) << m;
		return ss.str();
	}
	clock clock::plus(int m)
	{
		minutes += m;
		while (minutes < 0) minutes += 1440;
		minutes %= 1440;
		return *this;
	}
	int clock::operator==(clock other) const
	{
		return minutes == other.minutes;
	}
	int clock::operator!=(clock other) const
	{
		return !(*this == other);
	}
}
