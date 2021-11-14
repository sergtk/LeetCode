/*
Problem statement: https://leetcode.com/problems/surrounded-regions/

Some test cases:
[["O", "O", "O", "O"],["O", "O", "O", "O"],["O", "O", "O", "O"],["O", "O", "O", "O"],["O", "O", "O", "O"]]
[["O", "O", "O", "O"],["O", "O", "O", "O"],["O", "O", "O", "O"],["O", "O", "O", "O"],["O", "O", "O", "O"]]
[["O", "O", "O", "O", "O"],["O", "X", "X", "X", "O"],["O", "X", "O", "X", "O"],["O", "X", "X", "X", "O"],["O", "O", "O", "O", "O"]]
*/

public class Solution {
    char[][] board;
    
    Stack<Tuple<int, int>> tasks;
    bool[,] zero;
    
    int[] di = {-1, 0, 0, 1};
    int[] dj = {0, -1, 1, 0};
    
    void Push(int i, int j)
    {
        if (zero[i, j] || board[i][j] != 'O') {
            return;
        }
        zero[i, j] = true;
        tasks.Push(Tuple.Create(i, j));
    }
    
    public void Solve(char[][] board1) {
        board = board1;
        
        int m = board.Length;
        int n = board[0].Length;
        zero = new bool[m, n];
        tasks = new Stack<Tuple<int, int>>();
        
        for (int i = 0; i < m; i++) {
            Push(i, 0);
            Push(i, n-1);
        }
        for (int j = 0; j < n; j++) {
            Push(0, j);
            Push(m-1, j);
        }
        while (tasks.Count > 0) {
            var t = tasks.Pop();
            
            for (int d = 0; d < 4; d++) {
                int i1 = t.Item1+di[d];
                if (i1 < 0 || i1 == m) continue;
                int j1 = t.Item2+dj[d];
                if (j1 < 0 || j1 == n) continue;
                Push(i1, j1);
            }
        }
        
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                //System.Console.Write($" {zero[i, j]}");
                if (!zero[i, j]) {
                    board[i][j] = 'X';
                }
            }
            //System.Console.WriteLine();
        }
    }
}