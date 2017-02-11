from functools import reduce

segments={
    (0,1):('_',set('02356789')),
    (1,0):('|',set('045689')),
    (1,1):('_',set('2345689')),
    (1,2):('|',set('01234789')),
    (2,0):('|',set('0268')),
    (2,1):('_',set('0235689')),
    (2,2):('|',set('013456789')),
}

def grid(nums):
    return [''.join([''.join([c
        for c in [' ' if not b or not n in q[1] else q[0]
        for p,b,q in [(p,b,None if not b else segments[p])
        for p,b in [(p,p in segments)
        for p in [(y,x) for x in range(3)]]]]]) 
        for n,i in [(n,int(n)) for n in nums]]) 
        for y in range(3)]+['   '*len(nums)]
    
def intersect(a,b):
    return set([x for x in a if x in b])
    
def subtract(a,b):
    return set([x for x in a if not x in b])
    
def number(nums):
    if len(nums)<4: raise ValueError()
    for line in nums:
        if len(line)!=len(nums[0]): raise ValueError()
    return ''.join(['?' if b or len(ns)==0 else ns.pop() 
        for ns,b in [(reduce(lambda a,b: (intersect(a,b[0]) if b[1] else 
                subtract(a,b[0])),
            [(s,n[y][x]==c) for y,x,c,s in [(p[0],p[1],r[0],r[1]) 
                for p,r in segments.items()]],
            set('0123456789')),set(n[-1])!=set(' ')) 
        for n in [[x[i:i+3] for x in nums] for i in range(0,len(nums[0]),3)]]])