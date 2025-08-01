namespace CSharpTasks {
    public class Cell {
        // Properties
        public int Row { get; }
        public int Column { get; }
        public ChessPiece? Piece { get; private set; }

        public (int x, int y) Coordinates => (Column, Row);

        public char Symbol {
            get {
                if (Piece == null) {
                    return '·';   
                }
                return Piece.Symbol;
            }
        }

        // Constructor
        public Cell(int row, int column, ChessPiece? piece = null) {
            Row = row;
            Column = column;
            Piece = piece;
        }

        // Methods
        /// <summary>
        /// Checks if cell contains any chess piece.
        /// </summary>
        /// <returns>Returns true if cell contains any chess piece, otherwise - false.</returns>
        public bool HasChessPiece() {
            if (Piece == null) {
                return false;
            } else {
                return true;
            }
        }
        /// <summary>
        /// Checks if cell is occupied by specific color of any chess pieces.
        /// </summary>
        /// <param name="color">Color which will be checked.</param>
        /// <returns>Returns true, if cell contains given color, otherwise - false.</returns>
        public bool IsOccupiedByColor(ChessPieceColor color) {
            if (Piece == null) {
                return false;
            } else {
                if (Piece.Color == color) {
                    return true;
                } else {
                    return false;
                }
            }
        }
        public void SetPiece(ChessPiece? piece) {
            Piece = piece;
        }
    }
}
