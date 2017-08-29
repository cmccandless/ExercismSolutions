require 'set'
class Robot
  @@used = Set.new
  @@maxName = 26 * 26 * 1000
  def initialize
    @name = ""
    reset
  end
  attr_reader :name
  def randDigit
    rand(10).to_s
  end
  def randLetter
    (rand(26) + "A".ord).chr
  end
  def reset
    r = rand(@@maxName)
    while @@used.include?(r)
      r = rand(@@maxName)
    end
    @@used.add(r)
    @name = ((r / 26000).floor + "A".ord).chr
    @name += (((r % 26000) / 1000).floor + "A".ord).chr
    @name += (r % 1000).to_s.rjust(3,"0")
  end
  def self.forget
    @@used.clear
  end
end
module BookKeeping
  VERSION=3
end