package acronym

import (
	"regexp"
	"strings"
)

const testVersion = 3

func Abbreviate(input string) string {
	reNonLetter := regexp.MustCompile("([^A-Za-z -])")
	reSplit := regexp.MustCompile("[\\s-]+")
	result := ""
	for _, word := range reSplit.Split(reNonLetter.ReplaceAllString(input, ""), -1) {
		if strings.ToUpper(word) == word {
			result += string(word[0])
		} else {
			for i := 0; i < len(word); i++ {
				if i == 0 || string(word[i]) == strings.ToUpper(string(word[i])) {
					result += string(word[i])
				}
			}
		}
	}

	return strings.ToUpper(result)
}
