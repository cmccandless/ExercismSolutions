#include "grains.h"

unsigned long long grains::square(int n)
{
	auto x = 1ULL;
	for (int i = 1; i < n; i++) x *= 2;
	return x;
}

unsigned long long grains::total()
{
	unsigned long long sum = 1ULL, x = 1ULL;
	for (int i = 0; i < 64; i++) sum += (x *= 2);
	return sum;
}
