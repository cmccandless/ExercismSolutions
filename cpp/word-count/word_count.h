#ifndef word_count_h
#define word_count_h

#include <boost/algorithm/string.hpp>

#include <cctype>
#include <map>
#include <string>
#include <vector>

using namespace std;

namespace word_count
{
	map<string, int> words(string phrase);
}

#endif
