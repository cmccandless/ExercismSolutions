#include "crypto_square.h"

string strip(const string s)
{
	auto ss = stringstream();
	for (auto i = 0u; i < s.size(); i++)
	{
		if (isalnum(s[i])) ss << char(tolower(s[i]));
	}
	return ss.str();
}

crypto_square::cipher::cipher(string s) : text(strip(s)) { }

string crypto_square::cipher::normalize_plain_text() { return text; }

int crypto_square::cipher::size() { return int(ceil(sqrt(text.size()))); }

vector<string> crypto_square::cipher::plain_text_segments()
{
	auto a = vector<string>();
	auto ss = stringstream();
	auto c = 0;
	auto s = size();
	for (auto const &ch : text)
	{
		ss << ch;
		c++;
		if (c == s)
		{
			c = 0;
			a.push_back(ss.str());
			ss.str("");
		}
	}
	if (c > 0) a.push_back(ss.str());
	return a;
}

string crypto_square::cipher::cipher_text()
{
	auto ss = stringstream();
	auto sz = size();
	for (int i = 0; i < sz; i++)
	{
		for (auto const &s : plain_text_segments())
		{
			if (i < s.size()) ss << s[i];
		}
	}
	return ss.str();
}

string crypto_square::cipher::normalized_cipher_text()
{
	auto ss = stringstream();
	auto c = 0;
	auto sz = plain_text_segments().size();
	for (auto const &ch : cipher_text())
	{
		if (c > sz)
		{
			ss << ' ';
			c = 0;
		}
		ss << ch;
		c++;
	}
	return ss.str();
}
