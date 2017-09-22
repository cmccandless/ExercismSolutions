class TwelveDays
  @@nth = [ "", "first", "second", "third", "fourth",
    "fifth", "sixth", "seventh", "eighth",
    "ninth", "tenth", "eleventh", "twelfth"]
  @@gift = [ 
    "",
    "a Partridge in a Pear Tree",
    "two Turtle Doves",
    "three French Hens",
    "four Calling Birds",
    "five Gold Rings",
    "six Geese-a-Laying",
    "seven Swans-a-Swimming",
    "eight Maids-a-Milking",
    "nine Ladies Dancing",
    "ten Lords-a-Leaping",
    "eleven Pipers Piping",
    "twelve Drummers Drumming"
  ]
  def self.song
    verses(1,12)
  end
  def self.verses(start, stop)
    (start..stop).collect { |i| verse(i) }.join("\n")
  end
  def self.verse(n)
    gifts = *(1..n).collect { |i|
                     "#{n > 1 && i==1 ? "and " : ""}#{@@gift[i]}"
                   }.reverse
    "On the #{@@nth[n]} day of Christmas my true love gave to me, #{gifts.join(", ")}.\n"
  end
end
module BookKeeping
  VERSION=2
end