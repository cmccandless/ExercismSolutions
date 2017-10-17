using System;
using System.Collections.Generic;
using System.Linq;

public class VariableLengthQuantity
{
    private static uint[] ToBytes(uint i) =>
        (from j in Enumerable.Range(0, 5)
            let highBit = (j == 0 ? 0x0u : 0x80)
            select ((i >> (j * 7)) & 0x7f) | highBit)
        .Reverse()
        .SkipWhile(x => x == 0x80)
        .ToArray();

    public static uint[] ToBytes(uint[] inputs) =>
        inputs.SelectMany(ToBytes).ToArray();

    public static uint[] FromBytes(uint[] inputs)
    {
        var results = new List<uint>();
        var indexed = inputs.Select((x, i) => new { x, i });
        while (indexed.Any())
        {
            var grp = indexed.TakeWhile((t, j) => j == 0 ||
                (inputs[t.i - 1] & 0x80) > 0).Select(t => t.x).ToArray();
            if (grp.Length == 5 && grp.First() >= 0xa0)
                throw new InvalidOperationException("Overflow");
            if (grp.Length == indexed.Count() && grp.Last() >= 0x80)
                throw new InvalidOperationException("Incomplete sequence");
            var val = grp.Aggregate(0u, (a, x) => (a << 7) | (x & 0x7f));
            results.Add(val);
            indexed = indexed.Skip(grp.Length);
        }
        return results.ToArray();
    }
}
