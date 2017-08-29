class House
  @@wordPairs = [
    ["lay in", "house that Jack built.\n"],
    ["ate", "malt"],
    ["killed","rat"],
    ["worried","cat"],
    ["tossed","dog"],
    ["milked","cow with the crumpled horn"],
    ["kissed","maiden all forlorn"],
    ["married","man all tattered and torn"],
    ["woke","priest all shaven and shorn"],
    ["kept","rooster that crowed in the morn"],
    ["belonged to","farmer sowing his corn"],
    ["","horse and the hound and the horn"]
  ]
  def self.verse(n, start)
    verb, noun = @@wordPairs[n]
    "#{start ? "This is" : "that #{verb}"} the " +
      "#{noun}#{n == 0 ? "" : "\n#{verse(n - 1, false)}"}"
  end
  def self.recite
    (0..@@wordPairs.length - 1).collect { |n| verse(n, true) }
                               .join("\n")
  end
end