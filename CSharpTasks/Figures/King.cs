namespace CSharpTasks.Figures {
    public class King : ChessPiece {
        public King(string name, ChessPieceColor color) : base(name, color) {
        }

        public override bool IsValidMove(Cell[,] board, (int x, int y) fromCoordinates, (int x, int y) toCoordinates) {
            int dx = toCoordinates.x - fromCoordinates.x;
            int dy = toCoordinates.y - fromCoordinates.y;

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