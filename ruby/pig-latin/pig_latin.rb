class PigLatin
  @@exceptions = "ytt|xr"
  def self.translate(phrase)
    phrase.split(" ")
          .collect { |word| 
            prefix = word[/^(?!#{@@exceptions})[^aeiou]+((?<=q)u?)?/] || ""
            suffix = word[/(#{@@exceptions}|[aeio]|(?<!q)u).*$/]
            suffix + prefix + "ay"
          }
          .join(" ")
  end
end
module BookKeeping
  VERSION = 1 # Where the version number matches the one in the test.
end