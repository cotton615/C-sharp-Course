namespace CSharpTasks {
    public class Knight : ChessPiece {
        public Knight(string name, ChessPieceColor color) : base(name, color) {
        }

        public override bool IsValidMove(Cell[,] board, (int x, int y) fromCoordinate, (int x, int y) toCoordinate) {
            int dx = toCoordinate.x - fromCoordinate.x;
            int dy = toCoordinate.y - fromCoordinate.y;

            if (dx < 0) {
                dx = -dx;
            }
            if (dy < 0) {
                dy = -dy;
            }

            if ((dx == 2 && dy == 1) || (dx == 1 && dy == 2)) {
                return true;
            }

            return false;
        }

    }
}