public class Solution {
    public int UnhappyFriends(int n, int[][] preferences, int[][] pairs) {
        int[,] prefOrders = new int[n, n];
        for (int i = 0; i < n; i++) {
            for (int ii = 0; ii < n-1; ii++) {
                int j = preferences[i][ii];
                prefOrders[i, j] = ii;
            }
        }
        
        int ret = 0;
        
        for (int pi1 = 0; pi1 < pairs.Length; pi1++) {
            for (int order1 = 0; order1 < 2; order1++) {
                int x, y;
                if (order1 == 0)
                    (x, y) = (pairs[pi1][0], pairs[pi1][1]);
                else
                    (x, y) = (pairs[pi1][1], pairs[pi1][0]);
                
                //Console.WriteLine($"x = {x}");
                
                bool unhappy = false;
                
                for (int pi2 = 0; pi2 < pairs.Length; pi2++) if (pi1 != pi2) {
                    for (int order2 = 0; order2 < 2; order2++) {
                        int u, v;
                        if (order2 == 0)
                            (u, v) = (pairs[pi2][0], pairs[pi2][1]);
                        else
                            (u, v) = (pairs[pi2][1], pairs[pi2][0]);
                        
                        if (prefOrders[x, u] < prefOrders[x, y] && prefOrders[u, x] < prefOrders[u, v])
                        {
                            unhappy = true;
                            //Console.WriteLine($"Unhappy: {x} with {y}, bacause {u} with {v}");
                            break;
                        }
                    }
                    if (unhappy)
                        break;
                }
                if (unhappy)
                    ret++;
            }
        }
        return ret;
        
    }
}
