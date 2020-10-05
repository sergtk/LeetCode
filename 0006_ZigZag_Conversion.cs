public class Solution {
    public string Convert(string s, int numRows) {
        int n = s.Length;
        if (numRows == 1 || n <= 1) {
            return s;
        }
        StringBuilder res = new StringBuilder(n);
        int i = 0;
        while (i < n)
        {
            res.Append(s[i]);
            i += numRows * 2 - 2;
        }
        for (int r = 1; r < numRows - 1; r++)
        {
            i = r;
            while (i < n)
            {
                res.Append(s[i]);
                i += (numRows - r - 1) * 2;
                if (i < n)
                {
                    res.Append(s[i]);
                    i += r * 2;
                }
            }
        }
        i = numRows - 1;
        while (i < n)
        {
            res.Append(s[i]);
            i += numRows * 2 - 2;
        }
        string ret = res.ToString();
        return ret;
    }
}