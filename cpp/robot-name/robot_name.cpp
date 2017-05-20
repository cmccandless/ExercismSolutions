#include "robot_name.h"

char randCh(char min, char max) { return char(min + (rand() % (int)(max - min + 1))); }

char randL() { return randCh('A', 'Z'); }

char randD() { return randCh('0', '9'); }

robot_name::robot::robot() { reset(); }

string robot_name::robot::name() const { return _name; }

void robot_name::robot::reset()
{
	vector<char> chs = { randL() , randL() , randD() , randD() , randD() };
	_name = string(chs.begin(), chs.end());
}
