class Triplet
  def initialize(a, b, c)
    @sides = [a,b,c].sort
    @sum = a + b + c
    @product = a * b * c
  end
  attr_reader :sum
  attr_reader :product
  def pythagorean?
    a,b,c = @sides
    a * a + b * b == c * c
  end
  def self.maxmin(a, b)
    a > b ? [a, b] : [b, a]
  end
  def self.primitive_triplets(b)
    b_div_2 = b / 2
    (2..b_div_2 + 1).select { |m| b_div_2 % m == 0 }
                    .collect { |m| maxmin(m, b_div_2 / m) }
                    .select { |m, n| (m - n) % 2 == 1 && m.gcd(n) == 1 }
                    .collect { |m, n| 
                      maxmin(m * m - n * n, b).reverse.push(m * m + n * n)
                    }.uniq
  end
  def self.where(max_factor: 10, min_factor: 2, sum: nil)
    result = (4..max_factor + 1).step(4)
                                .collect { |b| primitive_triplets(b) }
                                .flatten(1)
                                .uniq
    result.to_a
          .each { |x, y, z|
            a,b,c = [x + x, y + y, z + z]
            while c <= max_factor
              result.push([a,b,c])
              a,b,c=[a+x,b+y,c+z]
            end
          }
    result.select { |a,b,c| a >= min_factor && c <= max_factor }
          .uniq
          .collect { |a,b,c| Triplet.new(a,b,c) }
          .select { |t| sum.nil? || t.sum == sum }
  end
end