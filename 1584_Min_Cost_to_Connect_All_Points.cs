using System.Diagnostics;

public class Solution {
    
    List<(int, int, int)> queue;
    
    void MoveUp(int cur) {
        while (cur > 0)
        {
            int next = (cur - 1) / 2;
            if (queue[cur].Item1 > queue[next].Item1) {
                break;
            }
            (queue[next], queue[cur]) = (queue[cur], queue[next]);
            cur = next;
        }
    }
    
    void MoveDown(int cur) {
        int n = queue.Count;
        while (true) {
            int next = cur;
            int next1 = cur * 2 + 1;
            if (next1 < n && queue[next1].Item1 < queue[next].Item1)
                next = next1;
            int next2 = next1 + 1;
            if (next2 < n && queue[next2].Item1 < queue[next].Item1)
                next = next2;
            if (next == cur) {
                break;
            }
            (queue[next], queue[cur]) = (queue[cur], queue[next]);
            cur = next;
        }
    }
    

    /*
    public void QueueWrite(string title = "queue")
    {
        Console.WriteLine($"{title}:");
        for (int i = 0; i < queue.Count; i++) {
            Console.Write($"{queue[i]} ");
        }
        Console.WriteLine();
    }

    
    public void QueueCheck()
    {
        for (int i = queue.Count - 1; i > 0; i--) {
            if (queue[(i - 1)/2].Item1 > queue[i].Item1) {
                throw new Exception($"Wrong queue: indexes {(i-1)/2} ({queue[(i-1)/2]}) and {i} ({queue[i]})");
            }
        }
    }
    */
    
    public int MinCostConnectPoints(int[][] points) {
        int n = points.Length;
        if (n < 2) return 0;
        queue = new List<(int, int, int)>(n * (n-1) / 2);
        
        //Console.WriteLine($"n = {n}");
        //var edges = new SortedSet<(int, int, int)>();
        for (int i = 0; i < n; i++) {
            for (int j = i+1; j < n; j++) {
                var w = Math.Abs(points[i][0] - points[j][0]) + 
                    Math.Abs(points[i][1] - points[j][1]);
                var e = (w, i, j);
                queue.Add(e);
                MoveUp(queue.Count - 1);
                //edges.Add(e);
            }
        }

        //QueueWrite();
        //QueueCheck();
        
        int[] parts = new int[n];
        for (int i = 0; i < n; i++) parts[i] = i;

        int ret = 0;
        
        for (int ei = 0; ei < n-1;) {
            //QueueWrite();
            //QueueCheck();

            //Console.WriteLine($"Edges avail: {edges.Count}");
            int w, i, j;
            var e = (w, i, j) = queue[0];
            //edges.Remove(e);
            queue[0] = queue[queue.Count - 1];
            queue.RemoveAt(queue.Count - 1);
            MoveDown(0);
            if (parts[i] != parts[j])
            {
                //Console.WriteLine($"Add edge {i}-{j} ({points[i][0]}, {points[i][1]}) - ({points[j][0]}, {points[j][1]}). Parts: {parts[i]}-{parts[j]}");
                
                int p = Math.Min(parts[i], parts[j]);
                int p1 = Math.Max(parts[i], parts[j]);

                for (int k = 0; k < n; k++) {
                    if (parts[k] == p1)
                        parts[k] = p;
                }
                ret += w;
                ei++;                
            }
        }        
        return ret;
    }
}
