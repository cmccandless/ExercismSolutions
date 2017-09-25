class Scale
  def self.keys(tonic)
    tonic =~ /^([A-EGabe]|[Fcdfg]#)$/ ?
    %w(A A# B C C# D D# E F F# G G#) :
    %w(A Bb B C Db D Eb E F Gb G Ab)
  end
  def self.intervals(name)
    case name
    when :chromatic
     "mmmmmmmmmmmm"
    when :major
     "MMmMMMmM"
    when :minor
     "MmMMMmMM"
    end
  end
  def self.pitches(tonic, intervals)
    keys = Scale.keys(tonic)
    intervals.tr("_mMA","0123")
             .chars
             .collect(&:to_i)
             .reduce([tonic.capitalize]) { |pitches, step|
               pitches.push(keys[(keys.index(pitches[-1]) + step) % keys.size])
             }
  end
  def initialize(tonic, name, intervals=nil)
    @name = "#{tonic.capitalize} #{name}"
    @pitches = Scale.pitches(tonic, (intervals || Scale.intervals(name))[0..-2])
  end
  attr_reader :name
  attr_reader :pitches
end
module BookKeeping
  VERSION=1
end