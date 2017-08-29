class FoodChain
  @@animal = ["fly", "spider", "bird", "cat", "dog", "goat", "cow", "horse"]
  @@spider = " wriggled and jiggled and tickled inside her."
  def self.start(n)
    extra = [
      "",
      "It#{@@spider}",
      "How absurd to swallow a bird!",
      "Imagine that, to swallow a cat!",
      "What a hog, to swallow a dog!",
      "Just opened her throat and swallowed a goat!",
      "I don't know how she swallowed a cow!",
      "She's dead, of course!"
    ]
    line = "I know an old lady who swallowed a #{@@animal[n]}."
    n > 0 ? [line, extra[n]] : line
  end
  def self.middle(n)
    case n
    when 0
      ["I don't know why she swallowed the fly. Perhaps she'll die."]
    when 7
      []
    else
      nxt = n - 1
      swallowed = "She swallowed the #{@@animal[n]}"
      caught = " to catch the #{@@animal[nxt]}#{nxt == 1 ? " that#{@@spider}" : "."}"
      middle(nxt).unshift(swallowed + caught)
    end
  end
  def self.song
    (0..7).collect { |n| 
      [start(n), middle(n), (n == 7 ? [] : "")].flatten 
    }
    .join("\n") + "\n"
  end
end
module BookKeeping
  VERSION=2
end