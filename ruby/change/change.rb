class Change
  def self.generate(coins, total_change)
    return -1 if total_change < 0 || coins.any? { |x| x < 1 }
    m = [[]] + [nil] * total_change
    coins.size
         .times
         .to_a
         .product((1..m.size - 1).to_a)
         .each { |c, t|
           if coins[c] == t
             m[t] = [coins[c]]
           else
             (1..t - 1).select { |t2| coins[c] + t2 == t }
                       .reject { |t2| m[t2].nil? }
                       .each { |t2| 
                         m[t] = m[t2] + [coins[c]] if m[t].nil? || m[t2].size + 1 < m[t].size 
                       }
           end
         }
    m[-1].nil? ? -1 : m[-1]
  end
end
module BookKeeping
  VERSION = 2
end