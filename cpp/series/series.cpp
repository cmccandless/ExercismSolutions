#include "series.h"

vector<int> series::digits(string s)
{
	auto a = vector<int>();
	for (auto const &ch : s) a.push_back(ch - '0');
	return a;
}

vector<vector<int>> series::slice(string s, int n)
{
	if (s.size() < n) throw domain_error("Not enough digits.");
	auto a = vector<vector<int>>();
	auto b = digits(s);
	for (int i = 0; i < b.size() - n + 1; i++)
	{
		auto c = vector<int>();
		for (int j = 0; j < n; j++) c.push_back(b[i + j]);
		a.push_back(c);
	}
	return a;
}
