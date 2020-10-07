using System;
using System.Collections.Generic;
using System.Linq;


// Ref: "1240. Tiling a Rectangle with the Fewest Squares" https://leetcode.com/problems/tiling-a-rectangle-with-the-fewest-squares/ 

// Good discussion and many interesting links on the subject:
// https://leetcode.com/problems/tiling-a-rectangle-with-the-fewest-squares/discuss/414804/A-Mathematical-Review%3A-Why-This-Problem-Is-a-Tip-of-the-Iceberg

// Ref: https://stackoverflow.com/questions/18975044/keep-number-longer-than-64-bit-long
// Note, to pass LeedCode test BigInteger can be replaced with long.
// BigInteger allows to test solution for wider input data

//--------------------------------------------------------------------------------------------

using System.Diagnostics;
using System.Numerics;

public class Solution
{

    const int inf = 123123;

    int n_, m_;
    Dictionary<BigInteger, int> memSkyline_;

    private BigInteger EncodeSpace(int[] space)
    {
        BigInteger ret = 0;

        int i = 0;
        while (i < space.Length && space[i] == 0) i++;
        if (i == space.Length) return 0;

        int mul = m_ + 1;
        for (; i < space.Length; i++)
        {
            //Debug.Assert(ret < (long.MaxValue - space[i]) / mul);
            ret = ret * mul + space[i];
        }
        return ret;
    }


    private static void ConsoleWriteLine(string s)
    {
        Console.WriteLine(s);
    }

    int CalcSkyline(int[] space, int firstNonZeroPos, int lim)
    {
        int sc = space.Length;
        //string spaceString = string.Join(", ", space);
        //ConsoleWriteLine($"CalcSkyline({{{spaceString}}}, {firstNonZeroPos}, lim={lim}) start");

        if (firstNonZeroPos < space.Length && space[firstNonZeroPos] == 0)
        {
            throw new Exception("Inconsistent firstNonZeroPos & space");
        }
        if (lim < 0) return inf;
        if (firstNonZeroPos == space.Length) return 0;
        if (firstNonZeroPos == space.Length - 1) return space[space.Length - 1];

        BigInteger spaceCode = EncodeSpace(space);
        int ret1;
        if (memSkyline_.TryGetValue(spaceCode, out ret1)) {
            return ret1;
        }

        //ConsoleWriteLine($"CalcSkyline({{{spaceString}}}, {firstNonZeroPos}) main body");

        int firstPos = firstNonZeroPos;
        int ret = lim;
        //int ret = inf;
        while (firstPos < sc)
        {

            int maxWidth = 1;
            while (maxWidth + firstPos < sc && space[firstPos + maxWidth - 1] == space[firstPos + maxWidth])
            {
                maxWidth++;
            }

            int maxSize = Math.Min(maxWidth, space[firstPos]);
            int minSize = 1;
            if (firstPos > firstNonZeroPos)
            {
                maxSize = Math.Min(maxSize, space[firstPos] - space[firstPos - 1]);
                minSize = maxSize;
            }

            for (int size = maxSize; size >= minSize; size--)
            {

                for (int i = firstPos; i < firstPos + size; i++)
                {
                    //Console.WriteLine($"firstPos = {firstPos}, i = {i}, space.Count = {space.Count}");
                    space[i] -= size;
                }

                int firstNonZeroPos1 = firstNonZeroPos;
                if (firstPos == firstNonZeroPos && space[firstNonZeroPos] == 0)
                {
                    firstNonZeroPos1 += size;
                }

                //string space1 = string.Join(", ", space);
                //ConsoleWriteLine($" before call CalcSkyline: (space={{{space1}}}, firstNonZeroPos1={firstNonZeroPos1}, lim(ret-1)={ret-1}, false)");
                int cur = CalcSkyline(space, firstNonZeroPos1, ret - 1) + 1;
                if (cur < ret)
                {
                    ret = cur;
                }

                for (int i = firstPos; i < firstPos + size; i++)
                {
                    space[i] += size;
                }
            }

            firstPos++;
            while (firstPos < sc && space[firstPos] == space[firstPos - 1])
            {
                firstPos++;
            }
        }

        if (ret < lim)
        {
            //Debug.Assert(!memSkyline_.ContainsKey(spaceCode));
            memSkyline_.Add(spaceCode, ret);
        }

        //ConsoleWriteLine($"CalcSkyline({{{spaceString}}}) => {ret}");
        return ret;
    }

