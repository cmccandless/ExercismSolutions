using System;

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
            return int.Parse(num);
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
            result = int.Parse(num);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
    public static bool DisposableResourcesAreDisposedWhenExceptionIsThrown(IDisposable disp)
    {
        using (disp) throw new Exception();
    }
}
