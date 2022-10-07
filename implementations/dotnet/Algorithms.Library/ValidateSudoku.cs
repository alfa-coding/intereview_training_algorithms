using System;

namespace Algorithms.Library
{


    public class Solution
    {
        private bool CheckCrash(char[][] board, int row, int col, char num)
        {

            // Check if we find the same num
            // in the similar row , we
            // return false
            for (int x = 0; x <= 8; x++)
                if (board[row][x] == num)
                    return false;

            // Check if we find the same num
            // in the similar column ,
            // we return false
            for (int x = 0; x <= 8; x++)
                if (board[x][col] == num)
                    return false;

            // Check if we find the same num
            // in the particular 3*3
            // UserBoard, we return false
            int startRow = row - row % 3, startCol
                                          = col - col % 3;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (board[i + startRow][j + startCol] == num)
                        return false;

            return true;
        }
        public bool IsValidSudoku(char[][] board)
        {

            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    char saved = board[i][j];
                    board[i][j] = '.';
                    if (saved != '.' && !CheckCrash(board, i, j, saved))
                        return false;
                    board[i][j] = saved;
                }
            return true;

        }
    }
}