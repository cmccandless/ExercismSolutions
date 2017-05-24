def readlines(filename):
    with open(filename, 'r') as f: return f.readlines()
        
def getOpts(opts):
    return ('-n' in opts, '-l' in opts, '-i' in opts, '-v' in opts, '-x' in opts)
        
def contains(line, s, ignoreCase, full):
    if ignoreCase: line, s = (line.lower(),s.lower())
    return s + '\n' == line if full else s in line
        
def label(s, c): return s + ':' if c else ''
        
def format(line, file, i, fnames, nums):
    return label(file, fnames) + label(str(i), nums) + line
    
def grep(s, files, opts = ''):
    nums, fileOnly, ignoreCase, invert, full = getOpts(opts)
    fnames = len(files) > 1
    result = [file if fileOnly else format(line, file, i+1, fnames, nums)
        for file in files 
        for i, line in enumerate(readlines(file)) 
        if contains(line, s, ignoreCase, full) != invert]
    if fileOnly: return ''.join(f + '\n' for f in files if f in result)
    return ''.join(result)