namespace TicTacToe
{
    public class PlayingPiece
    {
        public PlayingPieceType PieceType { get; set; }

        public PlayingPiece(PlayingPieceType pieceType)
        {
            PieceType = pieceType;
        }
    }
}
