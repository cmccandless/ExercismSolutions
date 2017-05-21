#include "roman_numerals.h"

namespace roman
{
	//map<string, int> _t =
	vector<tuple<string,int>> _t =
	{
		make_tuple("M", 1000),
		make_tuple("CM", 900),
		make_tuple("D", 500),
		make_tuple("CD", 400),
		make_tuple("C", 100),
		make_tuple("XC", 90),
		make_tuple("L", 50),
		make_tuple("XL", 40),
		make_tuple("X", 10),
		make_tuple("IX", 9),
		make_tuple("V", 5),
		make_tuple("IV", 4),
		make_tuple("I", 1),
	};

	string convert(int x)
	{
		auto s = stringstream();
		for (auto const &p : _t)
		{
			string key;
			int val;
			tie(key, val) = p;
			while (x >= val)
			{
				s << key;
				x -= val;
			}
		}
		return s.str();
	}
}