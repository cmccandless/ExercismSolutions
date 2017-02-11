valid=set('+-* |')

def countMines(x,y,board):
    xmin,xmax=(max(0,x-1),min(x+2,len(board[y])))
    ymin,ymax=(max(0,y-1),min(y+2,len(board)))
    result=[c
        for r in board[ymin:ymax] 
        for c in r[xmin:xmax]
        if c=='*']
    return len(result) if len(result) > 0 else ' '

def board(inp):
    for i,r in enumerate(inp):
        if len(r)!=len(inp[0]): raise ValueError()
        if i==0 or i==len(inp)-1:
            if r!='+{}+'.format(''.join(['-']*(len(r)-2))): raise ValueError()
        elif r[0]!='|' or r[-1]!='|': raise ValueError()
        for c in r:
            if not c in valid: raise ValueError()
    b=[list(r) for r in inp]
    b=[''.join([c if c!=' ' else str(countMines(x,y,b))
        for x,c in enumerate(r)]) 
        for y,r in enumerate(b)]
    return b