#include "phone_number.h"

using namespace std;

string strip(const string s)
{
	string str = s;
	for (int i = 0; i < str.size();)
	{
		if (!isdigit(str[i]))
		{
			str.erase(i, 1);
			continue;
		}
		i++;
	}
	return str;
}

phone_number::phone_number(const string num)
{
	full = strip(num);
	if (full.size() != 10)
	{
		if (full.size() == 11 && full[0] == '1') full.erase(0, 1);
		else full = "0000000000";
	}
}

string phone_number::number() const { return full; }

string phone_number::area_code() const 
{
	string ac = full;
	return ac.erase(3);
}

phone_number::operator string() const
{
	auto s = full;
	return s.insert(6, 1, '-').insert(3, 1, ' ').insert(3, 1, ')').insert(0, 1, '(');
}