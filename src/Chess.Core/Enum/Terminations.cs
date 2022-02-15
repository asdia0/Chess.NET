namespace Chess.Core
{
    /// <summary>
    /// Types of <see cref="Game"/> outcomes.
    /// </summary>
    public enum Terminations
    {
        // Decisive terminations

        /// <summary>
        /// Game terminated by checkmate.
        /// </summary>
        Checkmate,

        /// <summary>
        /// Game terminated by resignation.
        /// </summary>
        Resignation,

        /// <summary>
        /// Game terminated by timeout.
        /// </summary>
        Timeout,

        // Draws

        /// <summary>
        /// Game terminated by stalemate.
        /// </summary>
        Stalemate,

        /// <summary>
        /// Game terminated by agreement.
        /// </summary>
        DrawByAgreement,

        /// <summary>
        /// Game terminated by the 50 move rule.
        /// </summary>
        FiftyMoveRule,

        /// <summary>
        /// Game terminated by timeout versus insufficient material.
        /// </summary>
        TimeoutVersusInsufficientMaterial,
    }
}