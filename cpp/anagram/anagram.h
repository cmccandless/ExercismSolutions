#ifndef anagram_h 
#define anagram_h 

#include <algorithm>
#include <cctype>
#include <string>
#include <vector>

using namespace std;

namespace anagram
{
	class anagram
	{
	private:
		string base;
	public:
		anagram(string word);
		vector<string> matches(vector<string> words);
	};

	string aslower(string word);

	bool isanagram(string a, string b);
}

#endif 
