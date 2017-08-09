package gigasecond

import "time"

const testVersion = 4

func AddGigasecond(bday time.Time) time.Time {
	return bday.Add(1000000000 * time.Second);
}
