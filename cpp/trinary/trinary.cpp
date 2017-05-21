#include "trinary.h"

int trinary::to_decimal(string s)
{
	auto result = 0;
	for (auto const &ch : s)
	{
		result *= 3;
		auto x = ch - '0';
		if (x > 2) return 0;
		result += x;
	}
	return result;
}