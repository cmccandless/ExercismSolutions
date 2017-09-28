class Integer
  def factors
    (2..Math.sqrt(self).floor).reduce([1]) { |factors, x|
      case
      when self % x != 0
        factors
      when self / x == x
        factors.push(x)
      else
        factors.push(x).push(self / x)
      end
    }
  end
end
class PerfectNumber
  def self.classify(n)
    raise RuntimeError if n < 2
    case n <=> n.factors.sum
    when -1
      "abundant"
    when 0
      "perfect"
    when 1
      "deficient"
    end
  end
end
module BookKeeping
  VERSION = 1
end