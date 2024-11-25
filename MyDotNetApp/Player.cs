namespace TicTacToe
{
  //  using PlayingPT; // Assuming the PlayingPiece class is in the PlayingPT namespace

    public class Player
    {
        public string Name { get; set; }
        public PlayingPiece PlayingPi { get; set; } // Changed to PlayingPiece instead of PlayingPieces

        public Player(string name, PlayingPiece playingPi)
        {
            Name = name;
            PlayingPi = playingPi;
        }
    }
}
