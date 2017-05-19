#ifndef nucleotide_count_h
#define nucleotide_count_h

#include <map>
#include <string>

namespace dna
{
	class counter
	{
		const std::string nucleotides;
	public:
		counter(const std::string s = "");
		std::map<char, int> nucleotide_counts() const; //http://stackoverflow.com/a/3259729
		int count(char) const;
	};
}

#endif
