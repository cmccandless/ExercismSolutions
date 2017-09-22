class TwoBucket
  def dbg(msg)
    print(msg)
  end
  def initialize(size1, size2, goal, goal_bucket)
    @sizes = [size1, size2]
    @goal = goal
    @goal_bucket = goal_bucket
    @goal_index = goal_bucket == "one" ? 0 : 1
    @other_bucket = 0
  end
  attr_reader :goal_bucket
  attr_reader :other_bucket
  def goal?(buckets)
    if buckets.include?(@goal)
      @goal_bucket = buckets.index(@goal) == 0 ? "one" : "two"
      return true
    end
    false
  end
  def empty(buckets, i)
    i == 0 ? [0, buckets[1]] : [buckets[0], 0]
  end
  def fill(buckets, i)
    i == 0 ? [@sizes[0], buckets[1]] : [buckets[0], @sizes[1]]
  end
  def consolidate(buckets, i)
    amount = [buckets[1 - i], @sizes[i] - buckets[i]].min
    target = buckets[i] + amount
    from = buckets[1 - i] - amount
    i == 0 ? [target, from] : [from, target]
  end
  def buckets_s(buckets)
    "#{buckets[0]},#{buckets[1]}"
  end
  def moves
    dbg("sizes=#{@sizes},goal=#{@goal},goal_bucket=#{@goal_bucket}\n")
    invalid = [0, 0]
    invalid[1 - @goal_index] = @sizes[1 - @goal_index]
    invalid_s = buckets_s(invalid)
    buckets = [0, 0]
    buckets[@goal_index] = @sizes[@goal_index]
    to_visit = []
    visited = {}
    count = 1
    until goal?(buckets)
      key = buckets_s(buckets)
      unless visited[key] || key == invalid_s
        dbg("#{key}(#{count})\n")
        visited[key] = true
        nc = count + 1
        [0, 1].each { |i|
          to_visit.push([empty(buckets, i), nc]) unless buckets[i] == 0
          unless buckets[i] == @sizes[i]
            to_visit.push([fill(buckets, i), nc])
            to_visit.push([consolidate(buckets, i), nc])
          end
        }
      end
      raise ArgumentError.new("no more moves!") if to_visit.empty?
      buckets, count = to_visit.shift
    end
    @other_bucket = buckets[1 - @goal_index]
    dbg("Solution(#{buckets}): #{count} moves\n")
    count
  end
end
module BookKeeping
  VERSION=3
end