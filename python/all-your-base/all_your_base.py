from functools import reduce

def todecimal(ibase, bytes):
    return 0 if len(bytes) == 0 else reduce(lambda x, y: x * ibase + y, bytes)
    
def fromdecimal(x, obase):
    result = []
    while x > 0:
        x, r = divmod(x, obase)
        result.insert(0, r)
    return result
    

def rebase(ibase, bytes, obase):
    if ibase < 2 or obase < 2 or any(b < 0 or b >= ibase for b in bytes): raise ValueError()
    return fromdecimal(todecimal(ibase, bytes), obase)