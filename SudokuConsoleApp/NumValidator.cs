using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuConsoleApp
{
    public static class NumValidator
    {
        public static readonly int GRID_SIZE = 9;
        private static bool isNumberInRow(int[,] board, int numToCheck, int row)
        {
            for (int i = 0; i < GRID_SIZE; i++)
                if (board[row,i] == numToCheck)
                    return true;
            return false;
        }

        private static bool isNumberInColumn(int[,] board, int numToCheck, int column)
        {
            for (int i = 0; i < GRID_SIZE; i++)
                if (board[i,column] == numToCheck)
                    return true;
            return false;
        }

        private static bool isNumberInBox(int[,] board, int numToCheck, int row, int column)
        {
            int localBoxRow = row - row % 3; // One coordinate for starting point
            int localBoxColumn = column - column % 3; // Second coordinate for starting point

            for (int i = localBoxRow; i < localBoxRow + 3; i++)
                for (int j = localBoxColumn; j < localBoxColumn + 3; j++)
                    if (board[i,j] == numToCheck)
                        return true;
            return false;
        }

        private static bool isValidStatement(int[,] board, int numToCheck, int row, int column)
        {
            return !isNumberInRow(board, numToCheck, row) &&
                !isNumberInColumn(board, numToCheck, column) &&
                !isNumberInBox(board, numToCheck, row, column);
        }

        public static bool solveBoard(int[,] board)
        {
            for(int row = 0; row < GRID_SIZE; row++)
            {
                for(int column = 0; column < GRID_SIZE; column++)
                {
                    if(board[row,column] == 0)
                    {
                        for(int numToTry=1; numToTry <= GRID_SIZE; numToTry++)
                        {
                            if (isValidStatement(board, numToTry, row, column))
                            {
                                board[row,column] = numToTry;

                                if(solveBoard(board))
                                    return true;
                                else
                                    board[row,column] = 0;
                            }
                        }
                        return false;
                    }

                }
            }
            return true;
        }

        public static void printBoard(int[,] board)
        {
            for (int row = 0; row < NumValidator.GRID_SIZE; row++)
            {
                if (row % 3 == 0 && row != 0)
                {
                    Console.WriteLine("-----------");
                }
                for (int column = 0; column < NumValidator.GRID_SIZE; column++)
                {
                    if (column % 3 == 0 && column != 0)
                    {
                        Console.Write("|");
                    }
                    int number = board[row, column];
                    Console.Write(number);
                }
                Console.WriteLine();
            }
        }
    }
}
