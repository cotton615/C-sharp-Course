namespace CSharpTasks {
    public enum ChessPieceColor {
        Black,
        White
    }
    public enum MoveOutcome {
        Invalid,
        Move,
        Attack
    }

    public enum ChessPieceType {
        Rook, Knight, Bishop, Queen, King, Pawn
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
            bool gameRunning = true;

            while (gameRunning) {
                Console.WriteLine(board.ToString());
                ChessPieceColor currentPlayer;

                if (isWhiteTurn) {
                    currentPlayer = ChessPieceColor.White;
                } else {
                    currentPlayer = ChessPieceColor.Black;
                }

                Console.WriteLine($"Current player: {currentPlayer}");
                Console.WriteLine("Choose piece to make a move.");

                (int x, int y) fromCoordinates = GetUserCoordinate();
                if (!board.CanSelectPiece(fromCoordinates, currentPlayer)) {
                    Console.WriteLine("You are unable to choose that piece.");
                    Thread.Sleep(1000);
                    Console.Clear();
                    continue;
                }

                Console.WriteLine($"Now choose where to move piece ({FormatCoordinates(fromCoordinates)})");
                (int x, int y) destinationCoordinates = GetUserCoordinate();

                MoveOutcome outcome = board.ValidateMove(fromCoordinates, destinationCoordinates, currentPlayer);

                if (outcome == MoveOutcome.Invalid) {
                    Console.WriteLine($"You are unable to move from ({FormatCoordinates(fromCoordinates)}) to ({FormatCoordinates(destinationCoordinates)})");
                    Thread.Sleep(1000);
                    Console.Clear();
                    continue;
                }

                bool gameOver = board.ExecuteMove(fromCoordinates, destinationCoordinates, outcome);

                if (gameOver) {
                    Console.WriteLine($"{currentPlayer} WINS ! ! ! ");
                    gameRunning = false;
                } else {
                    isWhiteTurn = !isWhiteTurn;
                }

                Thread.Sleep(1000);
                Console.Clear();
            }
        }
    }
}