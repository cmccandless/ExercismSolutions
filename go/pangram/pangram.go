package pangram

import (
	"strings"
	"unicode"
)

const testVersion = 2

func IsPangram(input string) bool {
	letters := make(map[byte]bool)
	input = strings.ToLower(input)
	for i := 0; i < len(input); i++ {
		if unicode.IsLetter(rune(input[i])) {
			letters[input[i]] = true
		}
	}
	return len(letters) == 26
}
