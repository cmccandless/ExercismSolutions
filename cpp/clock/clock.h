#ifndef clock_h
#define clock_h

#include <iomanip>
#include <sstream>
#include <string>

using namespace std;

namespace date_independent
{
	class clock
	{
	private:
		int minutes;
		clock(int, int);
	public:
		static clock at(int, int);
		operator string() const;
		clock plus(int);
		int operator ==(clock) const;
		int operator !=(clock) const;
	};
}

#endif
