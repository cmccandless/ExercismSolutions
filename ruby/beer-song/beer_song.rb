class BeerSong
  def bottles(n)
    case
    when n == 0
      "No more bottles"
    when n == 1
      "1 bottle"
    else
      "#{n} bottles"
    end
  end
  def verse(n)
    line2 = n == 0 ? 
      "Go to the store and buy some more, #{bottles(99)}" :
      "Take #{n == 1 ? "it" : "one"} down and pass it around, #{bottles(n - 1).downcase}"
    b = bottles(n)
    "#{b} of beer on the wall, #{b.downcase} of beer.\n#{line2} of beer on the wall.\n"
  end
  def verses(start, stop)
    (0..start - stop).collect { |i| verse(start - i) }.join("\n")
  end
end
module BookKeeping
  VERSION = 3 # Where the version number matches the one in the test.
end