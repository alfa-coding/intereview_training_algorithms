using System;
namespace Algorithms.Library
{

    public class SudokuSolver
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


        public void SolveSudoku(char[][] board)
        {
            int[] arr = { 9, 2, 3, 4, 5, 6, 7, 8, 1 };

            SolveSudokuHelper(0, 0, arr, board);
        }

        private bool SolveSudokuHelper(int i, int j, int[] numbers, char[][] board)
        {

            if (i == 8 && j == 9)
            {

                return true;
            }

            if (j == 9)
            {
                i++;
                j = 0;
            }
            if (board[i][j] != '.')
                return SolveSudokuHelper(i, j + 1, numbers, board);


            for (int k = 0; k < numbers.Length; k++)
            {
                char num = (char)(numbers[k] + 48);
                bool nohayCrash = CheckCrash(board, i, j, num);
                if (nohayCrash)
                {
                    board[i][j] = num;
                    bool foundSolution = SolveSudokuHelper(i, j + 1, numbers, board);
                    if (foundSolution)
                    {
                        return true;
                    }

                }
                board[i][j] = '.';

            }
            return false;


        }
    }
}