#include "sum_of_multiples.h"

int sum_of_multiples::to(vector<int> nums, int max)
{
	auto vals = unordered_set<int>();
	for (auto &n : nums)
	{
		auto x = n;
		while (x < max)
		{
			vals.insert(x);
			x += n;
		}
	}
	auto sum = 0;
	for (auto &x : vals) sum += x;
	return sum;
}
