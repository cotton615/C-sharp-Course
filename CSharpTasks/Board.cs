using System.Data;
using System.Text;

namespace CSharpTasks {
    public class Board {
        // Fields
        private Cell[,] board;
        private static readonly char[] pieceOrder = { 'R', 'N', 'B', 'Q', 'K', 'B', 'N', 'R' };

        // Constructor
        public Board() {
            board = new Cell[8, 8];

            for (int row = 0; row < 8; row++) {
                for (int column = 0; column < 8; column++) {
                    char symbol = pieceOrder[column];

                    switch (row) {
                        case 7:
                            symbol = char.ToLower(pieceOrder[column]);
                            board[row, column] = CreatePiece(row, column, symbol);
                            break;
                        case 0:
                            symbol = char.ToUpper(pieceOrder[column]);
                            board[row, column] = CreatePiece(row, column, symbol);
                            break;
                        case 6:     // Черные пешки - нижний регистр
                            symbol = 'p';  
                            board[row, column] = CreatePiece(row, column, symbol);
                            break;
                        case 1:     // Белые пешки - верхний регистр
                            symbol = 'P'; 
                            board[row, column] = CreatePiece(row, column, symbol);
                            break;
                        default:
                            board[row, column] = new Cell(row, column);
                            break;
                    }
                }
            }
        }

        // Methods
        private Cell CreatePiece(int row, int column, char symbol) {
            var piece = PieceFactory.Create(symbol);
            return new Cell(row, column, piece);
        }
        private bool isFriendlyFire(Cell targetCell, ChessPieceColor playerColor) {
            if (targetCell.Piece != null && targetCell.Piece.Color == playerColor) {
                return true;
            }

            return false;
        }

        public Cell GetCellAt((int x, int y) coordinates) {
            return board[coordinates.y, coordinates.x];
        }

        /// <summary>
        /// Checks, if chess piece in cell is available for using by player.
        /// </summary>
        /// <param name="coordinates">Coordinates of the cell.</param>
        /// <param name="playerColor">Color of the player.</param>
        /// <returns>Returns true, if cell has player's pieces.</returns>
        public bool CanSelectPiece((int x, int y) coordinates, ChessPieceColor playerColor) {
            Cell cell = board[coordinates.y, coordinates.x];

            if (!cell.HasChessPiece()) {
                return false;
            }

            if (!cell.IsOccupiedByColor(playerColor)) {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Checks, if it is possible for making a move to a cell.
        /// </summary>
        /// <param name="coordinates">Coordinates, to which cell perform a move.</param>
        /// <param name="playerColor">Color of the player.</param>
        /// <returns>Returns Move if cell is empty, Attack if cell contains a chess piece with a different color.</returns>
        public MoveOutcome CanMoveTo((int x, int y) fromCoordinates, (int x, int y) toCoordinates, ChessPieceColor playerColor) {
            Cell fromCell = board[fromCoordinates.y, fromCoordinates.x];
            Cell toCell = board[toCoordinates.y, toCoordinates.x];

            if (fromCell.Piece.Color != playerColor) {
                return MoveOutcome.Invalid; 
            }

            if (!fromCell.Piece.IsValidMove(board, fromCoordinates, toCoordinates)) {
                return MoveOutcome.Invalid;
            }

            if (!toCell.HasChessPiece()) {
                return MoveOutcome.Move;
            }

            if (isFriendlyFire(toCell, playerColor)) {
                return MoveOutcome.Invalid;
            }

            return MoveOutcome.Attack;
        }

        public bool IsKingCaptured((int x, int y) coordinates) {
            Cell cell = GetCellAt(coordinates);

            if (cell.HasChessPiece()) {
                if (cell.Piece.Name == "King") {
                    return true;
                } else {
                    return false;
                }
            } else {
                return false;
            }
        }

        public void MovePiece(Cell fromCell, (int x, int y) toCoordinates) {
            ChessPiece movingPiece = fromCell.Piece;
            fromCell.SetPiece(null);

            Cell destinationCell = board[toCoordinates.y, toCoordinates.x];
            destinationCell.SetPiece(movingPiece);
        }

        public override string ToString() {
            char[] columns = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };

            StringBuilder builder = new StringBuilder();

            builder.Append("  ");
            foreach (char col in columns) {
                builder.Append(col).Append(' ');
            }
            builder.AppendLine();
            builder.AppendLine();

            for (int row = 7; row >= 0; row--) {
                builder.Append(row + 1).Append(' ');

                for (int col = 0; col < 8; col++) {
                    var cell = board[row, col];
                    char symbol;

                    if (cell == null || cell.Piece == null) {
                        symbol = '·';
                    } else {
                        symbol = cell.Symbol;
                    }
                    builder.Append(symbol).Append(' ');
                }

                builder.Append(row + 1).AppendLine();
            }

            builder.AppendLine();

            builder.Append("  ");
            foreach (char col in columns) {
                builder.Append(col).Append(' ');
            }
            builder.AppendLine();

            return builder.ToString();
        }
    }
}