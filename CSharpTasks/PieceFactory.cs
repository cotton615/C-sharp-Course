namespace CSharpTasks {
    public static class PieceFactory {
        public static ChessPiece Create(char symbol) {
            ChessPieceColor color;
            string name;

            if (char.IsUpper(symbol)) {
                color = ChessPieceColor.White;
            } else {
                color = ChessPieceColor.Black;
                symbol = char.ToUpperInvariant(symbol);
            }

            switch (symbol) {
                case 'R':
                    name = "Rook";
                    return new Rook(name, color);
                case 'P':
                    name = "Pawn";
                    return new Pawn(name, color);
                case 'N':
                    name = "Knight";
                    return new Knight(name, color);
                case 'B':
                    name = "Bishop";
                    return new Bishop(name, color);
                case 'Q':
                    name = "Queen";
                    return new Queen(name, color);
                case 'K':
                    name = "King";
                    return new King(name, color);
                default:
                    throw new ArgumentException($"PieceFactory: Unknown piece symbol: {symbol}");
                }
            }
        }
    }


