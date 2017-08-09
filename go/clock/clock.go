package clock

import "fmt"

const testVersion = 4

const maxMinutes = 1440

type Clock struct {
	time int
}

func New(hour, minute int) Clock {
	return Clock{time: 0 }.Add(hour * 60 + minute)
}

func (c Clock) String() string {
	return fmt.Sprintf("%02d:%02d", c.time / 60, c.time % 60)
}

func (c Clock) Add(minutes int) Clock {
	for minutes < 0 {
		minutes += maxMinutes
	}
	return Clock{time: (c.time + minutes) % maxMinutes }
}
