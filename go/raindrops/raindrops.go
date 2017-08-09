package raindrops

import "strconv"

const testVersion = 3

func Convert(value int) string {
	s := ""
	if value % 3 == 0 {
		s += "Pling"
	}
	if value % 5 == 0 {
		s += "Plang"
	}
	if value % 7 == 0 {
		s += "Plong"
	}
	if s == "" {
		return strconv.Itoa(value)
	}
	return s
}

// Don't forget the test program has a benchmark too.
// How fast does your Convert convert?
