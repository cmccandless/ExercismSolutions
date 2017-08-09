package hamming

import "errors"

const testVersion = 6

func Distance(a, b string) (int, error) {
	if len(a) != len(b) {
		return 0, errors.New("differing lengths")
	}
	c := 0
	for i:=0; i < len(a); i++ {
		if a[i] != b[i] {
			c += 1
		}
	}
	return c, nil
}
