using System;

public static class LargestSeriesProduct
{
    public static long GetLargestProduct(string series, int span)
    {
        if (span < 0 || span > series.Length) throw new ArgumentException();
        if (span == 0) return 1;
        var max = 0L;
        var slots = new long[span];
        for (int i=0;i<series.Length;i++)
        {
            if (!char.IsDigit(series[i])) throw new ArgumentException();
            var x = series[i] - 48L;
            slots[i % span] = x;
            var limit = i - span + 1;
            for (int j=i-1;j>=0 && j >= limit; j--)
                slots[j % span] *= x;
            if (limit >= 0 && slots[limit % span] > max)
                max = slots[limit % span];
        }
        return max;
    }
}
