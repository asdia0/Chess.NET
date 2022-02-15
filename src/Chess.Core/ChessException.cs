namespace Chess.Core
{
    using System;

    /// <summary>
    /// Represents errors that occur from Chess.<see cref="Core"/>.
    /// </summary>
    public class ChessException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChessException"/> class.
        /// </summary>
        public ChessException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChessException"/> class with a message.
        /// </summary>
        /// <param name="message">The message explaining the <see cref="ChessException"/>.</param>
        public ChessException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChessException"/> class with a message along with the <see cref="Exception"/> that caused the error.
        /// </summary>
        /// <param name="message">The message explaining the <see cref="ChessException"/>.</param>
        /// <param name="inner">The <see cref="Exception"/> that caused the <see cref="ChessException"/>.</param>
        public ChessException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}