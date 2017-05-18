#include "bob.h"

string bob::hey(string input)
{
	bool isShouting = true;
	int hasLetter = 0;
	int n = input.size();
	while (n > 0 && input[n - 1] == ' ') n--;
	if (n == 0) return "Fine. Be that way!";
	for (int i = 0;i < n;i++)
	{
		char ch = input[i];
		hasLetter |= isalpha(ch);
		if (ch != toupper(ch))
		{
			isShouting = false;
			break;
		}
	}
	if (hasLetter && isShouting) return "Whoa, chill out!";
	if (input[n - 1] == '?') return "Sure.";
	return "Whatever.";
}