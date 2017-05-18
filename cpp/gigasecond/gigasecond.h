#ifndef gigasecond_h 
#define gigasecond_h 

#define EXERCISM_RUN_ALL_TESTS

#include <boost/date_time/posix_time/conversion.hpp>
#include "boost/date_time/posix_time/posix_time.hpp" 

using namespace boost::posix_time;

namespace gigasecond
{
	ptime advance(ptime t);
}

#endif 
