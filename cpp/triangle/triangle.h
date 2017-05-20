#ifndef triangle_h
#define triangle_h

#include <stdexcept>

using namespace std;

namespace triangle
{
	enum triangle_kind {  scalene, isosceles, np, equilateral,};

	triangle_kind kind(double, double, double);
}

#endif
