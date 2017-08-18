package bob

import (
	"strings"
	"unicode"
)

const testVersion = 3

func HasLetter(input string) bool {
	for i := 0; i < len(input); i++ {
		if unicode.IsLetter(rune(input[i])) {
			return true
		}
	}
	return false
}

func Hey(input string) string {
	input = strings.TrimSpace(input)
	if len(input) == 0 {
		return "Fine. Be that way!"
	}
	if HasLetter(input) && input == strings.ToUpper(input) {
		return "Whoa, chill out!"
	}
	if input[len(input)-1] == '?' {
		return "Sure."
	}
	return "Whatever."
}
