class Palindromes
  def initialize(max_factor: 1000, min_factor: 1)
    @max_factor = max_factor
    @min_factor = min_factor
    @largest = nil
    @smallest = nil
  end
  attr_reader :largest
  attr_reader :smallest
  def palindrome?(n)
    n == n.to_s.reverse.to_i
  end
  def generate
    @smallest = Product.new(value: @max_factor * @max_factor, factors: [])
    @largest = Product.new(value: @min_factor, factors: [])
    (@min_factor..@max_factor).each { |m|
      (m..@max_factor).each { |n|
        p = m * n
        if palindrome?(p)
          case @smallest.value <=> p
          when 0
            @smallest.factors.push([m,n])
          when 1
            @smallest = Product.new(value: p, factors: [[m,n]])
          end
          case @largest.value <=> p
          when 0
            @largest.factors.push([m,n])
          when -1
            @largest = Product.new(value: p, factors: [[m,n]])
          end
        end
      }
    }
    @smallest.factors = @smallest.factors.uniq
    @largest.factors = @largest.factors.uniq
  end
end
class Product
  def initialize(value: 0, factors: [])
    @value = value
    @factors = factors
  end
  attr_reader :value
  attr_accessor :factors
end