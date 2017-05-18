#include "gigasecond.h" 

using namespace boost::posix_time;

ptime gigasecond::advance(ptime t)
{
	return t + seconds(1000000000);
}
