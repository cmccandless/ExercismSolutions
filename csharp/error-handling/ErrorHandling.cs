using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class ErrorHandling
{
	public static void HandleErrorByThrowingException()
	{
		throw new Exception();
	}
	public static int? HandleErrorByReturningNullableType(string num)
	{
		try
		{
			return (int?)int.Parse(num);
		}
		catch (Exception)
		{
			return null;
		}
	}
	public static bool HandleErrorWithOutParam(string num, out int result)
	{
		result = 0;
		try
		{
			result= int.Parse(num);
			return true;
		}
		catch (Exception)
		{
			return false;
		}
	}
	public static bool DisposableResourcesAreDisposedWhenExceptionIsThrown(IDisposable disp)
	{
		try
		{
			int.Parse("a");
			return true;
		}
		catch (FormatException)
		{
			disp.Dispose();
			throw new Exception();
		}
	}
}
