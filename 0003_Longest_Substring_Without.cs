using System;
using System.Diagnostics;

namespace AlgoLeetCode_CSharp
{
    public class Solution
    {
        public int LengthOfLongestSubstring(string s)
        {
            if (s.Length == 0)
                return 0;
            int ret = 1;

            bool[] occur = new bool[256];

            int tail = -1;
            for (int head = 0; head < s.Length; head++)
            {
                if (occur[s[head]])
                {
                    tail++;
                    Debug.Assert(occur[s[tail]]);
                    occur[s[tail]] = false;
                    while (s[tail] != s[head])
                    {
                        tail++;
                        Debug.Assert(occur[s[tail]]);
                        occur[s[tail]] = false;
                    }
                }
                occur[s[head]] = true;

                int cur = head - tail;
                ret = Math.Max(ret, cur);
            }

            return ret;
        }
    }


    class Program
    {
        static void RunTest(string input, int expectedResult)
        {
            Solution sol = new Solution();
            int actualResult = sol.LengthOfLongestSubstring(input);

            Console.Write($"{input} ");

            if (actualResult == expectedResult)
            {
                Console.WriteLine(" PASSED.");
            } else
            {
                Console.WriteLine($" FAILED:");
                Console.WriteLine($"   Expected: {expectedResult}");
                Console.WriteLine($"   Actual  : {actualResult}");
            }
        }

        static void Main(string[] args)
        {
            RunTest("abcabcbb", 3);
            RunTest("bbbbb", 1);
            RunTest("pwwkew", 3);
            RunTest("tmmzuxt", 5);
        }
    }
}
