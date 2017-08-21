class Sieve
	def initialize(n)
		@num = n
	end
	def primes
		np = (0..@num).select { |x| false }
		np[0] = true
		np[1] = true
		for i in (2..@num - 1) do
			x = i + i
			until x > @num
				np[x] = true
				x += i
			end
		end
		return (2..@num).select { |x| !np[x] }
	end
end
module BookKeeping
  VERSION = 1 # Where the version number matches the one in the test.
end