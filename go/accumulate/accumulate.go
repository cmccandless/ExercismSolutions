package accumulate

const testVersion = 1

func Accumulate(values []string, f func(string) string) []string {
	a := []string{}
	for  _, x := range values {
		a = append(a, f(x))
	}
	return a
}
