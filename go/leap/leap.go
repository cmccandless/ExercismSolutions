package leap

const testVersion = 3

func IsLeapYear(x int) bool {
	return x % 4 == 0 && (x % 100 != 0 || x % 400 == 0)
}
