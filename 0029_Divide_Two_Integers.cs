// Statement: https://leetcode.com/problems/divide-two-integers/

using System;
using System.Collections.Generic;
using System.Linq;

//--------------------------------------------------------------------------------------------

// MinValue = -2147483648
// MaxValue =  2147483647
public class Solution
{
    public int Divide(int dividend, int divisor)
    {
        if (dividend == 0)
        {
            return 0;
        }
        int sign = (dividend < 0) != (divisor < 0) ? -1 : 1;
        if (divisor == int.MinValue)
        {
            if (dividend == int.MinValue)
            {
                return 1;
            }
            return 0;
        }
        int dividendAdd = 0;
        if (dividend == int.MinValue)
        {
            dividend++;
            dividendAdd = 1;
        }
        dividend = Math.Abs(dividend);
        divisor = Math.Abs(divisor);
        if (divisor == 1)
        {
            if (dividendAdd == 1 && sign == 1)
            {
                return int.MaxValue; // overflow
            }
            if (sign == -1)
            {
                dividend = -dividend - dividendAdd;
            }
            return dividend;
        }

        int ret = 0;
        int res1 = 1, div1 = divisor;
        while (div1 <= dividend - div1)
        {
            res1 <<= 1;
            div1 <<= 1;
        }
        for (; res1 > 0; res1 >>= 1, div1 >>= 1)
        {
            if (div1 <= dividend)
            {
                ret += res1;
                dividend -= div1;
            }
        }
        if (dividend + dividendAdd >= divisor)
        {
            ret++;
        }
        if (sign == -1)
            ret = -ret;
        return ret;
    }
}

//--------------------------------------------------------------------------------------------

class Program
{
    static void RunTest(int testIndex, int dividend, int divisor /*, int expectedResult*/)
    {
        Console.WriteLine($"Test {testIndex}.");

        //-------------------------------------------------

        long expectedResult = (long)dividend / divisor;
        if (expectedResult < int.MinValue || expectedResult > int.MaxValue)
        {
            expectedResult = int.MaxValue;
        }

        Solution sol = new Solution();
        int actualResult = sol.Divide(dividend, divisor);

        //-------------------------------------------------

        if (actualResult == expectedResult)
        {
            Console.WriteLine("PASSED.");
        } else
        {
            Console.WriteLine($"{nameof(dividend)}={dividend}, {nameof(divisor)}={divisor}");

            Console.WriteLine($"FAILED:");
            Console.WriteLine($"  Expected: {expectedResult}");
            Console.WriteLine($"  Actual  : {actualResult}");
        }
        Console.WriteLine();
    }

    static void Main(string[] args)
    {
        //GenTests();

        var watch = System.Diagnostics.Stopwatch.StartNew();

        RunTest(1, 10, 3);
        RunTest(2, 7, -3);
        RunTest(3, 0, 1);
        RunTest(4, 1, 1);

        RunTest(1001, -2147483648, 1);
        RunTest(1002, 2147483647, 1);
        RunTest(1003, -2147483648, -1);
        RunTest(1004, 2147483647, -1);

        RunTest(1005, 0, -2147483648);
        RunTest(1006, 0, 2147483647);

        RunTest(1007, -2147483648, 2147483647);
        RunTest(1008, 2147483647, -2147483648);

        RunTest(1009, 2147483647, -2147483647);
        RunTest(1010, -2147483647, 2147483647);
        RunTest(1011, 2147483647, 2147483647);
        RunTest(1012, -2147483647, -2147483647);

        watch.Stop();
        Console.WriteLine($"\nProgram execution time: {watch.ElapsedMilliseconds / 1000f:0.000} sec.");

    }
}
