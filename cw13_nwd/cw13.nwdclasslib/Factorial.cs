using System;

namespace cw13.nwdclasslib;

public class Factorial
{
    public int Calculate(int a)
    {
        if (a < 0)
        {
            throw new ArgumentException("a cant be negtive");
        }
        int result = 1;
        for (int i = 1; i < a; i++)
        {
            result *= i + 1;
        }
        return result;
    }
}
