using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercism.variable_length_quantity
{
	public class VariableLengthQuantity
	{
		public static uint[] ToBytes(uint[] inputs)
		{
			return inputs.SelectMany(i =>
				{
					var bytes = new Stack<uint>();
					do
					{
						var x = i & 0x7Fu;
						i >>= 7;
						if (bytes.Count > 0) x |= 0x80;
						bytes.Push(x);
					} while (i > 0);
					return bytes;
				}).ToArray();
		}
		public static uint[] FromBytes(uint[] inputs)
		{
			var q = new Queue<uint>(inputs);
			var results = new List<uint>();
			var current = 0u;
			var usedBits = 0;
			var needNext = false;
			while (q.Any())
			{
				var i = q.Dequeue();
				current |= (i & 0x7F);
				var isFirst = !needNext;
				needNext = (i & 0x80) > 0;
				if (needNext)
				{
					if (isFirst) for (usedBits = 0; (1 << usedBits) <= current; usedBits++) { }
					else usedBits += 7;
					if (usedBits > 32) throw new Exception("Overflow");
					current <<= 7;
				}
				else
				{
					if (usedBits > 25) throw new Exception("Overflow");
					results.Add(current);
					current = 0;
				}
			}
			if (needNext) throw new Exception("Incomplete sequence");
			return results.ToArray();
		}
	}
}
