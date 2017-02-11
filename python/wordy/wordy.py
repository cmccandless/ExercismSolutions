op={
    'plus':lambda x,y: x+y,
    'minus':lambda x,y: x-y,
    'multiplied':lambda x,y: x*y,
    'divided':lambda x,y: x/y,
}

def calculate(expr):
    s=list(reversed(expr[:-1].split()[2:]))
    r,o=(0,op['plus'])
    while len(s)>0:
        x=s.pop()
        try: r,o=(o(r,int(x)),None)
        except TypeError: raise ValueError()
        except ValueError: 
            if o!=None: raise ValueError()
            try: o=op[x]
            except KeyError: raise ValueError()
            if x=='multiplied' or x=='divided': s.pop()
    return r
    