public class Solution {
    public string ReorderSpaces(string text) {
        int ns = text.Count(c => c == ' ');
        int n = text.Length;
        int wc = 0;
        if (text[0] != ' ') {
            wc = 1;
        }
        for (int i = 1; i < n; i++) {
            if (text[i-1] == ' ' && text[i] != ' ') {
                wc++;
            }
        }
        int slen = wc > 1 ? ns / (wc - 1) : 0;
        
        StringBuilder res = new StringBuilder(n);
        bool isFirst = true;
        for (int src = 0; src < n; src++) {
            if (text[src] != ' ') {
                if (src == 0 || text[src-1] == ' ') {
                    if (!isFirst) {
                        for (int j = 0; j < slen; j++) {
                            res.Append(' ');
                        }
                    }
                    isFirst = false;
                }
                res.Append(text[src]);
            }
        }
        while (res.Length < n) res.Append(' ');
        string ret = res.ToString();
        return ret;
    }
}