class Trinary
  def initialize(trinary)
    @trinary = trinary
  end
  def to_decimal
    @trinary =~ /[^012]/ ? 0 
      : @trinary.length == 1 ? @trinary.to_i : @trinary[-1].to_i + 3 * Trinary.new(@trinary[0..-2]).to_decimal
  end
end
module BookKeeping
  VERSION = 1 # Where the version number matches the one in the test.
end