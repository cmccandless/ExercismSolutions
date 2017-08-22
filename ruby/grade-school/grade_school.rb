class School
  def initialize
    @roster = Hash.new([])
  end
  def students(grade)
    @roster[grade]
  end
  def add(name, grade)
    @roster[grade] = Array.new(@roster[grade]).push(name).sort
  end
  def students_by_grade
    @roster.to_a.sort.collect { |a| {:grade => a[0], :students => a[1] } }
  end
end
module BookKeeping
  VERSION = 3 # Where the version number matches the one in the test.
end