using System;

namespace SudokuConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] board = {
                {7,0,2,0,5,0,6,0,0},
                {0,0,0,0,0,3,0,0,0},
                {1,0,0,0,0,9,5,0,0},
                {8,0,0,0,0,0,0,9,0},
                {0,4,3,0,0,0,7,5,0},
                {0,9,0,0,0,0,0,0,8},
                {0,0,9,7,0,0,0,0,5},
                {0,0,0,2,0,0,0,0,0},
                {0,0,7,0,4,0,2,0,3}
            };

            Console.WriteLine("The board before:");
            NumValidator.printBoard(board);

            if (NumValidator.solveBoard(board))
            {
                Console.WriteLine("");
                Console.WriteLine("The board after: ");
                NumValidator.printBoard(board);
                Console.WriteLine("Solved successfully..!!!");
            }
            else
                Console.WriteLine("Unsolvable board..!!");
        }
        
        
    }
}
