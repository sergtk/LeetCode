public class Solution {
    string str;
    int n;
    int[,] subIdx;
    bool[] pres;
    
    int cnt;
    
    void calc(int start, int c) {
        if (start == n) {
            cnt = Math.Max(cnt, c);
            //Console.WriteLine(new string('-', start) + $"+ ({cnt})");
            return;
        }
        for (int end = start; end < n; end++) {
            int i = subIdx[start, end];
            if (pres[i]) {
                continue;
            }
            pres[i] = true;
            //Console.WriteLine(new string('-', start) + str.Substring(start, end - start + 1));
            calc(end+1, c+1);
            pres[i] = false;
        }
    }

    public int MaxUniqueSplit(string str1) {
        str = str1;
        n = str.Length;
        
        var strIdx = new Dictionary<string, int>();
        subIdx = new int[n, n];
        
        for (int s = 0; s < n; s++) {
            for (int e = s; e < n; e++) {
                string sub = str.Substring(s, e - s + 1);
                //Console.WriteLine($"sub = {sub}");
                if (!strIdx.ContainsKey(sub)) {
                    strIdx[sub] = strIdx.Count;
                }
                //Console.WriteLine($"strIdx[{sub}] = {strIdx[sub]}");
                subIdx[s, e] = strIdx[sub];
            }
        }
        //Console.WriteLine($"strIdx.Count = {strIdx.Count}");
        
        pres = new bool[strIdx.Count];        
        cnt = 0;
        calc(0, 0);
        return cnt;
    }
}
