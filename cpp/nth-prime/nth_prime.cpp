#include "nth_prime.h"

int prime::nth(int n)
{
	auto np = std::vector<bool>(500000, false);
	np[0] = np[1] = true;
	auto c = 0;
	for (auto i = 2u; i < np.size(); i++)
	{
		if (np[i]) continue;
		if (++c == n) return i;
		for (auto j = i + i; j < np.size(); j += i) np[j] = true;
	}
	throw std::domain_error("Invalid index.");
}
