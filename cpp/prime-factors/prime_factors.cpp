#include "prime_factors.h"

vector<int> prime_factors::of(int x)
{
	auto facts = vector<int>();
	auto np = vector<bool>(x+1, false);
	np[0] = np[1] = true;
	for (int i = 2; i < np.size() && x > 1; i++)
	{
		if (np[i]) continue;
		while (x % i == 0)
		{
			x /= i;
			facts.push_back(i);
		}
		for (int j = i + i; j < np.size(); j += i) np[j] = true;
	}
	return facts;
}
