class BookStore
    def self.calculate_price(books)
       return 0 if books.empty?
       start = Grouping.new.add(books.shift)
       books.inject([start, start.dup]) { |t, b|
            sm, la = *t
            [[sm.add(b), la.add(b)].min, [sm.add(b, -1), la.add(b, -1)].min]
       }.min.total * 8.0
    end
end

class Grouping
    @@discount = [1.0, 1.0, 0.95, 0.9, 0.8, 0.75]
    attr_accessor :groups
    def initialize(groups=[[]])
        @groups=groups.sort_by { |g| g.size }
    end
    def total
        groups.collect { |g| groupCost(g) }.sum
    end
    def groupCost(group)
        group.size * @@discount[group.size]
    end
    def dup
        Grouping.new(groups.collect { |g| g.dup })
    end
    def add(b, index=0)
        other = dup
        valid = other.groups.reject { |g| g.member?(b) }
        valid.empty? ? other.groups.push([b]) : valid[index].push(b)
        other
    end
    def <=>(other)
        total <=> other.total
    end
end

module BookKeeping
    VERSION = 0
end
