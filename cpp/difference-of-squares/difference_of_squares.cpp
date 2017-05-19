#include "difference_of_squares.h"

namespace squares
{
	int square_of_sums(int n)
	{
		int result = 0;
		for (;n > 0;n--) result += n;
		return result * result;
	}

	int sum_of_squares(int n)
	{
		int result = 0;
		for (;n > 0;n--) result += n * n;
		return result;
	}

	int difference(int n)
	{
		return square_of_sums(n) - sum_of_squares(n);
	}
}