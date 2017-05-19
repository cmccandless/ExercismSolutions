#include "food_chain.h"

using namespace std;

string phrase[] =
{
	"",
	"fly",
	"spider",
	"bird",
	"cat",
	"dog",
	"goat",
	"cow",
	"horse",
};

string extra[] =
{
	"",
	"I don't know why she swallowed the fly. Perhaps she'll die.",
	"wriggled and jiggled and tickled inside her.",
	"How absurd to swallow a bird!",
	"Imagine that, to swallow a cat!",
	"What a hog, to swallow a dog!",
	"Just opened her throat and swallowed a goat!",
	"I don't know how she swallowed a cow!",
	"She's dead, of course!",
};

string food_chain::verse(int n, bool root)
{
	stringstream result;
	if (root) result << "I know an old lady who swallowed a ";
	else result << "She swallowed the " << phrase[n + 1] << " to catch the ";
	result << phrase[n];
	if (n == 2)
	{
		if (root) result << ".\nIt ";
		else result << " that " << extra[n] << "\n";
	}
	else result << ".\n";
	if (root || n == 1) result << extra[n] << "\n";
	if (n < 8 && n > 1) result << verse(n - 1, false);
	return result.str();
}