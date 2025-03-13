using System.Drawing;
using System.Threading;

namespace CSharpTasks
{
    internal class Program
    {
        static void Shuffle(List<int> List)
        {
            int n = List.Count;
            while (n > 1)
            {
                int k = Random.Shared.Next(n--);
                (List[n], List[k]) = (List[k], List[n]);
            }
        }

        static void DisplayBoard(int[,] Board, (int Row, int Col) Card1, (int Row, int Col) Card2, List<(int, int)> Guessed)
        {
            Console.Write("  ");
            for (int col = 0; col < Board.GetLength(1); col++)
            {
                Console.Write($"{(char)('A' + col)} ");
            }

            Console.WriteLine();

            for (int i = 0; i < Board.GetLength(0); i++)
            {
                Console.Write($"{i + 1} ");

                for (int j = 0; j < Board.GetLength(1); j++)
                {
                    if (Guessed.Contains((i, j)) ||
                        (i == Card1.Row && j == Card1.Col)
                        ||
                        (i == Card2.Row && j == Card2.Col))
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write($"{Board[i, j]} ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write($"{Board[i, j]} ");
                    }
                }
                Console.ResetColor();

                Console.WriteLine();
            }
        }

        static int[,] CreateBoard((int Rows, int Cols) Size)
        {
            int[,] board = new int[Size.Rows, Size.Cols];
            int PairsCount = (Size.Rows * Size.Cols) / 2;
            List<int> values = new List<int>();

            for (int i = 0; i < PairsCount; i++)
            {
                values.Add(i);
                values.Add(i);
            }

            Shuffle(values);
            int index = 0;
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j] = values[index++];
                }
            }

            return board;
        }

        static (int, int) EnterSize()
        {
            (int Rows, int Cols) Size;
            string[] Input = Console.ReadLine().Split(" ");

            while (true)
            {
                if (Input.Length == 2
                    &&
                    int.TryParse(Input[0].Trim(), out int Rows)
                    &&
                    int.TryParse(Input[1].Trim(), out int Cols))
                {
                    if ((Rows * Cols) % 2 == 0)
                    {
                        Size = (Rows, Cols);
                        return Size;
                    }
                    else
                    {
                        Console.WriteLine("ERROR: Enter numbers in a way, to make the product even.");
                    }
                }
                else
                {
                    Console.WriteLine("ERROR: Input is not a number.");
                }
            }
        }

        static (int, int) EnterCoordinateForCard((int Rows, int Cols) Size)
        {
            (int Col, int Row) Indices;

            while (true)
            {
                string[] Coordinate = Console.ReadLine().ToLower().Trim().Split(" ");

                if (char.TryParse(Coordinate[0], out char CharCol) && int.TryParse(Coordinate[1], out int Row))
                {
                    int Col = CharCol - 'a';
                    if (Row <= 0 || Row > Size.Rows || Col < 0 || Col >= Size.Cols)
                    {
                        Console.WriteLine("ERROR: Coordinate is out of range.");
                        continue;
                    } 
                    else
                    {
                        Indices = (Row - 1, Col);
                        return Indices;
                    }
                }

                else 
                {
                    Console.WriteLine("ERROR: Invalid Input. Enter in format: (A 1)");
                }
            }
        }

        static void Main()
        {   
            int FoundPairs = 0;
            Console.WriteLine("Welcome to the 'Guess the Pair' Game!");
            Console.WriteLine("Let's create a board. Enter dimensions (rows, cols): ");

            (int Rows, int Cols) Size = EnterSize();
            int[,] Board = CreateBoard(Size);
            Console.Clear();
            List<(int Row, int Col)> Guessed = new List<(int, int)>();

            while (FoundPairs < (Size.Rows * Size.Cols) / 2) 
            {
                DisplayBoard(Board, (-1, -1), (-1, -1), Guessed);

                Console.WriteLine("Enter the coordinates of 1st card: ");
                (int Row, int Col) Card1 = EnterCoordinateForCard(Size);

                Console.Clear();
                DisplayBoard(Board, Card1, (-1, -1), Guessed);

                Console.WriteLine("Enter the coordinates of 2nd card: ");
                (int Row, int Col) Card2 = EnterCoordinateForCard(Size);
                
                Console.Clear();
                DisplayBoard(Board, Card1, Card2, Guessed);

                if (Card1 == Card2)
                {
                    Console.WriteLine("ERROR: The coordinates of two cards MUST be different.");
                    Thread.Sleep(1000); 
                    Console.Clear();

                    continue;
                } else if (Guessed.Contains(Card1) || Guessed.Contains(Card2)) 
                {
                    Console.WriteLine("ERROR: The chosen card are already guessed.");
                    Thread.Sleep(1000);
                    Console.Clear();
                    continue;                
                }

                if (Board[Card1.Row, Card1.Col] == Board[Card2.Row, Card2.Col])
                {
                    Console.WriteLine("the cards are SAME");
                    FoundPairs += 1;
                    Guessed.Add((Card1.Row, Card1.Col));
                    Guessed.Add((Card2.Row, Card2.Col));
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("the cards are DIFFERENT");
                    Thread.Sleep(1000);
                    Console.Clear();
                }
            }
            Console.WriteLine("YOU WON!");
        }
    }
}