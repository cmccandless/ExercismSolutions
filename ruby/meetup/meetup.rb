require 'date'
class Meetup
  def initialize(month, year)
    @month = month
    @year = year
  end
  def day(dayOfWeek, schedule)
    nToDay = [:sunday, :monday, :tuesday, :wednesday, :thursday, :friday, :saturday]
    nth = [:first, :second, :third, :fourth]
    d = Date.new(@year, @month, 1)
    n = case schedule
    when :teenth
      d += 12
      0
    when :last
      d = (d >> 1) - 7
      0
    else
      nth.index(schedule)
    end
    while nToDay[d.wday] != dayOfWeek
      d += 1
    end
    d += 7 * n
  end
end