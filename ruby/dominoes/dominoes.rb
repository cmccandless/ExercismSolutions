class Dominoes
  def self.chain(dominoes)
    return [] if dominoes.empty?
    dominoes.permutation { |perm|
      chain = perm[1..-1].reduce([perm[0]]) { |result, domino|
        case
        when result.nil?
          nil
        when result.size == 1 && result[0][0] == domino[0]
          [result[0].reverse, domino]
        when result.size == 1 && result[0][0] == domino[1]
          [result[0].reverse, domino.reverse]
        when result[-1][1] == domino[0]
          result + [domino]
        when result[-1][1] == domino[1]
          result + [domino.reverse]
        else
          nil
        end
      }
      return chain unless chain.nil? || chain[0][0] != chain[-1][1]
    }
    nil
  end
end
module BookKeeping
  VERSION = 1
end