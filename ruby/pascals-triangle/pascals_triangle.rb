class Triangle
  def initialize(rows)
    @rows = rows
  end
  def rows
    rs = [[1]]
    (2..@rows).each { |_|
      rs.push((0..rs[-1].size - 1).collect { |i| 
                                    rs[-1][i, 2].sum
                                  }.unshift(1))
    }
    rs
  end
end