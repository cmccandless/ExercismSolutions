def binary_search(a,x):
  p=0
  r=len(a)
  while p<r:
    q=int((r-p)/2)+p
    if a[q]==x: return q
    elif a[q]<x: 
      if p==q: raise ValueError()
      p=q
    else: r=q
  raise ValueError()
 