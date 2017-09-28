class Diamond
  def self.make_diamond(c)
    a = 'A'.ord
    d = c.ord
    w = d - a
    lines = (a..d).collect { |i|
      x = i - a
      s = ' ' * (w - x) + i.chr + ' ' * x
      s + s[0..-2].reverse + "\n"
    }
    (lines + lines[0..-2].reverse).join
  end
end
module Bookkeeping
  VERSION = 1
end