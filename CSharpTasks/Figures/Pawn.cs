namespace CSharpTasks.Figures {
    public class Pawn : ChessPiece {
        public Pawn(string name, ChessPieceColor color) : base(name, color) {
        }

        public override bool IsValidMove(Cell[,] board, (int x, int y) fromCoordinates, (int x, int y) toCoordinates) {
            int dx = toCoordinates.x - fromCoordinates.x;
            int dy = toCoordinates.y - fromCoordinates.y;

            int direction;
            if (Color == ChessPieceColor.White) {
                direction = 1;
            } else {
                direction = -1;
            }

            if (dx != 0) {
                return false; 
            }

            Cell toCell = board[toCoordinates.y, toCoordinates.x];

            if (dy == direction && !toCell.HasChessPiece()) {
                return true;
            }

            int startRow = (Color == ChessPieceColor.White) ? 1 : 6;
            if (dy == 2 * direction && fromCoordinates.y == startRow) {
                int intermediateY = fromCoordinates.y + direction;
                if (!board[intermediateY, fromCoordinates.x].HasChessPiece() && !toCell.HasChessPiece()) {
                    return true;
                }
            }

            return false;
        }


        public override bool IsValidAttack(Cell[,] board, (int x, int y) fromCoordinate, (int x, int y) toCoordinate) {
            int dx = toCoordinate.x - fromCoordinate.x;
            int dy = toCoordinate.y - fromCoordinate.y;
            int direction;
            if (Color == ChessPieceColor.White) {
                direction = 1;
            } else {
                direction = -1;
            }

            if ((dx == 1 || dx == -1) && (dy == direction)) {
                Cell targetCell = board[toCoordinate.y, toCoordinate.x];
                if (targetCell.HasChessPiece() && targetCell.Piece.Color != this.Color) {
                    return true;
                }
            }

            return false;
        }
    }
}