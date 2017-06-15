final class Robot {
    private int x, y, heading;
    public Robot(GridPosition p, Orientation o) {
        x = p.x; y = p.y; heading = o.ordinal();
    }
    public Orientation getOrientation() {
        return Orientation.values()[heading];
    }
    public GridPosition getGridPosition() {
        return new GridPosition(x, y);
    }
    public void simulate(String commands) {
        for (char c : commands.toCharArray()) {
            switch(c) {
                case 'A': advance(); break;
                case 'L': turnLeft(); break;
                case 'R': turnRight(); break;
            }
        }
    }
    public void advance() {
        if (heading % 2 == 0) y += (heading == 0) ? 1 : -1;
        else x += (heading == 1 ? 1 : -1);
    }
    public void turnLeft() {
        heading = (heading + 3) % 4;
    }
    public void turnRight() {
        heading = (heading + 1) % 4;
    }
}
