#include "anagram.h" 

using namespace std;

namespace anagram
{
	anagram::anagram(string word)
	{
		base = word;
	}

	vector<string> anagram::matches(vector<string> words)
	{
		auto lowered = aslower(base);
		auto sbase = lowered;
		sort(sbase.begin(), sbase.end());
		auto result = vector<string>();
		while (!words.empty())
		{
			auto word = *words.begin();
			words.erase(words.begin());
			auto wlowered = aslower(word);
			if (lowered == wlowered) continue;
			if (isanagram(sbase, wlowered)) result.push_back(word);
		}
		return result;
	}

	string aslower(string word)
	{
		int n = word.size();
		for (int i = 0;i < n;i++) word[i] = tolower(word[i]);
		return word;
	}

	bool isanagram(string a, string b)
	{
		sort(b.begin(), b.end());
		return a == b;
	}
}