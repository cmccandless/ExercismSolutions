using System;

namespace Exercism.circular_buffer
{
    public class CircularBuffer<T>
    {
        private T[] buf;
        private int writePosition = 0;
        private int readPosition = 0;
        private int length => writePosition - readPosition;
        public CircularBuffer(int size) { buf = new T[size]; }
        public void Write(T x)
        {
            if (length == buf.Length) throw new InvalidOperationException();
            buf[writePosition++ % buf.Length] = x;
        }
        public void ForceWrite(T x)
        {
            if (length == buf.Length) readPosition++;
            buf[writePosition++ % buf.Length] = x;
        }
        public T Read()
        {
            if (length == 0) throw new InvalidOperationException();
            return buf[readPosition++ % buf.Length];
        }
        public void Clear() => readPosition = writePosition = 0;
    }
}
