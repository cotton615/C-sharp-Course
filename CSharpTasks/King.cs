namespace CSharpTasks {
    public class King : ChessPiece {
        public King(string name, ChessPieceColor color) : base(name, color) {
        }

        public override bool IsValidMove(Cell[,] board, (int x, int y) fromCoordinate, (int x, int y) toCoordinate) {
            int dx = toCoordinate.x - fromCoordinate.x;
            int dy = toCoordinate.y - fromCoordinate.y;

            if (dx < -1 || dx > 1) {
                return false;
            }
            if (dy < -1 || dy > 1) {
                return false;
            }
            if (dx == 0 && dy == 0) {
                return false; 
            }


            return true;
        }
    }
}