class Year
	def self.leap?(y)
		return y % 4 == 0 && (y % 100 != 0 || y % 400 == 0)
	end
end
module BookKeeping
VERSION = 3 # Where the version number matches the one in the test.
end