namespace CSharpTasks.Figures {
    public static class ChessSymbols {
        public static readonly Dictionary<(string name, ChessPieceColor color), char> chessPieceSymbols = new Dictionary<(string name, ChessPieceColor color), char>() {
            {("Pawn",   ChessPieceColor.White), 'P'}, // Пешка
            {("Rook",   ChessPieceColor.White), 'R'}, // Ладья
            {("Knight", ChessPieceColor.White), 'N'}, // Конь
            {("Bishop", ChessPieceColor.White), 'B'}, // Слон
            {("Queen",  ChessPieceColor.White), 'Q'}, // Королева или Ферзь
            {("King",   ChessPieceColor.White), 'K'}, // Король
            // Верхний регистр - БЕЛЫЕ

            // Нижний регистр - ЧЁРНЫЕ
            {("Pawn",   ChessPieceColor.Black), 'p'},
            {("Rook",   ChessPieceColor.Black), 'r'},
            {("Knight", ChessPieceColor.Black), 'n'},
            {("Bishop", ChessPieceColor.Black), 'b'},
            {("Queen",  ChessPieceColor.Black), 'q'},
            {("King",   ChessPieceColor.Black), 'k'},
        };
    }
}