    public int TilingRectangle(int n, int m)
    {
        if (n > m)
        {
            (n, m) = (m, n);
        }

        n_ = n;
        m_ = m;

        //memSkyline_ = new Dictionary<int[], int>(new IntArrayEqualityComparer());
        memSkyline_ = new Dictionary<BigInteger, int>();

        //int ret = CalcRect(n_, m_, inf);
        int[] space = Enumerable.Repeat<int>(n_, m_).ToArray();
        int ret = CalcSkyline(space, 0, inf);
        return ret;
    }
}
//--------------------------------------------------------------------------------------------

class Program
{
    static void RunTest(int testIndex, int n, int m, int expectedResult)
    {
        Console.WriteLine($"Test {testIndex}.");

        //-------------------------------------------------

        Solution sol = new Solution();
        double actualResult = sol.TilingRectangle(n, m);

        //-------------------------------------------------

        if (actualResult == expectedResult)
        {
            Console.WriteLine("PASSED.");
        } else
        {
            Console.WriteLine($"n={n}, m={m}");

            Console.WriteLine($"FAILED:");
            Console.WriteLine($"  Expected: {expectedResult}");
            Console.WriteLine($"  Actual  : {actualResult}");
        }
        Console.WriteLine();
    }

    static int GCD(int a, int b)
    {
        while (a % b != 0)
        {
            int t = a;
            a = b;
            b = t % a;
        }
        return b;
    }


    static void GenTests()
    {
        int testIndex = 100000;
        for (int n = 2; n <= 13; n++)
        {
            for (int m = 2; m <= n; m++)
            {
                if (GCD(n, m) > 1)
                {
                    continue;
                }

                Solution sol = new Solution();
                double actualResult = sol.TilingRectangle(n, m);
                Console.WriteLine($"RunTest({testIndex}, {n}, {m}, {actualResult});");
                testIndex++;
            }
        }
    }


    static void Main(string[] args)
    {
        //GenTests();

        var watch = System.Diagnostics.Stopwatch.StartNew();

        RunTest(1, 2, 3, 3);
        RunTest(2, 5, 8, 5);
        RunTest(3, 11, 13, 6);

        RunTest(27, 11, 10, 6);
        RunTest(-27, 10, 11, 6);

        RunTest(35, 10, 9, 6);

        // Test is out of task constraints.
        RunTest(-1, 16, 17, 8);

        // Generated tests
        bool runGeneratedTests = false;
        if (runGeneratedTests)
        {
            RunTest(100000, 3, 2, 3);
            RunTest(100001, 4, 3, 4);
            RunTest(100002, 5, 2, 4);
            RunTest(100003, 5, 3, 4);
            RunTest(100004, 5, 4, 5);
            RunTest(100005, 6, 5, 5);
            RunTest(100006, 7, 2, 5);
            RunTest(100007, 7, 3, 5);
            RunTest(100008, 7, 4, 5);
            RunTest(100009, 7, 5, 5);
            RunTest(100010, 7, 6, 5);
            RunTest(100011, 8, 3, 5);
            RunTest(100012, 8, 5, 5);
            RunTest(100013, 8, 7, 7);
            RunTest(100014, 9, 2, 6);
            RunTest(100015, 9, 4, 6);
            RunTest(100016, 9, 5, 6);
            RunTest(100017, 9, 7, 6);
            RunTest(100018, 9, 8, 7);
            RunTest(100019, 10, 3, 6);
            RunTest(100020, 10, 7, 6);
            RunTest(100021, 10, 9, 6);
            RunTest(100022, 11, 2, 7);
            RunTest(100023, 11, 3, 6);
            RunTest(100024, 11, 4, 6);
            RunTest(100025, 11, 5, 6);
            RunTest(100026, 11, 6, 6);
            RunTest(100027, 11, 7, 6);
            RunTest(100028, 11, 8, 6);
            RunTest(100029, 11, 9, 7);
            RunTest(100030, 11, 10, 6);
            RunTest(100031, 12, 5, 6);
            RunTest(100032, 12, 7, 6);
            RunTest(100033, 12, 11, 7);
            RunTest(100034, 13, 2, 8);
            RunTest(100035, 13, 3, 7);
            RunTest(100036, 13, 4, 7);
            RunTest(100037, 13, 5, 6);
            RunTest(100038, 13, 6, 6);
            RunTest(100039, 13, 7, 6);
            RunTest(100040, 13, 8, 6);
            RunTest(100041, 13, 9, 7);
            RunTest(100042, 13, 10, 7);
            RunTest(100043, 13, 11, 6);
            RunTest(100044, 13, 12, 7);
        }

        watch.Stop();
        Console.WriteLine($"\nProgram execution time: {watch.ElapsedMilliseconds / 1000f:0.000} sec.");

    }
}
