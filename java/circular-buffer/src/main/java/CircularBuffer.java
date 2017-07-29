public class CircularBuffer<T> {
    private Object[] buf;
    private int r = 0, w = 0, length = 0;
    public CircularBuffer(int size) {
        buf = new Object[size];
    }
    private int increment(int i) { return (i + 1) % buf.length; }
    private T _read() {
        T x = (T)buf[r];
        r = increment(r);
        length--;
        return x;
    }
    private void _write(T x) {
        buf[w] = x;
        w = increment(w);
        length++;
    }
    public void clear() { w = r = length = 0; }
    public T read() throws BufferIOException {
        if (length == 0)
            throw new BufferIOException("Tried to read from empty buffer");
        return _read();
    }
    public void write(T x) throws BufferIOException {
        if (length == buf.length) 
            throw new BufferIOException("Tried to write to full buffer");
        _write(x);
    }
    public void overwrite(T x) {
        if (length == buf.length) _read();
        _write(x);
    }
}