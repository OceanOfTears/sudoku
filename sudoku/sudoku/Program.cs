using System;

class Program
{
    static bool IsRowValid(int[,] board, int row, int value)
    {
        for (int col = 0; col < 9; col++)
        {
            if (board[row, col] == value)
            {
                return false;
            }
        }
        return true;
    }

    static bool IsColumnValid(int[,] board, int col, int value)
    {
        for (int row = 0; row < 9; row++)
        {
            if (board[row, col] == value)
            {
                return false;
            }
        }
        return true;
    }

    static void PrintBoard(int[,] board)
    {
        Console.WriteLine("______________________________");
        for (int row = 0; row < 9; row++)
        {
            if (row % 3 == 0 && row != 0)
            {
                Console.WriteLine("_________|_________|_________|");
            }
                for (int col = 0; col < 9; col++)
            {
                if (col % 3 == 0 && col != 0)
                {
                    Console.Write("|");
                }
                Console.Write(board[row, col] == 0 ? "   " : $" {board[row, col]} ");
            }
            Console.WriteLine("|");
        }
        Console.WriteLine("_________|_________|_________|");
    }

    static void Main()
    {
        int[,] board = new int[9, 9];

        int[,] initialBoard = {
            {4, 2, 0, 0, 0, 3, 0, 8, 1},
            {0, 0, 1, 0, 0, 0, 0, 0, 3},
            {0, 7, 8, 0, 1, 5, 0, 6, 9},
            {0, 0, 0, 6, 0, 0, 0, 3, 5},
            {2, 5, 7, 0, 0, 0, 9, 4, 6},
            {0, 0, 0, 0, 0, 9, 0, 0, 8},
            {1, 9, 0, 2, 8, 4, 0, 0, 0},
            {7, 4, 5, 3, 0, 6, 0, 0, 2},
            {0, 0, 0, 1, 5, 0, 6, 0, 0}
        };

        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                board[i, j] = initialBoard[i, j];
            }
        }

        while (true)
        {
            PrintBoard(board);

            Console.WriteLine("Введите координаты и значение, например 1(строка) 2(столбец) 3(значение)");
            string input = Console.ReadLine();
            string[] parts = input.Split(' ');
            if (parts.Length == 3)
            {
                int row = int.Parse(parts[0]) - 1;
                int col = int.Parse(parts[1]) - 1;
                int value = int.Parse(parts[2]);

                if (IsRowValid(board, row, value) && IsColumnValid(board, col, value))
                {
                    if (board[row, col] != 0)
                    {
                        Console.WriteLine("В ячейке уже вписано значение.");
                    }
                    else
                    {
                        board[row, col] = value;
                    }
                }
                else
                {
                    Console.WriteLine("Некорректное значение. Число такое уже стоит");
                }
            }
        }
        Console.WriteLine("Игра завершена.");
    }
}