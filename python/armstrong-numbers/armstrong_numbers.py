def is_armstrong(number):
    def pow_ndigits(digits):
        return (int(d) ** len(digits) for d in digits)
    return sum(pow_ndigits(str(number))) == number
