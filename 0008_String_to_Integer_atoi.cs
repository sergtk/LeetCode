public class Solution {
    public int MyAtoi(string str) {
        int n = str.Length;
        int p = 0;
        while (p < n && str[p] == ' ')
            p++;
        if (p == n)
            return 0;
        
        bool neg = false;
        if (str[p] == '-') {
           neg = true;
           p++;
        }
        else if (str[p] == '+') {
            p++;
        }
        
        int lim10;
        int limLast;
        if (neg) {
            lim10 = Math.Abs(int.MinValue / 10);
            limLast = 8;
        } else {
            lim10 = int.MaxValue / 10;
            limLast = 7;
        }
        
        int ret = 0;
        while (p < n && char.IsDigit(str[p])) {
            int dig = str[p] - '0';
            
            if (ret > lim10 || ret == lim10 && dig > limLast)
            {
                if (neg)
                    return int.MinValue;
                else
                    return int.MaxValue;
            }
            ret = ret * 10 + dig;
            p++;
        }
        if (neg) ret = -ret;
        return ret;
    }
}
