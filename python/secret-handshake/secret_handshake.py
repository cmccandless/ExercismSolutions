codes=['wink','double blink','close your eyes','jump']

def handshake(value):
    try: 
        if any(not d in ['1','0'] for d in value): return []
    except TypeError: 
        if value<0: return []
        value='{:b}'.format(value)
    reverse=len(value)>len(codes)
    result=[codes[i] for i,v in enumerate(reversed(value[1 if reverse else 0:])) if v=='1']
    if reverse: result.reverse()
    return result
    
def code(seq):
    if any(not c in codes for c in seq): return '0'
    return str(int(''.join(['0' if [c for c in codes if c in seq]==seq else '1',
        ''.join(reversed(['1' if c in seq else '0' for c in codes]))])))