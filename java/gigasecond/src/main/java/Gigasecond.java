import java.time.LocalDate;
import java.time.LocalDateTime;
import java.time.LocalTime;

class Gigasecond {
    private LocalDateTime birth;
    Gigasecond(LocalDate birthDate) {
        birth = LocalDateTime.of(birthDate, LocalTime.MIDNIGHT);
    }

    Gigasecond(LocalDateTime birthDateTime) {
        birth = birthDateTime;
    }

    LocalDateTime getDate() {
        return birth.plusSeconds(1000000000);
    }

}
