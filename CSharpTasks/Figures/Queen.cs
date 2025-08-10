namespace CSharpTasks.Figures {
    public class Queen : ChessPiece {
        public Queen(string name, ChessPieceColor color) : base(name, color) {
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

            int dx = toX - fromX;
            int dy = toY - fromY;

            if (dx == 0 || dy == 0) {
                int stepX;
                if (dx == 0) {
                    stepX = 0;
                } else if (dx > 0) {
                    stepX = 1;
                } else {
                    stepX = -1;
                }

                int stepY;
                if (dy == 0) {
                    stepY = 0;
                } else if (dy > 0) {
                    stepY = 1;
                } else {
                    stepY = -1;
                }

                int currentX = fromX + stepX;
                int currentY = fromY + stepY;

                while (currentX != toX || currentY != toY) {
                    if (board[currentY, currentX].HasChessPiece()) {
                        return false; 
                    }
                    currentX += stepX;
                    currentY += stepY;
                }
                return true;
            }

            if (Math.Abs(dx) == Math.Abs(dy)) {
                int stepX;
                if (dx > 0) {
                    stepX = 1;
                } else {
                    stepX = -1;
                }

                int stepY;
                if (dy > 0) {
                    stepY = 1;
                } else {
                    stepY = -1;
                }

                int currentX = fromX + stepX;
                int currentY = fromY + stepY;

                while (currentX != toX && currentY != toY) {
                    if (board[currentY, currentX].HasChessPiece()) {
                        return false; 
                    }
                    currentX += stepX;
                    currentY += stepY;
                }
                return true;
            }

            return false;
        }
    }
}