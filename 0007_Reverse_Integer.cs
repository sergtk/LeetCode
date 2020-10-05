using System;
using System.Collections.Generic;
using System.Diagnostics;

public class Solution
{
    public int Reverse(int x)
    {
        if (x == 0)
            return 0;
        List<int> limDigs = new List<int>();
        int lim = x < 0 ? int.MinValue : int.MaxValue;
        bool neg = x < 0;
        while (lim != 0)
        {
            limDigs.Add(Math.Abs(lim % 10));
            lim /= 10;
        }
        List<int> xDigs = new List<int>();
        while (x != 0)
        {
            xDigs.Add(Math.Abs(x % 10));
            x /= 10;
        }
        //Console.WriteLine($"xDigs.Count == {xDigs.Count}");

        xDigs.Reverse();
        while (xDigs[xDigs.Count - 1] == 0)
        {
            //Console.WriteLine($"dig {xDigs[xDigs.Count - 1]}");
            xDigs.RemoveAt(xDigs.Count - 1);
        }

        if (limDigs.Count < xDigs.Count)
            return 0;
        bool ok = false;
        if (limDigs.Count > xDigs.Count)
            ok = true;

        int ret = 0;
        for (int i = xDigs.Count - 1; i >= 0; i--)
        {
            if (xDigs[i] > limDigs[i] && !ok)
                return 0;
            if (xDigs[i] < limDigs[i])
                ok = true;
            ret = ret * 10 + xDigs[i];
        }
        if (neg)
            ret = -ret;
        return ret;
    }
}

class Program
{
    static void RunTest(int testIndex, int input, int expectedResult)
    {
        Console.WriteLine($"Test {testIndex}.");

        //-------------------------------------------------

        Solution sol = new Solution();
        double actualResult = sol.Reverse(input);

        //-------------------------------------------------

        if (actualResult == expectedResult)
        {
            Console.WriteLine("PASSED.");
        } else
        {
            Console.WriteLine($"{input}");

            Console.WriteLine($"FAILED:");
            Console.WriteLine($"  Expected: {expectedResult}");
            Console.WriteLine($"  Actual  : {actualResult}");
        }
        Console.WriteLine();
    }

    static void Main(string[] args)
    {
        int v = int.MinValue;
        int p = -v;
        int a = v % 10;
        int b = v / 10;

        var watch = System.Diagnostics.Stopwatch.StartNew();

        RunTest(1, 123, 321);
        RunTest(2, -123, -321);
        RunTest(3, 120, 21);

        RunTest(-1, int.MinValue, 0);
        RunTest(-2, int.MaxValue, 0);

        watch.Stop();
        Console.WriteLine($"\nProgram execution time: {watch.ElapsedMilliseconds / 1000f:0.000} sec.");

    }
}
