class Integer
	def to_roman
		case
		when self >= 1000
			return 'M' + (self - 1000).to_roman
		when self >= 900
			return 'CM' + (self - 900).to_roman
		when self >= 500
			return 'D' + (self - 500).to_roman
		when self >= 400
			return 'CD' + (self - 400).to_roman
		when self >= 100
			return 'C' + (self - 100).to_roman
		when self >= 90
			return 'XC' + (self - 90).to_roman
		when self >= 50
			return 'L' + (self - 50).to_roman
		when self >= 40
			return 'XL' + (self - 40).to_roman
		when self >= 10
			return 'X' + (self - 10).to_roman
		when self >= 9
			return 'IX' + (self - 9).to_roman
		when self >= 5
			return 'V' + (self - 5).to_roman
		when self >= 4
			return 'IV' + (self - 4).to_roman
		when self >= 1
			return 'I' + (self - 1).to_roman
		else
			return ''
		end
	end
end
module BookKeeping
  VERSION = 2 # Where the version number matches the one in the test.
end