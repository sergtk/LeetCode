public class Solution {
    public bool IsPalindrome(int x) {
        string s = x.ToString();
        //Console.WriteLine($"s == {s}");
        string s1 = new string(s.Reverse().ToArray());
        //Console.WriteLine($"s1 == {s1}");
        return s == s1;
    }
}
