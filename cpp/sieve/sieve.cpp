#include "sieve.h"

vector<int> sieve::primes(int max)
{
	auto p = vector<int>();
	auto np = vector<bool>(max, false);
	np[0] = np[1] = true;
	for (int i = 2; i < max; i++)
	{
		if (np[i]) continue;
		p.push_back(i);
		for (int j = i + i; j < max; j += i) np[j] = true;
	}
	return p;
}
