public final class Clock {
    private int minutes;
    public Clock(int hour, int minute) {
        add(hour * 60 + minute);
    }
    public void add(int minutes) {
        this.minutes += minutes;
        while (this.minutes < 0) this.minutes += 1440;
        this.minutes %= 1440;
        
    }
    @Override
    public String toString() {
        int h = minutes / 60;
        int m = minutes % 60;
        return String.format("%02d:%02d", h, m);
    }
    @Override
    public boolean equals(Object obj) {
        return obj instanceof Clock && ((Clock)obj).minutes == this.minutes;
    }
}