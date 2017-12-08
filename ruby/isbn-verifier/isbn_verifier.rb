class IsbnVerifier
    def self.valid?(isbn)
        isbn.tr("-","")
            .chars
            .each_with_index
            .collect { |digit, index|
                if digit == 'X'
                    if index == 9
                        digit = 10
                    else
                        return nil
                    end
                else
                    digit = digit.to_i
                end
                (10 - index) * digit
            }.sum % 11 == 0
    end
end
module BookKeeping
    VERSION = 1
end
