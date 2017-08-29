class Queens
  def initialize(white: nil, black: nil)
    white.each { |c| raise ArgumentError if c < 0 || c > 7 } if !white.nil?
    black.each { |c| raise ArgumentError if c < 0 || c > 7 } if !black.nil?
    @white = white
    @black = black
  end
  def attack?
    @white[0] == @black[0] || 
      @white[1] == @black[1] || 
      (@white[0] - @black[0]).abs == (@white[1] - @black[1]).abs
  end
end
module BookKeeping
  VERSION = 2 # Where the version number matches the one in the test.
end