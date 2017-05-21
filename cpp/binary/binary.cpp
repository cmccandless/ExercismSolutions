#include "binary.h"

int binary::convert(string s)
{
	auto result = 0;
	for (auto const &ch : s)
	{
		result <<= 1;
		switch (ch)
		{
		case '1': result |= 1;
		case '0': break;
		default: return 0;
		}
	}
	return result;
}
