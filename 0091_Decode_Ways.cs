using System;
using System.Collections.Generic;
using System.Linq;

//--------------------------------------------------------------------------------------------

// Problem statement: https://leetcode.com/problems/decode-ways/submissions/

public class Solution {
    public int NumDecodings(string s) {
        int n = s.Length;
        var mem = new int[n+1];
        mem[0] = 1;
        for (int l = 1; l <= n; l++) {
            int cur = 0;
            if (s[l-1] > '0') cur += mem[l-1];
            if (l > 1 && s[l-2] > '0') {
                int cur1 = (s[l-2] - '0') * 10 + s[l-1] - '0';
                if (cur1 <= 26) {
                    cur += mem[l-2];
                }
            }
            mem[l] = cur;
        }
        int ret = mem[n];
        return ret;
    }
}
//--------------------------------------------------------------------------------------------

class Program
{
    static void RunTest(int testIndex, string s, int expectedResult)
    {
        Console.WriteLine($"Test {testIndex}.");

        //-------------------------------------------------

        Solution sol = new Solution();
        int actualResult = sol.NumDecodings(s);

        //-------------------------------------------------

        if (actualResult == expectedResult)
        {
            Console.WriteLine("PASSED.");
        } else
        {
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

        RunTest(1, "12", 2);
        RunTest(2, "226", 3);
        RunTest(3, "0", 0);
        RunTest(4, "06", 0);

        watch.Stop();
        Console.WriteLine($"\nProgram execution time: {watch.ElapsedMilliseconds / 1000f:0.000} sec.");

    }
}
