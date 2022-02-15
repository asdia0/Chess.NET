namespace Chess.Core
{
    /// <summary>
    /// Types of <see cref="Move"/>s.
    /// </summary>
    public enum SpecialMoves
    {
        /// <summary>
        /// Kingside castle.
        /// </summary>
        KCastle,

        /// <summary>
        /// Queenside castle.
        /// </summary>
        QCastle,

        /// <summary>
        /// Promotion.
        /// </summary>
        Promotion,
    }
}