class Game
  class BowlingError < StandardError
    def initialize(msg="")
    end
  end
  def initialize(num=1)
    @num = num
    @ball1 = nil
    @ball2 = nil
    @next = nil
  end
  def balls
    @ball1 ? (@ball2 ? [@ball1, @ball2] : [@ball1]) : []
  end
  def strike?
    @ball1 && @ball1 == 10
  end
  def spare?
    !strike? && @ball2 && balls.sum == 10
  end
  def roll(pins)
    raise BowlingError if pins < 0 || pins > 10
    if !@ball1
      @ball1 = pins
    elsif !strike? && !@ball2
      raise BowlingError if pins + @ball1 > 10
      @ball2 = pins
    else 
      raise BowlingError if @num == 10 && !strike? && !spare?
      if !@next
        @next = Game.new(@num + 1)
      end
      @next.roll(pins)
    end
  end
  def rolls
    r = @next ? @next.rolls : []
    if @num < 10
      if strike?
        r = r.take(2) + r
      elsif spare?
        r = r.take(1) + r
      end
    end
    balls + r
  end
  def frames
    @next ? [self] + @next.frames : [self]
  end
  def score 
    fs = frames
    raise BowlingError if fs.length < 10
    raise BowlingError if fs.length == 10 && (fs[-1].strike? || fs[-1].spare?)
    raise BowlingError if fs.length == 11 && fs[-2].strike? && fs[-1].balls.length < 2
    rolls.sum
  end
end
module BookKeeping
  VERSION = 3 # Where the version number matches the one in the test.
end