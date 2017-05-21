#ifndef crypto_square_h
#define crypto_square_h

#include <cctype>
#include <sstream>
#include <string>
#include <vector>

using namespace std;

namespace crypto_square
{
	class cipher
	{
	private:
		string text;
	public:
		cipher(string);
		string normalize_plain_text();
		int size();
		vector<string> plain_text_segments();
		string cipher_text();
		string normalized_cipher_text();
	};
}

#endif
