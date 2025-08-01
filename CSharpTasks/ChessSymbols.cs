
namespace CSharpTasks {
    public static class ChessSymbols {
        public static readonly Dictionary<(string name, ChessPieceColor color), char> chessPieceSymbols = new Dictionary<(string name, ChessPieceColor color), char>() {
            {("Pawn",   ChessPieceColor.White), 'P'}, // Ладья
            {("Rook",   ChessPieceColor.White), 'R'}, // Конь
            {("Knight", ChessPieceColor.White), 'N'}, // Слон 
            {("Bishop", ChessPieceColor.White), 'B'}, // Ферзь
            {("Queen",  ChessPieceColor.White), 'Q'}, // Король
            {("King",   ChessPieceColor.White), 'K'}, // Пешка
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