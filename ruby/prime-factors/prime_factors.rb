class PrimeFactors
	# https://rosettacode.org/wiki/Miller%E2%80%93Rabin_primality_test#Ruby
	def self.mod_exp(n, e, mod)
		fail ArgumentError, 'negative exponent' if e < 0
		prod = 1
		base = n % mod
		until e.zero?
			prod = (prod * base) % mod if e.odd?
			e >>= 1
			base = (base * base) % mod
		end
		prod
	end
	def self.prime?(n, g)
		return false if n < 2
		return true if n < 4
		d = n - 1
		s = 0
		while d % 2 == 0
		d /= 2
		s += 1
		end
		g.times do
		a = 2 + rand(n - 4)
		x = mod_exp(a, d, n) # x = (a**d) % n
		next if x == 1 || x == n - 1
		for r in (1..s - 1)
			x = mod_exp(x, 2, n) # x = (x**2) % n
			return false if x == 1
			break if x == n - 1
		end
		return false if x != n - 1
		end
		true # probably
	end
  def self.for(n)
    factors = []
    x = 2
    while n != 1
      if n % x == 0
        n /= x
        factors.push(x)
      else
        loop do
          x += 1
          break if prime?(x, 5)
        end
      end
    end
    factors
  end
end