public class Solution {
    
    List<string> ret;
    int n;
    
    StringBuilder cur;
    
    void Gen(int pos, int opened) {
        if (n-pos < opened) {
            //string curPart = cur.ToString().Substring(0, pos);
            //Console.WriteLine($"Return n={n}, pos={pos}, opened={opened}, part={curPart}");
            return;
        }
        if (pos == n) {
            ret.Add(cur.ToString());
            return;
        }
        cur[pos] = '(';
        Gen(pos+1, opened+1);
        if (opened > 0) {
            cur[pos] = ')';
            Gen(pos+1, opened-1);
        }
    }
    
    public IList<string> GenerateParenthesis(int n) {
        n *= 2;
        this.n = n;
        ret = new List<string>();
        cur = new StringBuilder(new string('@', n));
        
        Gen(0, 0);
        
        return ret;
    }
}
