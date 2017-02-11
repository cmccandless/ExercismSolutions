a=ord('A')
def make_diamond(c):
  d = ord(c)
  w = d - a
  lines = []
  for i in range(a, d+1):
    x = i - a
    outer = ' ' * (w - x)
    inner = ' ' * x
    s = outer + chr(i) + inner
    lines += [s + ''.join(reversed(s[:-1]))]
  lines += reversed(lines[:-1])
  return '\n'.join(lines) + '\n'