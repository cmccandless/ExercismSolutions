class Tournament
  def self.flip_result(result)
    case result
    when "win"
      "loss"
    when "loss"
      "win"
    else
      result
    end
  end
  def self.tally(games)
    games.split("\n")
         .reduce({}) { |ts, game|
           home, away, result = game.split(";")
           [home, away].each { |team| 
             ts[team] = Team.new(team) unless ts.has_key?(team) 
           }
           ts[home] += result
           ts[away] += flip_result(result)
           ts
         }.values
         .sort
         .collect(&:to_s)
         .unshift("#{"Team".ljust(31)}| MP |  W |  D |  L |  P\n")
         .join
  end
end
class Team
  attr_reader :name, :points
  def initialize(name, games=[0,0,0])
    @name = name
    @games = games
    @points = games.zip([3,1,0]).collect { |g,m| g * m }.sum
  end
  def +(result)
    inc = (case result
           when "win"
             "100"
           when "draw"
             "010"
           when "loss"
             "001"
           end).chars
              .collect(&:to_i)
    Team.new(name, @games.zip(inc).collect(&:sum))
  end
  def <=>(other)
    c = other.points <=> points
    c == 0 ? name <=> other.name : c
  end
  def to_s
     [@games.sum, 
      @games[0],
      @games[1],
      @games[2], 
      points].collect { |x| x.to_s.rjust(3) }
             .unshift(name.ljust(30))
             .join(" |") + "\n"
  end
end
module BookKeeping
  VERSION = 3
end