#include "queen_attack.h"

queen_attack::chess_board::chess_board() : _white(make_pair(0,3)), _black(make_pair(7,3)) { }

queen_attack::chess_board::chess_board(pair<int, int> w, pair<int, int> b) : _white(w), _black(b) 
{ 
	if (_white == _black) throw domain_error("Positions cannot be the same.");
}

pair<int, int> queen_attack::chess_board::white() const { return _white; }

pair<int, int> queen_attack::chess_board::black() const { return _black; }

queen_attack::chess_board::operator string() const
{
	auto ss = stringstream();
	for (int i = 0;i < 8;i++)
	{
		for (int j = 0;j < 8;j++)
		{
			auto p = make_pair(i, j);
			if (p == _white) ss << 'W';
			else if (p == _black) ss << 'B';
			else ss << '_';
			if (j < 7) ss << ' ';
		}
		ss << endl;
	}
	return ss.str();
}

bool queen_attack::chess_board::can_attack() const
{
	return _white.first == _black.first || _white.second == _black.second ||
		abs(_white.first - _black.first) == abs(_white.second - _black.second);
}
