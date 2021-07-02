using System;
using System.Collections.Generic;
using System.Linq;

//--------------------------------------------------------------------------------------------

// Problem statement: 128. Longest Consecutive Sequence https://leetcode.com/problems/longest-consecutive-sequence/


// This solution can be considered near lenear if hash operations are considered constant and disjoint sets operation
// are considered constant as well. Strictly speaking these operations are not constant, but anyway close to it.
// Strictly speaking problem statement is hardly considered correct.
public class Solution {

    // number -> (isRoot, parent or size)
    Dictionary<int, (bool, int)> _dset = new Dictionary<int, (bool, int)>();

    int GetRoot(int v) {
        var r = _dset[v];
        while (!r.Item1) {
            v = r.Item2;
            r = _dset[v];
        }
        return v;
    }


    public int LongestConsecutive(int[] nums) {
        int n = nums.Length;
        if (n == 0) return 0;
        foreach (var v in nums) {
            //Console.WriteLine($"v = {v}");
            if (_dset.ContainsKey(v))
                continue;
            bool has1 = _dset.ContainsKey(v-1);
            bool has2 = _dset.ContainsKey(v+1);
            if (!has1 && !has2) {
                _dset[v] = (true, 1);
                continue;
            }
            if (has1 && has2) {
                int root1 = GetRoot(v-1);
                var ref1 = _dset[root1];
                int root2 = GetRoot(v+1);
                var ref2 = _dset[root2];

                int total = ref1.Item2 + ref2.Item2 + 1;
                if (ref1.Item2 > ref2.Item2) {
                    _dset[root1] = (true, total);
                    _dset[root2] = (false, root1);
                    _dset[v] = (false, root1);
                } else {
                    _dset[root2] = (true, total);
                    _dset[root1] = (false, root2);
                    _dset[v] = (false, root2);
                }
                continue;
            }

            if (has1) {
                int root1 = GetRoot(v-1);
                var ref1 = _dset[root1];
                _dset[root1] = (true, ref1.Item2+1);
                _dset[v] = (false, root1);
            } else {
                int root2 = GetRoot(v+1);
                var ref2 = _dset[root2];
                _dset[root2] = (true, ref2.Item2+1);
                _dset[v] = (false, root2);
            }
        }

        var ret = _dset.Max(v => v.Value.Item1 ? v.Value.Item2 : 0);
        return ret;
    }
}

//--------------------------------------------------------------------------------------------

class Program
{
    static void RunTest(int testIndex, int[] nums, int expectedResult)
    {
        Console.WriteLine($"Test {testIndex}.");

        //-------------------------------------------------

        Solution sol = new Solution();
        int actualResult = sol.LongestConsecutive(nums);

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

        RunTest(1, new int[] {100,4,200,1,3,2}, 4);
        RunTest(2, new int[] {0,3,7,2,5,8,4,6,0,1}, 9);
        RunTest(3, new int[] {1}, 1);
        RunTest(4, new int[] {1, 2}, 2);
        RunTest(5, new int[] {1, 3}, 1);
        RunTest(6, new int[] {1, 3, 2}, 3);
        RunTest(7, new int[] {1, 3, 5, 2, 4}, 5);
        RunTest(8, new int[] {1, 3, 5, 2, 4, 10, 9, 8, 7, 6}, 10);
        RunTest(9, new int[] {}, 0);
        RunTest(10, new int[] {100}, 1);
        RunTest(11, new int[] {-100}, 1);
        RunTest(21, new int[] {-3,2,8,5,1,7,-8,2,-8,-4,-1,6,-6,9,6,0,-7,4,5,-4,8,2,0,-2,-6,9,-4,-1}, 7);
        
        watch.Stop();
        Console.WriteLine($"\nProgram execution time: {watch.ElapsedMilliseconds / 1000f:0.000} sec.");

    }
}
