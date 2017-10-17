using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

static class Palindrome
{
	public static Product Smallest(int end)
	{
		return Smallest(1, end);
	}
	public static Product Smallest(int start, int end)
	{
		return GetPalindromes(start, end).Min();
	}
	public static Product Largest(int end)
	{
		return Largest(1, end);
	}
	public static Product Largest(int start, int end)
	{
		return GetPalindromes(start, end).Max();
	}

	private static IEnumerable<Product> GetPalindromes(int start, int end)
	{
		return from p in GetAllPalindromes(start, end)
			   from f in p.Factors
			   group f by p.Value into grp
			   select new Product(grp.Key) { Factors = grp.ToList() };
	}

	private static IEnumerable<Product> GetAllPalindromes(int start, int end)
	{
		for (int i = start; i <= end; i++)
		{
			for (int j = i; j <= end; j++)
			{
				var value = i * j;
				if (Product.IsValuePalindrome(value)) yield return new Product(i, j);
			}
		}
	}

	public class Product : IComparable
	{
		public int Value { get; private set; }
		public List<Tuple<int, int>> Factors { get; set; }
		public bool IsPalindrome
		{
			get
			{
				return IsValuePalindrome(Value);
			}
		}
		public Product(int value)
		{
			Value = value;
		}
		public Product(int a, int b)
		{
			Value = a * b;
			Factors = new[] { Tuple.Create(a, b) }.ToList();
		}

		public static bool IsValuePalindrome(int num)
		{
			int temp = num;
			int rem = 0;
			while (num > 0)
			{
				rem = rem * 10 + num % 10;
				num /= 10;
			}
			return temp == rem;
		}

		public int CompareTo(object obj)
		{
			var other = obj as Product;
			if (other == null) return 1;

			return this.Value.CompareTo(other.Value);
		}
	}
}
