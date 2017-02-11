using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

public class DiffieHellman
{
	private static Random rand = new Random();
	public static BigInteger PublicKey(BigInteger primeP, BigInteger primeG, BigInteger privateKey)
	{
		return BigInteger.ModPow(primeG,privateKey,primeP);
	}
	public static BigInteger PrivateKey(BigInteger primeP)
	{
		var limit = (int)(primeP % int.MaxValue);
		return rand.Next(1,limit-1);
	}
	public static BigInteger Secret(BigInteger primeP, BigInteger publicKey, BigInteger privateKey)
	{
		return BigInteger.ModPow(publicKey,privateKey,primeP);
	}
}
