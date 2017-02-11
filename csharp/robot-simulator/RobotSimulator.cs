using System;
using System.Collections.Generic;

public enum Bearing
{
	North = 1,
	East,
	South,
	West,
}
class Coordinate
{
	public int[] pos;
	public Coordinate(int x, int y)
	{
		pos = new[] { x, y };
	}
	public override bool Equals(object obj)
	{
		return obj is Coordinate && (obj as Coordinate).pos[0] == pos[0] && (obj as Coordinate).pos[1] == pos[1];
	}
	public override int GetHashCode()
	{
		return base.GetHashCode();
	}
}
class RobotSimulator
{
	private int bearing { get; set; }
	public Bearing Bearing
	{
		get
		{
			return (Bearing)bearing;
		}
		set
		{
			bearing = (int)value;
		}
	}
	public Coordinate Coordinate { get; set; }
	private Dictionary<char, Action> sim;
	public RobotSimulator(Bearing _bearing, Coordinate coord)
	{
		Bearing = _bearing;
		Coordinate = coord;
		sim = new Dictionary<char, Action>()
		{
			{ 'A', () => Coordinate.pos[bearing % 2] += bearing < 3 ? 1 : -1 },
			{ 'R', () => bearing = (bearing % 4) + 1 },
			{ 'L', () => bearing = ((bearing + 2) % 4) + 1 },
		};
	}

	public void Simulate(string instructions)
	{
		foreach (var ch in instructions.ToUpper()) sim[ch]();
	}

	public void Advance() { sim['A'](); }

	public void TurnRight() { sim['R'](); }

	public void TurnLeft() { sim['L'](); }
}
