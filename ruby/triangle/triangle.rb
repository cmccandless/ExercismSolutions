class Triangle
  def initialize(sides)
    @sides = sides
  end
  def valid?
    a,b,c = @sides
    @sides.all? { |s| s > 0 } && a + b > c && b + c > a && a + c > b
  end
  def equilateral?
    valid? && @sides.all? { |s| s == @sides[0] }
  end
  def isosceles?
    a,b,c = @sides
    valid? && (a == b || b == c || a == c)
  end
  def scalene?
    valid? && !isosceles?
  end
end
module BookKeeping
  VERSION = 1 # Where the version number matches the one in the test.
end