#include "hexadecimal.h"

int hexadecimal::convert(string s)
{
	auto result = 0;
	for (auto const &ch : s)
	{
		result *= 16;
		if (isalpha(ch) && ch <= 'f') result += ch - 'a' + 10;
		else if (isdigit(ch)) result += ch - '0';
		else return 0;
	}
	return result;
}
