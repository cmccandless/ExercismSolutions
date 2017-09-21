class Poker
  def initialize(handStrs)
    @hands = handStrs.collect { |h| Hand.new(h) }
  end
  def best_hand
    results = []
    @hands.each { |hand|
      if results.empty?
        results.push(hand)
      else
        case results[0] <=> hand
        when 0
          results.push(hand)
        when -1
          results = [hand]
        end
      end
    }
    results.collect { |h| h.to_a }
  end
end
class Hand
  @@types = ["11111", "2111", "221", "311", "S", "F", "32", "41", "SF"]
  def initialize(cards)
    @cards = cards.collect { |card| Card.new(card) }
    @cards = @cards.collect { |card| card.low_ace } if counts_s(0) == "145432"
  end
  attr_reader :cards
  def counts
    cs = @cards.collect { |c| c.value }
          .group_by(&:itself)
          .collect { |value, group| [value, group.size] }
          .sort_by { |value, count| [-count, -value] }
    cs
  end
  def counts_s(i)
    counts.transpose[i].join
  end
  def straight?
    values = counts.collect { |value, count| value }.sort
    values.size == 5 && 
      (values[4] - values[0] == 4 ||
       values[4] == 14 && values[0] == 2 && values[3] - values[0] == 3)
  end
  def flush?
    1 == @cards.collect { |c| c.suit }.group_by(&:itself).size
  end
  def classify
    countStr = ""
    countStr = "S" if straight?
    countStr += "F" if flush?
    countStr = counts_s(1) if countStr.empty?
    @@types.index(countStr)
  end
  def <=>(other)
    c = classify <=> other.classify
    c != 0 ? c
           : counts.zip(other.counts)
                   .collect { |a,b| a <=> b }
                   .drop_while { |x| x == 0 }
                   .push(0)[0]
  end
  def to_a
    @cards.collect { |card| card.to_s }
  end
  def to_s
    "[#{to_a.join(",")}]"
  end
end
class Card
  @@values = '_123456789TJQKA'
  def initialize(cardStr)
    @value = cardStr =~ /10/ ? 10 : @@values.index(cardStr[0..-2])
    @suit = cardStr[-1]
  end
  attr_reader :value
  attr_reader :suit
  def <=>(other)
    c = @value <=> other.value
    c != 0 ? c : @suit <=> other.suit
  end
  def to_s
    case @value
    when 10
      "10#{@suit}"
    when 1
      "A#{@suit}"
    else
      "#{@@values[@value]}#{@suit}"
    end
  end
  def low_ace
    value == 14 ? Card.new("1#{suit}") : self
  end
end
module BookKeeping
  VERSION = 2
end