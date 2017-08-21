class RunLengthEncoding
	def self.encode(input)
		input == "" ? ""
			: input.match(/((.)\2*)(.*)/) { |m|
				(m[1].length > 1 ? m[1].length.to_s + m[2] : m[2]) + encode(m[3])
			}
	end
	def self.decode(input)
		input == "" ? ""
			: input.match(/(\d+)?([^\d])(.*)/) { |m|
				(m[1] ? m[2] * m[1].to_i : m[2]) + decode(m[3])
			}
	end
end
module BookKeeping
  VERSION = 3 # Where the version number matches the one in the test.
end