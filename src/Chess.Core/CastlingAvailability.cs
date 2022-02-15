namespace Chess.Core
{
    /// <summary>
    /// Represents castling rights.
    /// </summary>
    public readonly struct CastlingAvailability
    {
        /// <summary>
        /// Gets a value indicating whether white can castle kingside.
        /// </summary>
        public bool WhiteKingside { get; init; }

        /// <summary>
        /// Gets a value indicating whether white can castle queenside.
        /// </summary>
        public bool WhiteQueenside { get; init; }

        /// <summary>
        /// Gets a value indicating whether black can castle kingside.
        /// </summary>
        public bool BlackKingside { get; init; }

        /// <summary>
        /// Gets a value indicating whether black can castle queenside.
        /// </summary>
        public bool BlackQueenside { get; init; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CastlingAvailability"/> struct.
        /// </summary>
        /// <param name="whiteKingside">A value indicating whether white can castle kingside.</param>
        /// <param name="whiteQueenside">A value indicating whether white can castle queenside.</param>
        /// <param name="blackKingside">A value indicating whether black can castle kingside.</param>
        /// <param name="blackQueenside">A value indicating whether black can castle queenside.</param>
        public CastlingAvailability(bool whiteKingside, bool whiteQueenside, bool blackKingside, bool blackQueenside)
        {
            this.WhiteKingside = whiteKingside;
            this.WhiteQueenside = whiteQueenside;
            this.BlackKingside = blackKingside;
            this.BlackQueenside = blackQueenside;
        }

        /// <summary>
        /// Gets a string that represents the castling rights. Upper case indicates white, lower case indicates black. "K" represents kingside, "Q" represents queenside.
        /// </summary>
        /// <returns>The castling rights as a string.</returns>
        public override string ToString()
        {
            string res = string.Empty;

            if (this.WhiteKingside)
            {
                res += "K";
            }

            if (this.WhiteQueenside)
            {
                res += "Q";
            }

            if (this.BlackKingside)
            {
                res += "k";
            }

            if (this.BlackQueenside)
            {
                res += "q";
            }

            return res;
        }
    }
}
