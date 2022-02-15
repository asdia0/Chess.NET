namespace Chess.Core
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents a chess match between two players.
    /// </summary>
    public class Game
    {
        /// <summary>
        /// Gets or sets the <see cref="Board"/> being played.
        /// </summary>
        public Board Board { get; set; }

        /// <summary>
        /// Gets the list of <see cref="Core.Move"/>s possible in the current position.
        /// </summary>
        public List<Move> LegalMoves
        {
            get
            {
                // TODO: Get legal moves
                return new();
            }
        }

        /// <summary>
        /// Gets or sets the list of <see cref="Core.Move"/>s played.
        /// </summary>
        public List<Move> MoveList { get; set; }

        /// <summary>
        /// Gets or sets the outcome of the <see cref="Game"/>.
        /// </summary>
        public GameOutcomes Outcome { get; set; }

        /// <summary>
        /// Gets the Portable Game Notation of the game.
        /// </summary>
        public string PGN
        {
            get
            {
                // TODO: Get PGN
                return string.Empty;
            }
        }

        /// <summary>
        /// Gets or sets the way the <see cref="Game"/> terminated.
        /// </summary>
        public Terminations Termination { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Game"/> class.
        /// </summary>
        /// <param name="moveList">The list of moves to play.</param>
        public Game(List<Move>? moveList = null)
        {
            this.Board = new();
            this.MoveList = moveList ?? new();
            foreach (Move move in this.MoveList)
            {
                this.Play(move);
            }
        }

        /// <summary>
        /// Plays a <see cref="Move"/>.
        /// </summary>
        /// <param name="move">The <see cref="Move"/> to play.</param>
        public void Play(Move move)
        {
        }
    }
}