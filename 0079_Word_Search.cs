// Problem statement: https://leetcode.com/problems/word-search/

public class Solution {

    char[][] board;
    bool[,] used;
    string word;
    int m, n, len;
    
    static int[] dr = {-1, 0, 1, 0};
    static int[] dc = { 0, 1, 0,-1};
    
    bool Find(int r, int c, int idx) {
        if (idx == len-1) {
            return true;
        }
        used[r, c] = true;
        for (int d = 0; d < 4; d++) {
            int r1 = r + dr[d];
            int c1 = c + dc[d];
            if (r1 >= 0 && c1 >= 0 && r1 < m && c1 < n && !used[r1, c1]) {
                if (board[r1][c1] == word[idx+1] && Find(r1, c1, idx+1)) {
                    return true;
                }
            }
        }
        used[r, c] = false;
        return false;
    }
    
    public bool Exist(char[][] board, string word) {
        m = board.Length;
        n = board[0].Length;
        this.board = board;
        this.word = word;
        len = word.Length;
        used = new bool[m, n];
        
        for (int r = 0; r < m; r++) {
            for (int c = 0; c < n; c++) {
                if (board[r][c] == word[0]) {
                    if (Find(r, c, 0)) {
                        return true;
                    }
                }
            }
        }
        return false;
    }
}
