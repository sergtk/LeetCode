// Link: https://leetcode.com/problems/median-of-two-sorted-arrays/

using System;
using System.Diagnostics;

namespace AlgoLeetCode_CSharp
{
    public class Solution
    {
        /*
        public double findMerge(int[] nums1, int[] nums2)
        {
            int[] all = new int[n];
            int i = 0, j = 0, k = 0;
            while (i < p && j < q)
                if (nums1[i] < nums2[j])
                    all[k++] = nums1[i++];
                else
                    all[k++] = nums2[j++];
            while (i < p)
                all[k++] = nums1[i++];
            while (j < q)
                all[k++] = nums2[j++];

            double ret;
            if (n % 2 == 1)
                ret = all[n / 2];
            else
                ret = (all[n / 2] + all[n / 2 - 1]) / 2.0;
            return ret;
        }
        */

        int p, q, n;
        int[] nums1;
        int[] nums2;

        public double findFast(int k, int start1, int start2)
        {
            //Debug.Assert(start1 <= p);
            //Debug.Assert(start2 <= q);
            if (k == 0)
            {
                if (start2 == q)
                {
                    return nums1[start1];
                }
                if (start1 == p)
                {
                    return nums2[start2];
                }
                if (nums1[start1] < nums2[start2])
                    return nums1[start1];
                else
                    return nums2[start2];
            }

            if (p == start1 || start2 < q && nums1[p - 1] < nums2[start2])
            {
                if (k < p - start1)
                    return nums1[start1 + k];
                return nums2[start2 + k - (p - start1)];
            }
            if (q == start2 || start1 < p && nums2[q - 1] < nums1[start1])
            {
                if (k < q - start2)
                    return nums2[start2 + k];
                return nums1[start1 + k - (q - start2)];
            }

            double ret;
            int kk = (k - 1) / 2;
            int m1 = Math.Min(start1 + kk, p - 1);
            int m2 = Math.Min(start2 + kk, q - 1);
            if (nums1[m1] < nums2[m2])
            {
                ret = findFast(k - (m1 + 1) + start1, m1 + 1, start2);
            }
            else
            {
                ret = findFast(k - (m2 + 1) + start2, start1, m2 + 1);
            }
            return ret;
        }

        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            this.nums1 = nums1;
            this.nums2 = nums2;
            p = nums1.Length;
            q = nums2.Length;
            n = p + q;

            //return findMerge(nums1, nums2);

            double ret;
            int k = n / 2;
            if (n % 2 == 0)
            {
                double a = findFast(k - 1, 0, 0);
                double b = findFast(k, 0, 0);
                ret = (a + b) / 2;
            }
            else
            {
                ret = findFast(k, 0, 0);
            }

            //double ret = findMerge(nums1, nums2); 
            return ret;
        }
    }

    class Program
    {
        static void RunTest(int testIndex, int[] nums1, int[] nums2, double expectedResult)
        {
            Console.WriteLine($"Test {testIndex}.");

            //-------------------------------------------------

            Solution sol = new Solution();
            double actualResult = sol.FindMedianSortedArrays(nums1, nums2);

            //-------------------------------------------------

            if (actualResult == expectedResult)
            {
                Console.WriteLine("PASSED.");
            } else
            {
                string nums1str = string.Join(", ", nums1);
                string nums2str = string.Join(", ", nums2);
                Console.WriteLine($"{{{nums1str}}} & {{{nums2str}}}");

                Console.WriteLine($"FAILED:");
                Console.WriteLine($"  Expected: {expectedResult}");
                Console.WriteLine($"  Actual  : {actualResult}");
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            RunTest(1, new int[] { 1, 3 }, new int[] { 2 }, 2);
            RunTest(2, new int[] { 1, 2 }, new int[] { 3, 4 }, 2.5);
            RunTest(3, new int[] { 0, 0 }, new int[] { 0, 0 }, 0);
            RunTest(4, new int[] { }, new int[] { 1 }, 1);
            RunTest(5, new int[] { 2 }, new int[] { }, 2);

            RunTest(10, new int[] { 1, 3 }, new int[] { 2, 7 }, 2.5);
            RunTest(11, new int[] { }, new int[] { 2, 3 }, 2.5);
            RunTest(12, new int[] { 3, 4 }, new int[] { }, 3.5);
            RunTest(13, new int[] { 3 }, new int[] { -2, -1 }, -1);
            RunTest(97, new int[] { 2 }, new int[] { 1, 3, 4, 5, 6 }, 3.5);
            RunTest(98, new int[] { 1, 3, 4, 5, 6 }, new int[] { 2 }, 3.5);
        }
    }
}
