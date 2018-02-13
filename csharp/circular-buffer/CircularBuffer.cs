using System;

public class CircularBuffer<T>
{
    private T[] buf;

    private int writePosition, readPosition;

    public readonly int Size;

    public int Length => writePosition - readPosition;

    public CircularBuffer(int size) => buf = new T[Size = size];

    private static TA AssertDo<TA>(bool c, Func<TA> f, string msg = "")
    {
        if (c) return f();
        throw new InvalidOperationException(msg);
    }

    private T WriteInternal(T x) => buf[writePosition++ % buf.Length] = x;

    public void Write(T x) => AssertDo(Length < buf.Length, () => WriteInternal(x));

    public void ForceWrite(T x)
    {
        if (Length == buf.Length) readPosition++;
        WriteInternal(x);
    }

    public T Read() => AssertDo(Length > 0, () => buf[readPosition++ % buf.Length]);

    public void Clear() => readPosition = writePosition;
}
