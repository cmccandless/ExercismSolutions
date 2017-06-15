import java.time.*;

public final class Meetup {
    private LocalDate d;
    public Meetup(int m, int y) { d = LocalDate.of(y, m, 1); }
    private static LocalDate adjustTo(LocalDate d, DayOfWeek day) {
        return d.plusDays((day.ordinal() - d.getDayOfWeek().ordinal() + 7) % 7);
    }
    public LocalDate lastDay(DayOfWeek day) {
        return adjustTo(d.plusMonths(1), day).minusWeeks(1);
    }
    public LocalDate teenthDay(DayOfWeek day) {
        return adjustTo(d.plusDays(12), day);
    }
    public LocalDate day(DayOfWeek day, MeetupSchedule sch) {
        // LocalDate d = LocalDate.of(year, month, 1);
        return sch == MeetupSchedule.TEENTH ? teenthDay(day) :
            sch == MeetupSchedule.LAST ? lastDay(day) :
            adjustTo(d, day).plusWeeks(sch.ordinal());
    }
}