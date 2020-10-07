public class Solution {
    public string ModifyString(string s) {
        int n = s.Length;
        StringBuilder res = new StringBuilder(s);
        for (int i = 0; i < n; i++) {
            if (res[i] == '?') {
                for (char c = 'a'; ; c++) {
                    if (i > 0 && res[i-1] == c || i < res.Length-1 && res[i+1] == c)
                        continue;
                    res[i] = c;
                    break;
                }
            }
        }
        string ret = res.ToString();
        return ret;
    }
}
