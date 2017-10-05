using System;

public static class CollatzConjecture
{
    public static int Steps(int number) 
    {
        if (number < 1) throw new ArgumentException();
        int count;
        for (count = 0; number != 1; count++)
            number = number % 2 == 0 ? number / 2 : number * 3 + 1;
        return count;
    }
}