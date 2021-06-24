// Problem statement: https://leetcode.com/problems/valid-palindrome/

public class Solution {
    public bool IsPalindrome(string s) {
        int n = s.Length;
        var s1 = new List<char>();
        foreach (char ch in s) {
            if (ch >= 'a' && ch <= 'z' || ch >= 'A' && ch <= 'Z' || ch >= '0' && ch <= '9') {
                s1.Add(Char.ToLower(ch));
            }
        }
        //System.Console.WriteLine(String.Join("", s1));
        var s2 = new List<char>(s1);
        s2.Reverse();
        var ret = s1.SequenceEqual(s2);
        return ret;
    }
}