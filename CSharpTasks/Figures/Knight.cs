namespace CSharpTasks.Figures {
    public class Knight : ChessPiece {
        public Knight(string name, ChessPieceColor color) : base(name, color) {
        }

        public override bool IsValidMove(Cell[,] board, (int x, int y) fromCoordinates, (int x, int y) toCoordinates) {
            int dx = toCoordinates.x - fromCoordinates.x;
            int dy = toCoordinates.y - fromCoordinates.y;

            if (dx < 0) {
                dx = -dx;
            }
            if (dy < 0) {
                dy = -dy;
            }

            if (dx == 2 && dy == 1 || dx == 1 && dy == 2) {
                return true;
            }

            return false;
        }

    }
}