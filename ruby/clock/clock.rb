class Clock
  def initialize(min, hour=0)
    @minutes = hour * 60 + min
    while @minutes < 0
      @minutes += 1440
    end
    @minutes = @minutes % 1440
  end
  def self.at(hour, min)
    Clock.new(min, hour)
  end
  def to_s
    h = (@minutes / 60).to_s.rjust(2,"0")
    m = (@minutes % 60).to_s.rjust(2,"0")
    "#{h}:#{m}"
  end
  def +(min)
    Clock.new(@minutes + min)
  end
  def ==(other)
    to_s == other.to_s
  end
end
module BookKeeping
  VERSION = 2 # Where the version number matches the one in the test.
end