public final class QueenAttackCalculator {
    private BoardCoordinate first, second;
    public QueenAttackCalculator(BoardCoordinate f, BoardCoordinate s) {
        if (f == null || s == null) throw new IllegalArgumentException("You must supply valid board coordinates for both Queens.");
        if (f.equals(s)) throw new IllegalArgumentException("Queens may not occupy the same board coordinate.");
        first = f;
        second = s;
    }
    public boolean canQueensAttackOneAnother() {
        return first.rank == second.rank || first.file == second.file ||
        Math.abs(first.rank - second.rank) == Math.abs(first.file - second.file);
    }
}
