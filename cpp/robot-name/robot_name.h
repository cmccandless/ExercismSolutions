#ifndef robot_name_h
#define robot_name_h

#include <string>
#include <vector>

using namespace std;

namespace robot_name
{
	class robot
	{
	private:
		string _name;
	public:
		robot();
		string name() const;
		void reset();
	};
}

#endif
