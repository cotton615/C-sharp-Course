namespace CSharpTasks.Figures {
    public class Rook : ChessPiece {
        public Rook(string name, ChessPieceColor color) : base(name, color) {
        }

        protected override bool NeedsClearPath => true;
        public override bool IsValidMove(Cell[,] board, (int x, int y) fromCoordinates, (int x, int y) toCoordinates) {
            if (NeedsClearPath && !IsPathClear(board, fromCoordinates, toCoordinates)) {
                return false;
            }

            int fromX = fromCoordinates.x;
            int fromY = fromCoordinates.y;
            int toX = toCoordinates.x;
            int toY = toCoordinates.y;

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
