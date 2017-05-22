#include "beer_song.h"

namespace beer
{
	string bottles(int n) { return n == 1 ? " bottle" : " bottles"; }

	string verse(int n)
	{
		auto ss = stringstream();
		string b = bottles(n);
		if (n > 0) ss << n;
		else ss << "No more";
		ss << b << " of beer on the wall, ";
		if (n > 0) ss << n;
		else ss << "no more";
		ss << b << " of beer." << endl;
		if (n > 0)
		{
			ss << "Take " << (n == 1 ? "it" : "one") << " down and pass it around, ";
			if (n == 1) ss << "no more";
			else ss << n - 1;
		}
		else ss << "Go to the store and buy some more, 99";
		ss << bottles(n - 1) << " of beer on the wall." << endl;
		return ss.str();
	}
	string sing(int start, int stop)
	{
		auto ss = stringstream();
		while (start >= stop)
		{
			ss << verse(start);
			if (start-- > stop) ss << endl;
		}
		return ss.str();
	}
}