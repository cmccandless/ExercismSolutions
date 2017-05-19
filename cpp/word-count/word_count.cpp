#include "word_count.h"

using namespace std;

string aslower(string word)
{
	int n = word.size();
	for (int i = 0;i < n;i++) word[i] = tolower(word[i]);
	return word;
}

map<string, int> word_count::words(string phrase)
{
	auto dict = map<string, int>();
	auto strs = vector<string>();
	boost::split(strs, phrase, boost::is_any_of(" \r\n!@#$%^&*(),./<>?{}[]_+-=:;"));
	for (auto &word : strs)
	{
		if (word[0] == '\'') word.erase(0,1);
		if (word.size() > 0 && word[word.size() - 1] == '\'') word.erase(word.size()-1,1);
		if (word == "") continue;
		word = aslower(word);
		try
		{
			dict[word]++;
		}
		catch (...)
		{
			dict[word] = 1;
		}
	}
	return dict;
}