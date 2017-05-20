#ifndef grade_school_h
#define grade_school_h

#include <algorithm>
#include <map>
#include <string>
#include <vector>

using namespace std;

namespace grade_school
{
	class school
	{
	private:
		map<int, vector<string>> _roster;
	public:
		school();
		map<int, vector<string>> roster();
		void add(string, int);
		vector<string> grade(int);
	};
}

#endif
