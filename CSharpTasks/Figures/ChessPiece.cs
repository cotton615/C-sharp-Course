namespace CSharpTasks.Figures {
    public abstract class ChessPiece {
        // Properties
        public string Name { get; private set; }
        public ChessPieceColor Color { get; private set; }
        public char Symbol { get; private set; }
        public Cell? Cell { get; private set; }
        protected virtual bool NeedsClearPath => false;

        // Constructor
        protected ChessPiece(string name, ChessPieceColor color) {
            Name = name;
            Color = color;

            if (!ChessSymbols.chessPieceSymbols.TryGetValue((name, color), out char symbol)) {
                throw new ArgumentException($"No symbol found for {color} {name}");
            }

            Symbol = symbol;
        }

        // Abstract and virtual method
        public abstract bool IsValidMove(Cell[,] board, (int x, int y) fromCoordinates, (int x, int y) toCoordinates);
        public virtual bool IsValidAttack(Cell[,] board, (int x, int y) fromCoordinates, (int x, int y) toCoordinates) {
            if (!IsValidMove(board, fromCoordinates, toCoordinates)) {
                return false;
            } 

            Cell targetCell = board[toCoordinates.y, toCoordinates.x];
            if (targetCell.HasChessPiece() && targetCell.Piece.Color != this.Color) {
                return true;
            }

            return false;
        }

        // Methods
        public void SetCell(Cell? cell) {
            Cell = cell;
        }

        public bool IsPathClear(Cell[,] board, (int x, int y) fromCoordinates, (int x, int y) toCoordinates) {
            int dx = toCoordinates.x - fromCoordinates.x;
            int dy = toCoordinates.y - fromCoordinates.y;

            int stepX = 0;
            int stepY = 0;

            if (dx > 0) {
                stepX = 1;
            } else if (dx < 0) {
                stepX = -1;
            }

            if (dy > 0) {
                stepY = 1;
            } else if (dy < 0) {
                stepY = -1;
            }

            int currentX = fromCoordinates.x + stepX;
            int currentY = fromCoordinates.y + stepY;

            while (currentX != toCoordinates.x || currentY != toCoordinates.y) {
                if (board[currentY, currentX].HasChessPiece()) {
                    return false;
                }

                currentX += stepX;
                currentY += stepY;
            }

            return true;
        }
    }
}
