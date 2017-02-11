
static class NthPrime
	{
		public static int Nth(int n)
		{
			var isNotPrime = new bool[(n+1)*100];
			var primeCount = 0;
			for (int i = 2; i < isNotPrime.Length; i++)
			{
				if (isNotPrime[i]) continue;
				primeCount++;
				if (primeCount == n) return i;
				for (int j = 2 * i; j < isNotPrime.Length; j += i)
				{
					isNotPrime[j] = true;
				}
			}
			return 0;
		}
	}
