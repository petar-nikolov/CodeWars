using System;

namespace SoftUni
{
    class Program
    {
        static void Main(string[] args)
        {
            //input
            var chess = new string[8, 8];
            var board = new char[8, 8];

            for (int row = 0; row < board.GetLength(0); row++)
            {
                var line = Console.ReadLine().ToCharArray();
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    board[row, col] = line[col];
                }
            }

            //build chess
            for (int row = 0; row < 8; row++)
            {
                var line = "abcdefgh".ToCharArray();
                for (int col = 0; col < 8; col++)
                {
                    chess[row, col] = $"{line[col]}{chess.GetLength(0) - row}";
                }
            }

            //get current pawn positions
            var currentWhitePositionRow = 0;
            var currentWhitePositionCol = 0;
            var currentBlackPositionRow = 0;
            var currentBlackPositionCol = 0;

            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    if (board[row, col] == 'w')
                    {
                        currentWhitePositionRow = row;
                        currentWhitePositionCol = col;
                    }

                    if (board[row, col] == 'b')
                    {
                        currentBlackPositionRow = row;
                        currentBlackPositionCol = col;
                    }
                }
            }

            //start move
            while (true)
            {
                var whiteNextRow = currentWhitePositionRow - 1;
                var whiteLeftDiagonal = currentWhitePositionCol - 1;
                var whiteRightDiagonal = currentWhitePositionCol + 1;

                var blackNextRow = currentBlackPositionRow + 1;
                var blackLeftDiagonal = currentBlackPositionCol + 1;
                var blackRightDiagonal = currentBlackPositionCol - 1;

                //first white move
                //check if can capture black
                if (whiteLeftDiagonal >= 0)
                {
                    if (CheckWin(whiteNextRow, whiteLeftDiagonal, board, 'b'))
                    {
                        Console.WriteLine($"Game over! White capture on {chess[whiteNextRow, whiteLeftDiagonal]}.");
                        break;
                    }
                }

                if (whiteRightDiagonal < 8)
                {
                    if (CheckWin(whiteNextRow, whiteRightDiagonal, board, 'b'))
                    {
                        Console.WriteLine($"Game over! White capture on {chess[whiteNextRow, whiteRightDiagonal]}.");
                        break;
                    }
                }

                //check queen
                if (whiteNextRow == 0)
                {
                    Console.WriteLine($"Game over! White pawn is promoted to a queen at {chess[whiteNextRow, currentWhitePositionCol]}.");
                    break;
                }

                //move white
                board[currentWhitePositionRow, currentWhitePositionCol] = '-';
                board[whiteNextRow, currentWhitePositionCol] = 'w';
                currentWhitePositionRow = whiteNextRow;


                //black move
                //check if can capture white
                if (blackRightDiagonal >= 0)
                {
                    if (CheckWin(blackNextRow, blackRightDiagonal, board, 'w'))
                    {
                        Console.WriteLine($"Game over! Black capture on {chess[blackNextRow, blackRightDiagonal]}.");
                        break;
                    }
                }

                if (blackLeftDiagonal < 8)
                {
                    if (CheckWin(blackNextRow, blackLeftDiagonal, board, 'w'))
                    {
                        Console.WriteLine($"Game over! Black capture on {chess[blackNextRow, blackLeftDiagonal]}.");
                        break;
                    }
                }

                if (blackNextRow == 7)
                {
                    Console.WriteLine($"Game over! Black pawn is promoted to a queen at {chess[blackNextRow, currentBlackPositionCol]}.");
                    break;
                }

                //move white
                board[currentBlackPositionRow, currentBlackPositionCol] = '-';
                board[blackNextRow, currentBlackPositionCol] = 'b';
                currentBlackPositionRow = blackNextRow;

                //Print(board);
            }
        }

        // public static void Print(char[,] board)
        // {
        //     for (int row = 0; row < 8; row++)
        //     {
        //         for (int col = 0; col < 8; col++)
        //         {
        //             Console.Write(board[row, col]);
        //         }
        //
        //         Console.WriteLine();
        //     }
        // }
        //
        // public static void PrintChess(string[,] board)
        // {
        //     for (int row = 0; row < 8; row++)
        //     {
        //         for (int col = 0; col < 8; col++)
        //         {
        //             Console.Write(board[row, col]);
        //         }
        //
        //         Console.WriteLine();
        //     }
        // }

        public static bool CheckWin(int row, int col, char[,] board, char pawn)
        {
            return board[row, col] == pawn;
        }
    }
}