#include "nucleotide_count.h"

using namespace std;

namespace dna
{
	bool valid(char ch)
	{
		switch (ch)
		{
		case 'A':
		case 'C':
		case 'G':
		case 'T':
			return true;
		default:
			return false;
		}
	}

	counter::counter(const string s) : nucleotides(s)
	{
		for (auto &ch : nucleotides)
		{
			if (!valid(ch)) throw std::invalid_argument("Invalid nucleotide.");
		}
	}

	map<char, int> counter::nucleotide_counts() const
	{
		map<char, int> dict = { { 'A', 0 }, { 'C', 0 }, { 'G', 0 }, { 'T', 0 }, };
		for (auto &ch : nucleotides) dict[ch]++;
		return dict;
	}

	int counter::count(char ch) const
	{
		if (valid(ch)) return nucleotide_counts()[ch];
		throw std::invalid_argument("Invalid nucleotide.");
	}
}