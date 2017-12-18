def parse_binary(str):
    if any(d not in ['0', '1'] for d in str):
        raise ValueError('invalid digit')
    return sum([int(d) << i for i, d in enumerate(reversed(str))])
