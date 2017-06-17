def count(lines=''):
    corners = [(x, y) for y in range(len(lines))
               for x in range(len(lines[y]))
               if lines[y][x] == '+']
    rectangles = [(a, b, c, (b[0], c[1])) for a in corners
                  for b in corners
                  if a[1] == b[1] and a[0] < b[0] and
                  all(ch in '+-' for ch in lines[a[1]][a[0] + 1: b[0]])
                  for c in corners
                  if a[0] == c[0] and a[1] < c[1] and
                  all(line[a[0]] in '+|' for line in lines[a[1] + 1: c[1]]) and
                  (b[0], c[1]) in corners and
                  all(ch in '+-' for ch in lines[c[1]][c[0] + 1: b[0]]) and
                  all(line[b[0]] in '+|' for line in lines[b[1] + 1: c[1]])]
    return len(rectangles)
