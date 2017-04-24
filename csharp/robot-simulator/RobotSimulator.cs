public enum Bearing
{
    North = 1,
    East,
    South,
    West,
}
public class Coordinate
{
    public int[] pos;
    public Coordinate(params int[] p) { pos = p; }
    public override bool Equals(object obj) => Equals(obj as Coordinate);
    public bool Equals(Coordinate other) => pos[0].Equals(other?.pos[0]) && pos[1].Equals(other.pos[1]);
    public override int GetHashCode() => base.GetHashCode();
}
public class RobotSimulator
{
    private int bearing { get; set; }
    public Bearing Bearing
    {
        get => (Bearing)bearing;
        set => bearing = (int)value;
    }
    public Coordinate Coordinate { get; set; }
    public RobotSimulator(Bearing _bearing, Coordinate coord)
    {
        Bearing = _bearing;
        Coordinate = coord;
    }

    public void Simulate(string instructions)
    {
        foreach (var ch in instructions.ToUpper())
        {
            switch (ch)
            {
                case 'A': Advance(); break;
                case 'R': TurnRight(); break;
                case 'L': TurnLeft(); break;
            }
        }
    }

    public void Advance() => Coordinate.pos[bearing % 2] += bearing < 3 ? 1 : -1;

    public void TurnRight() => bearing = (bearing % 4) + 1;

    public void TurnLeft() => bearing = ((bearing + 2) % 4) + 1;
}
