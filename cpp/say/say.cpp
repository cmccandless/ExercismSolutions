#include "say.h"

namespace say
{
	vector<string> digits{ "zero","one","two","three","four","five","six","seven","eight","nine","ten",
	"eleven","twelve","thirteen","fourteen","fifteen","sixteen","seventeen","eighteen","nineteen" };
	vector<string> tens{ "","","twenty","thirty","forty","fifty","sixty","seventy","eighty","ninety" };
	vector<tuple<unsigned long long, string>> modifiers
	{
		make_tuple(1000000000ULL, " billion"),
		make_tuple(1000000ULL, " million"),
		make_tuple(1000ULL, " thousand"),
		make_tuple(100ULL, " hundred"),
	};

	string in_english(unsigned long long x)
	{
		if (x >= -1ULL) throw domain_error("Negative number.");
		if (x < 20) return digits[x];
		else if (x < 100)
		{
			auto result = tens[x / 10];
			auto r = x % 10;
			if (r > 0) result += "-" + in_english(r);
			return result;
		}
		for (auto const &t : modifiers)
		{
			unsigned long long mod;
			string label;
			tie(mod, label) = t;
			if (mod > x) continue;
			auto q = x / mod;
			if (q > 999) throw domain_error("Too large.");
			string result = in_english(q) + label;
			auto r = x % mod;
			if (r > 0) result += " " + in_english(r);
			return result;
		}
		throw domain_error("Invalid.");
	}
}
