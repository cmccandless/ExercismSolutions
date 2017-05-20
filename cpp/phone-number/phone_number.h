#ifndef phone_number_h
#define phone_number_h

#include <string>

using namespace std;

class phone_number
{
private:
	string full;
public:
	phone_number(const string);
	string number() const;
	string area_code() const;
	operator string() const;
};

#endif
