#include "hamming.h" 

using namespace std;

int hamming::compute(string a, string b)
{
	auto result = 0;
	int n = a.size();
	if (n != b.size()) throw domain_error("a.size() != b.size()");
	for (int i = 0;i < n;i++) result += a[i] != b[i];
	return result;
}