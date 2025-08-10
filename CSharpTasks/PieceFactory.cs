using CSharpTasks.Figures;

namespace CSharpTasks {
    public static class PieceFactory {
        private static readonly Dictionary<ChessPieceType, Func<ChessPieceColor, ChessPiece>> _factories = 
            new Dictionary<ChessPieceType, Func<ChessPieceColor, ChessPiece>> {
            { ChessPieceType.Rook, color => new Rook("Rook", color) },
            { ChessPieceType.Pawn, color => new Pawn("Pawn", color) },
            { ChessPieceType.Knight, color => new Knight("Knight", color) },
            { ChessPieceType.Bishop, color => new Bishop("Bishop", color) },
            { ChessPieceType.Queen, color => new Queen("Queen", color) },
            { ChessPieceType.King, color => new King("King", color) }
        };

        public static ChessPiece Create(ChessPieceType pieceType, ChessPieceColor color) {
            if (_factories.TryGetValue(pieceType, out var factory)) {
                return factory(color);
            }

            throw new ArgumentException($"Unable to create chess piece with unknown pieceType: {pieceType}");
        }
    }
}