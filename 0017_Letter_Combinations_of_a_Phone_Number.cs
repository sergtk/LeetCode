public class Solution {
    
    string[] map = {"", "", "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz"};
    
    
    List<string> res;
    
    int n;
    string digits;
    StringBuilder values;

    void Gen(int pos) {
        if (pos == n) {
            res.Add(values.ToString());
            return;
        }
        foreach (var c in map[digits[pos]-'0']) {
            values[pos] = c;
            Gen(pos+1);
        }
    }

    public IList<string> LetterCombinations(string digits) {
        this.n = digits.Length;
        if (n == 0) return new List<string>();
        this.digits = digits;
        this.values = new StringBuilder(digits);
        res = new List<string>();
        
        Gen(0);
        
        return res;
    }
}
