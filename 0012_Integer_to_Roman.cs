public class Solution {
    public string IntToRoman(int num) {
        int[] vals = new int[] {1, 5, 10, 50, 100, 500, 1000};
        string chars = "IVXLCDM";
        
        string ret = "";
        for (int p = 6; p >= 0; p--) {
            while (num >= vals[p]) {
                ret += chars[p];
                num -= vals[p];
            }
            if (p > 0) {
                int p1 = p-1;
                if (p1%2 == 1)
                    p1--;
                if (num >= vals[p] - vals[p1]) {
                    ret += chars[p1];
                    ret += chars[p];
                    num -= vals[p] - vals[p1];
                }
            }
        }
        return ret;
    }
}
