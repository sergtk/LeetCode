public class Solution {
    public int SumOddLengthSubarrays(int[] arr) {
        int n = arr.Length;
        int ret = 0;
        for (int s = 0; s < n; s++) {
            for (int e = s; e < n; e += 2) {
                for (int i = s; i <= e; i++) {
                    ret += arr[i];
                }
            }
        }
        return ret;
    }
}