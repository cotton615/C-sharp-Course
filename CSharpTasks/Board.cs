using System.Text;
using CSharpTasks.Figures;

namespace CSharpTasks {
    public class Board {
        // Fields
        private const int _ROWS = 8;
        private const int _COLUMNS = _ROWS;

        private Cell[,] board;
        private static readonly ChessPieceType[] pieceOrder = {
            ChessPieceType.Rook,
            ChessPieceType.Knight,
            ChessPieceType.Bishop,
            ChessPieceType.Queen,
            ChessPieceType.King,
            ChessPieceType.Bishop,
            ChessPieceType.Knight,
            ChessPieceType.Rook
        };

        // Constructor
        public Board() {
            board = new Cell[_ROWS, _COLUMNS];

            for (int row = 0; row < _ROWS; row++) {
                for (int column = 0; column < _COLUMNS; column++) {
                    ChessPieceType pieceType = pieceOrder[column];
                    Cell cell;

                    const int blackPiecesRow = 7;
                    const int blackPawnsRow = 6;

                    const int whitePawnsRow = 1;
                    const int whitePiecesRow = 0;

                    if (row == whitePiecesRow) {
                        cell = CreatePiece(pieceType, ChessPieceColor.White, row, column);
                    } else if (row == whitePawnsRow) {
                        cell = CreatePiece(ChessPieceType.Pawn, ChessPieceColor.White, row, column);
                    } else if (row == blackPawnsRow) {
                        cell = CreatePiece(ChessPieceType.Pawn, ChessPieceColor.Black, row, column);
                    } else if (row == blackPiecesRow) {
                        cell = CreatePiece(pieceType, ChessPieceColor.Black, row, column);
                    } else {
                        cell = new Cell(row, column);
                    }
                    board[row, column] = cell;
                }
            }
        }

        // Methods
        private Cell CreatePiece(ChessPieceType pieceType, ChessPieceColor color, int row, int column) {
            var piece = PieceFactory.Create(pieceType, color);
            return new Cell(row, column, piece);
        }

        private bool isFriendlyFire(Cell targetCell, ChessPieceColor playerColor) {
            if (targetCell.Piece is not null && targetCell.Piece.Color == playerColor) {
                return true;
            }

            return false;
        }
        
        public Cell GetCellAt((int x, int y) coordinates) {
            if (board[coordinates.y, coordinates.x] is null) {
                throw new NullReferenceException($"Unable to get Cell at coordinate ({coordinates.x},{coordinates.y})");
            }

            return board[coordinates.y, coordinates.x];
        }

        public bool CanSelectPiece((int x, int y) coordinates, ChessPieceColor playerColor) {
            Cell cell = GetCellAt(coordinates);

            if (!cell.HasChessPiece()) {
                return false;
            }

            if (!cell.IsOccupiedByColor(playerColor)) {
                return false;
            }

            return true;
        }

        public MoveOutcome ValidateMove((int x, int y) fromCoordinates, (int x, int y) destinationCoordinates, ChessPieceColor playerColor) {
            Cell fromCell = GetCellAt(fromCoordinates);
            Cell destinationCell = GetCellAt(destinationCoordinates);

            if (fromCell.Piece.Color != playerColor) {
                return MoveOutcome.Invalid;
            }

            if (!destinationCell.HasChessPiece()) {
                if (fromCell.Piece.IsValidMove(board, fromCoordinates, destinationCoordinates)) {
                    return MoveOutcome.Move;
                } 
            } else {
                if (fromCell.Piece.IsValidAttack(board, fromCoordinates, destinationCoordinates) && !isFriendlyFire(destinationCell, playerColor)) {
                    return MoveOutcome.Attack;
                } 
            }

            return MoveOutcome.Invalid;
        }

        public bool ExecuteMove((int x, int y) fromCoordinates, (int x, int y) destinationCoordinates, MoveOutcome outcome) {
            Cell fromCell = GetCellAt(fromCoordinates);
            Cell destinationCell = GetCellAt(destinationCoordinates);

            switch (outcome) {
                case MoveOutcome.Invalid:
                    throw new ArgumentException($"Unable to perform move from {fromCoordinates} to {destinationCoordinates}");

                case MoveOutcome.Move:
                    MovePiece(fromCell, destinationCoordinates);
                    return false;

                case MoveOutcome.Attack:
                    if (destinationCell.Piece is King) {
                        MovePiece(fromCell, destinationCoordinates);
                        return true;
                    }

                    MovePiece(fromCell, destinationCoordinates);
                    return false;
            }

            return false;
        }
        public void MovePiece(Cell fromCell, (int x, int y) destinationCoordinates) {
            ChessPiece movingPiece = fromCell.Piece;
            Cell destinationCell = GetCellAt(destinationCoordinates);

            fromCell.SetPiece(null);
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

            for (int row = board.GetLength(0) - 1; row >= 0; row--) {
                builder.Append(row + 1).Append(' ');

                for (int col = 0; col < board.GetLength(1); col++) {
                    var cell = board[row, col];
                    char symbol;

                    if (cell.Piece is null) {
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