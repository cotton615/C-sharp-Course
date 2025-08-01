using System.Diagnostics;
using System.Security.Cryptography;

namespace CSharpTasks {
    public class Rook : ChessPiece {
        public Rook(string name, ChessPieceColor color) : base(name, color) {
        }

        public override bool IsValidMove(Cell[,] board, (int x, int y) fromCoordinate, (int x, int y) toCoordinate) {
            int fromX = fromCoordinate.x;
            int fromY = fromCoordinate.y;
            int toX = toCoordinate.x;
            int toY = toCoordinate.y;

            if (fromX == toX) {
                int step;
                if (toY > fromY) {
                    step = 1;
                } else {
                    step = -1;
                }
                int currentY = fromY + step;
                while (currentY != toY) {
                    if (board[currentY, fromX].HasChessPiece()) {
                        return false; 
                    }
                    currentY += step;
                }
                return true;
            }
            else if (fromY == toY) {
                int step;
                if (toX > fromX) {
                    step = 1;
                } else {
                    step = -1;
                }
                int currentX = fromX + step;
                while (currentX != toX) {
                    if (board[fromY, currentX].HasChessPiece()) {
                        return false; 
                    }
                    currentX += step;
                }
                return true;
            }

            return false;
        }
    }
}
