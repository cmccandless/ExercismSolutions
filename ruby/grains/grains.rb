class Grains
	def self.square(n)
		raise ArgumentError if n < 1 || n > 64
		return 1 if n == 1
		return 2 * square(n - 1)
	end
	def self.total
		return (1..64).inject(0){|sum,x| sum + square(x) }
	end
end
module BookKeeping
  VERSION = 1 # Where the version number matches the one in the test.
end