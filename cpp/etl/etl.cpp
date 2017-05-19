#include "etl.h"

using namespace std;

map<char, int> etl::transform(map<int, vector<char>> old)
{
	auto dict = map<char, int>();
	for (auto const &pair : old)
	{
		auto key = pair.first;
		for (auto const &ch : pair.second) dict[tolower(ch)] = key;
	}
	return dict;
}