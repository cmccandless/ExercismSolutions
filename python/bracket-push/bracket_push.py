open=['{','[','(']
close=['}',']',')']

def check_brackets(str,d=0):
    if len(str)==0: return True
    s=list(reversed(str))
    so=[]
    while len(s)>0:
        try: a=so.pop()
        except IndexError: a=s.pop()
        try: i=open.index(a)
        except ValueError: return False
        b=s.pop()
        try:
            j=open.index(b)
            so.append(a)
            so.append(b)
        except ValueError:
            try: 
                j=close.index(b)
                if i!=j: return False
            except ValueError: return False
    return len(so)==0