namespace CSharpTasks {
    public abstract class ChessPiece {
        // Properties
        public string Name { get; private set; }
        public ChessPieceColor Color { get; private set; }
        public char Symbol { get; private set; }

        // Constructor
        protected ChessPiece(string name, ChessPieceColor color) {
            Name = name;
            Color = color;

            if (!ChessSymbols.chessPieceSymbols.TryGetValue((name, color), out char symbol)) {
                throw new ArgumentException($"No symbol found for {color} {name}");
            }

            Symbol = symbol;
        }

        // Abstract method
        public abstract bool IsValidMove(Cell[,] board, (int x, int y) fromCoordinate, (int x, int y) toCoordinate);
    }
}
