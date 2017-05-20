#ifndef space_age_h
#define space_age_h

#include "math.h"

namespace space_age
{
	class space_age
	{
	private:
		__int64 _seconds;
	public:
		space_age(__int64);
		__int64 seconds() const;
		double on_earth() const;
		double on_mercury() const;
		double on_venus() const;
		double on_mars() const;
		double on_jupiter() const;
		double on_saturn() const;
		double on_uranus() const;
		double on_neptune() const;
	};
}

#endif
