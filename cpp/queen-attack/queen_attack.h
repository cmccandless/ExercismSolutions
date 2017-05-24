#ifndef queen_attack_h
#define queen_attack_h

#include <sstream>
#include <string>
#include <stdexcept>
#include <utility>

using namespace std;

namespace queen_attack
{
	class chess_board
	{
	private:
		pair<int, int> _white;
		pair<int, int> _black;
	public:
		chess_board();
		chess_board(pair<int, int> w, pair<int, int> b);
		pair<int, int> white() const;
		pair<int, int> black() const;
		explicit operator string() const;
		bool can_attack() const;
	};
}

#endif
