class Solution {
    public int FirstUniqChar(string s) {
        int absent = 1000000;
        int dup = 500000;
        int[] ar = Enumerable.Repeat(absent, 26).ToArray();        
        for (int i = 0; i < s.Length; i++) {
            int c = s[i]-'a';
            ar[c] = ar[c] == absent ? i : dup;
        }
        int mn = ar.Min();
        if (mn < dup)
            return mn;
        return -1;
    }
};