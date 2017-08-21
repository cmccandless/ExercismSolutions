class Binary
	def self.to_decimal(base2)
		raise ArgumentError if !"01"[base2[-1]]
		base2.length == 1 ? base2.to_i : base2[-1].to_i + 2 * to_decimal(base2[0..-2])
	end
end
module BookKeeping
  VERSION = 3 # Where the version number matches the one in the test.
end