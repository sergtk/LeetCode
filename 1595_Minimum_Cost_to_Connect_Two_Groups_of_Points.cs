using System;
using System.Collections.Generic;
using System.Diagnostics;

//--------------------------------------------------------------------------------------------

// Ref: https://leetcode.com/problems/minimum-cost-to-connect-two-groups-of-points/
public class Solution
{
    public int ConnectTwoGroups(IList<IList<int>> cost)
    {
        int inf = 1111000000;
        int n = cost.Count;
        int m = cost[0].Count;

        int[,] dp = new int[n + 1, 1 << m];
        for (int ii = 0; ii <= n; ii++)
        {
            for (int maskj = 0; maskj < (1 << m); maskj++)
            {
                dp[ii, maskj] = inf;
            }
        }
        dp[0, 0] = 0;

        for (int ii = 0; ii <= n; ii++)
        {
            for (int maskj = 0; maskj < (1 << m); maskj++)
            {
                if ((ii == 0) != (maskj == 0))
                    continue;
                for (int i = 0; i < Math.Min(ii + 1, n); i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        if (i < ii && (maskj & (1 << j)) > 0)
                        {
                            // nothing new
                            continue;
                        }

                        int maskj1 = maskj | 1 << j;
                        int ii1 = Math.Max(ii, i + 1);
                        int cur = dp[ii, maskj] + cost[i][j];
                        if (dp[ii1, maskj1] > cur)
                        {
                            dp[ii1, maskj1] = cur;
                        }
                    }
                }
            }
        }

        int ret = dp[n, (1 << m) - 1];
        return ret;
    }
}

//--------------------------------------------------------------------------------------------

class Program
{
    static void RunTest(int testIndex, int[,] inputArray, int expectedResult)
    {
        Console.WriteLine($"Test {testIndex}.");

        IList<IList<int>> input = new List<IList<int>>();
        for (int i = 0; i < inputArray.GetLength(0); i++) {
            var row = new List<int>();
            input.Add(row);
            for (int j = 0; j < inputArray.GetLength(1); j++) {
                row.Add(inputArray[i, j]);
            }
        }

        //-------------------------------------------------

        Solution sol = new Solution();
        double actualResult = sol.ConnectTwoGroups(input);

        //-------------------------------------------------

        if (actualResult == expectedResult)
        {
            Console.WriteLine("PASSED.");
        } else
        {
            Console.WriteLine($"{Util.ToString(input)}");

            Console.WriteLine($"FAILED:");
            Console.WriteLine($"  Expected: {expectedResult}");
            Console.WriteLine($"  Actual  : {actualResult}");
        }
        Console.WriteLine();
    }

    static void Main(string[] args)
    {
        var watch = System.Diagnostics.Stopwatch.StartNew();

        RunTest(1, new int[,] { { 15, 96}, { 36, 2} }, 17);
        RunTest(2, new int[,] { { 1, 3, 5 }, { 4, 1, 1 }, { 1, 5, 3 } }, 4);
        RunTest(3, new int[,] { { 2, 5, 1 }, { 3, 4, 7 }, { 8, 1, 2 }, { 6, 2, 4 }, { 3, 8, 8 } }, 10);

        RunTest(51, new int[,] { { 41, 33, 96 }, { 6, 32, 44 }, { 64, 76, 67 }, { 1, 64, 40 }, { 14, 13, 16 }, { 12, 93, 33 } }, 132);
        RunTest(72, new int[,] { { 99, 44, 34, 99, 67, 59, 97, 62, 82 }, { 77, 57, 37, 2, 74, 28, 80, 11, 100 }, { 35, 14, 55, 92, 7, 50, 68, 31, 11 },
            { 96, 68, 32, 96, 55, 26, 29, 0, 45 }, { 25, 11, 62, 87, 48, 78, 68, 32, 54 }, { 20, 34, 94, 38, 7, 74, 66, 3, 45 },
            { 46, 76, 73, 90, 21, 32, 88, 89, 60 }, { 75, 34, 20, 69, 91, 8, 69, 73, 54 }, { 34, 45, 28, 5, 69, 53, 72, 1, 34 },
            { 18, 63, 89, 29, 66, 11, 33, 90, 54 } }, 138);

        watch.Stop();
        Console.WriteLine($"\nProgram execution time: {watch.ElapsedMilliseconds / 1000f:0.000} sec.");

    }
}
