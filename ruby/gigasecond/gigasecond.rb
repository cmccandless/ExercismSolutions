class Gigasecond
	def self.from(t)
		return Time.at(1000000000 + t.to_i)
	end
end
module BookKeeping
  VERSION = 6 # Where the version number matches the one in the test.
end