class Squares
	def initialize(n)
		@num = n
	end
	def square_of_sum
		sum = (1..@num).inject(:+)
		return sum * sum
	end
	def sum_of_squares
		return (1..@num).inject(0){|sum,x| sum + x * x }
	end
	def difference
		return square_of_sum - sum_of_squares
	end
end
module BookKeeping
  VERSION = 4 # Where the version number matches the one in the test.
end