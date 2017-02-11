using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

static class PrimeFactors
{
	private static string tempFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Temp");
	private static string primeCache = Path.Combine(tempFolder, "primes.txt");
	private static bool[] primes = null;
	private static List<int> Primes
	{
		get 
		{
			if (primes == null)
			{
				primes = new bool[1000000];
				if (File.Exists(primeCache))
				{
					var contents = File.ReadAllLines(primeCache).Select(l => int.Parse(l)).ToDictionary(i => i, i => i);
					for (int i = 0; i < primes.Length; i++)
						primes[i] = !contents.ContainsKey(i);

				}
				else
				{
					primes[0] = primes[1] = true;
					for (int i = 2; i < primes.Length; i++)
					{
						if (primes[i]) continue;
						primes[i] = false;
						var n = i * 2;
						while (n < primes.Length)
						{
							primes[n] = true;
							n += i;
						}
					}
					try
					{
						File.WriteAllLines(primeCache, Primes.Select(i => i.ToString()));
					}
					catch (UnauthorizedAccessException) { }
				}
			}
			return Enumerable.Range(0, primes.Length).Where(i => !primes[i]).ToList(); 
		}
	}
	static PrimeFactors()
	{
		
	}

	public static int[] For(long i)
	{
		var result = new List<int>();

		if (i > 1)
		{
			foreach (var prime in Primes)
			{
				while (i % prime == 0)
				{
					i /= prime;
					result.Add(prime);
				}
				if (i == 1) break;
			}
		}

		return result.ToArray();
	}
}
