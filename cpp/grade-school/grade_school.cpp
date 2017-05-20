#include "grade_school.h"

grade_school::school::school() { _roster = map<int, vector<string>>(); }

map<int, vector<string>> grade_school::school::roster() { return _roster; }

void grade_school::school::add(string name, int grade)
{
	_roster[grade].push_back(name);
	sort(_roster[grade].begin(), _roster[grade].end());
}

vector<string> grade_school::school::grade(int grade)
{
	try { return _roster[grade]; }
	catch (...) { return vector<string>(); }
}
