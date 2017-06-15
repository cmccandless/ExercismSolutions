public final class BoardCoordinate {
    public int rank, file;
    public BoardCoordinate(int r, int f) {
        if (r < 0) throw new IllegalArgumentException("Coordinate must have positive rank.");
        if (r > 7) throw new IllegalArgumentException("Coordinate must have rank <= 7.");
        if (f < 0) throw new IllegalArgumentException("Coordinate must have positive file.");
        if (f > 7) throw new IllegalArgumentException("Coordinate must have file <= 7.");
        rank = r;
        file = f;
    }
    public boolean equals(BoardCoordinate other) {
        return rank == other.rank && file == other.file;
    }
}
