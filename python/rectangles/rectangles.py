def count(lines=''):
    def vertLine(x, y, w, z):
        return all(line[x] in '+|' for line in lines[y + 1: z])

    def horizLine(x, y, w, z):
        return all(ch in '+-' for ch in lines[y][x + 1: w])

    corners = [(x, y) for y in range(len(lines))
               for x in range(len(lines[y]))
               if lines[y][x] == '+']
    rectangles = [(a, b, c, (b[0], c[1])) for a in corners
                  for b in corners
                  if a[1] == b[1] and a[0] < b[0] and horizLine(*a, *b)
                  for c in corners
                  if a[0] == c[0] and a[1] < c[1] and vertLine(*a, *c) and
                  (b[0], c[1]) in corners and
                  horizLine(*b, *c) and
                  vertLine(*b, *c)]
    return len(rectangles)
