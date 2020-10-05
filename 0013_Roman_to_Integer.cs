public class Solution {
    public int RomanToInt(string s) {
        Dictionary<char, int> dict = new Dictionary<char, int>() {
            ['I'] = 1,
            ['V'] = 5,
            ['X'] = 10,
            ['L'] = 50,
            ['C'] = 100,
            ['D'] = 500,
            ['M'] = 1000 
        };
        
        int ret = 0;
        for (int i = 0; i < s.Length; i++) {
            if (i < s.Length - 1 && dict[s[i]] < dict[s[i+1]])
                ret -= dict[s[i]];
            else
                ret += dict[s[i]];
        }
        return ret;
    }
}
