using System.Xml.Linq;

namespace CSharpTasks {
    public class Pawn : ChessPiece {
        public Pawn(string name, ChessPieceColor color) : base(name, color) {
        }

        public override bool IsValidMove(Cell[,] board, (int x, int y) fromCoordinate, (int x, int y) toCoordinate) {
            int dx = toCoordinate.x - fromCoordinate.x;
            int dy = toCoordinate.y - fromCoordinate.y;

            int direction;
            if (this.Color == ChessPieceColor.White) {
                direction = 1;
            } else {
                direction = -1;
            }

            Cell toCell = board[toCoordinate.y, toCoordinate.x];
            Cell fromCell = board[fromCoordinate.y, fromCoordinate.x];


            if (dx == 0) {
                if (dy == direction) {
                    if (!toCell.HasChessPiece()) {
                        return true;
                    } else {
                        return false;
                    }
                }

                int startRow;
                if (this.Color == ChessPieceColor.White) {
                    startRow = 1; 
                } else {
                    startRow = 6; 
                }

                if (dy == 2 * direction && fromCoordinate.y == startRow) {
                    int intermediateY = fromCoordinate.y + direction;
                    if (!board[intermediateY, fromCoordinate.x].HasChessPiece() && !toCell.HasChessPiece()) {
                        return true;
                    } else {
                        return false;
                    }
                }

                return false;
            }

            if ((dx == 1 || dx == -1) && dy == direction) {
                if (toCell.HasChessPiece() && toCell.Piece.Color != this.Color) {
                    return true;
                } else {
                    return false;
                }
            }
            return false; 
        }
    }
}