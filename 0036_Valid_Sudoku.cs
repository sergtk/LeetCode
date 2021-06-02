// Problem statement: https://leetcode.com/problems/valid-sudoku/

using System;

public class Solution {
    
    static bool CheckVal(char c, bool[] has)
    {
        if (c == '.') {
            return true;
        }
        int res = c - '0' - 1;
        if (res == -1)
            return true;
        if (has[res])
            return false;
        has[res] = true;
        return true;
    }
    
    public bool IsValidSudoku(char[][] board)
    {
        bool[] has = new bool[9];
        for (int r = 0; r < 9; r++) {
            Array.Fill(has, false);
            for (int c = 0; c < 9; c++) {
                if (!CheckVal(board[r][c], has))
                    return false;
            }
        }
        for (int c = 0; c < 9; c++) {
            Array.Fill(has, false);
            for (int r = 0; r < 9; r++) {
                if (!CheckVal(board[r][c], has))
                    return false;
            }
        }
            
        for (int pr = 0; pr < 3; pr++) {
            for (int pc = 0; pc < 3; pc++) {
                Array.Fill(has, false);
                for (int r = 0; r < 3; r++) {
                    for (int c = 0; c < 3; c++) {
                        if (!CheckVal(board[pr * 3 + r][pc * 3 + c], has))
                            return false;                        
                    }
                }
            }
        }
        return true;
    }
}
