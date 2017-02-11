using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CircularBuffer<T>
{
	private T[] buf;
	private int writePosition = 0;
	private int readPosition = 0;
	private int length = 0;
	public CircularBuffer(int size) { this.buf = new T[size]; }
	public void Write(T x)
	{
		if (length == buf.Length) throw new InvalidOperationException();
		buf[writePosition++ % buf.Length] = x;
		length++;
	}
	public void ForceWrite(T x)
	{
		if (length == buf.Length) readPosition++;
		buf[writePosition++ % buf.Length] = x;
		length = Math.Min(length + 1, buf.Length);
	}
	public T Read()
	{
		if (readPosition == writePosition) throw new InvalidOperationException();
		length--;
		return buf[readPosition++ % buf.Length];
	}
	public void Clear()
	{
		readPosition = writePosition = length = 0;
	}
}
