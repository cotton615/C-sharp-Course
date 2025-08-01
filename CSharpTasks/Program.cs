namespace CSharpTasks {
    public enum ChessPieceColor {
        Black = 0,
        White = 1
    }
    public enum MoveOutcome {
        Invalid = 0,
        Move = 1,
        Attack = 2
    }

    internal class Program {
        static (int x, int y) GetUserCoordinate() {
            while (true) {
                Console.Write("> ");
                string userInput = Console.ReadLine();
                userInput = userInput.Trim().ToLower();
                
                if (userInput.Length != 2) {
                    Console.WriteLine($"{userInput} is invalid. Try format: a1");
                    continue;
                } 

                char xChar = userInput[0];
                char yChar = userInput[1];

                if (xChar < 'a' || xChar > 'h' || yChar < '1' || yChar > '8') {
                    Console.WriteLine($"Coordinate ({xChar}{yChar}) are out of bounds: a-h and 1-8.");
                    continue;
                }

                int x = xChar - 'a'; 
                int y = yChar - '1';

                return (x, y);
            }
        }

        static string FormatCoordinates((int x, int y) coordinates) {
            char column = (char)('a' + coordinates.x);
            int row = coordinates.y + 1;

            return $"{column}{row}";
        }

        static void Main() {
            Board board = new Board();
            bool isWhiteTurn = true;
            bool isGameRunning = true;

            while (isGameRunning) {
                Console.WriteLine(board.ToString());
                ChessPieceColor currentPlayer;

                if (isWhiteTurn) {
                    currentPlayer = ChessPieceColor.White;
                } else {
                    currentPlayer= ChessPieceColor.Black;
                }

                Console.WriteLine($"Current player: {currentPlayer}");
                Console.WriteLine("Choose piece to make a move.");
                (int x, int y) chessPieceCoordinate = GetUserCoordinate();
                if (!board.CanSelectPiece(chessPieceCoordinate, currentPlayer)) {
                    Console.WriteLine("You are unable to choose that piece.");
                    Thread.Sleep(1000);
                    Console.Clear();
                    continue;
                }

                Cell selectedCell = board.GetCellAt((chessPieceCoordinate.x, chessPieceCoordinate.y));
                Console.WriteLine($"Now choose where to move piece ({FormatCoordinates(selectedCell.Coordinates)})");

                (int x, int y) moveCoordinate = GetUserCoordinate();
                switch (board.CanMoveTo(selectedCell.Coordinates, (moveCoordinate.x, moveCoordinate.y), currentPlayer)) {
                    case MoveOutcome.Invalid:
                        Console.WriteLine($"You are unable to move from ({FormatCoordinates(selectedCell.Coordinates)}) to ({FormatCoordinates((moveCoordinate.x, moveCoordinate.y))})");
                        Thread.Sleep(1000);
                        Console.Clear();
                        break;
                    case MoveOutcome.Move:
                        board.MovePiece(selectedCell, moveCoordinate);
                        Console.WriteLine($"You moved from ({FormatCoordinates(selectedCell.Coordinates)}) to ({FormatCoordinates((moveCoordinate.x, moveCoordinate.y))})");
                        isWhiteTurn = !isWhiteTurn;
                        Thread.Sleep(1000);
                        Console.Clear();
                        break;
                    case MoveOutcome.Attack:
                        if (board.IsKingCaptured(moveCoordinate)) {
                            Console.WriteLine($"{currentPlayer} WINS! ! ! ");
                            isGameRunning = false;
                            break;
                        } else {
                            board.MovePiece(selectedCell, moveCoordinate);
                            Console.WriteLine($"You moved from ({FormatCoordinates(selectedCell.Coordinates)}) to ({FormatCoordinates((moveCoordinate.x, moveCoordinate.y))}) \nAnd made a kill.");
                            isWhiteTurn = !isWhiteTurn;
                            Thread.Sleep(1000);
                            Console.Clear();
                            break;
                        }
                }
            }
        }
    }
}