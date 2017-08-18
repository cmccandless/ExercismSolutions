package triangle

import "math"

const testVersion = 3

type Kind int

const (
	NaT = -1 // not a triangle
	Equ = 3  // equilateral
	Iso = 1  // isosceles
	Sca = 0  // scalene
)

func KindFromSides(a, b, c float64) Kind {
	sides := [3]float64{a, b, c}
	for i := 0; i < 3; i++ {
		s := sides[i]
		if s == 0 || math.IsNaN(s) || math.IsInf(s, 0) {
			return NaT
		}
	}
	if a > b+c || b > a+c || c > a+b {
		return NaT
	}
	score := 0
	if a == b {
		score++
	}
	if b == c {
		score++
	}
	if a == c {
		score++
	}
	return Kind(score)
}
