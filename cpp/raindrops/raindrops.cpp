#include "raindrops.h"

string raindrops::convert(int x)
{
	auto result = stringstream();
	if (x % 3 == 0) result << "Pling";
	if (x % 5 == 0) result << "Plang";
	if (x % 7 == 0) result << "Plong";
	if (result.rdbuf()->in_avail() == 0) result << x;
	return result.str();
}
