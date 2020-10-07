public class Solution {
    const int mod = 1000000000 + 7;
    public int CountRoutes(int[] locations, int start, int finish, int fuel) {
        int n = locations.Length;
        long[,] mem = new long[fuel+1, n];
        mem[0, start] = 1;
        for (int fu = 0; fu <= fuel; fu++) {
            int fr = fuel - fu;
            for (int src = 0; src < n; src++) {
                for (int dst = 0; dst < n; dst++) if (src != dst) {
                    int fneed = Math.Abs(locations[src] - locations[dst]);
                    if (fr >= fneed)
                    {
                        mem[fu+fneed, dst] = (mem[fu+fneed, dst] + mem[fu, src]) % mod;
                    }
                }
            }
        }
        long ret = 0;
        for (int f = 0; f <= fuel; f++) {
            ret += mem[f, finish];
        }
        ret %= mod;
        return (int)ret;
    }
}
