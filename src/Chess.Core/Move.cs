namespace Chess.Core
{
    using System.Linq;

    /// <summary>
    /// Represents a move.
    /// </summary>
    public class Move
    {
        /// <summary>
        /// Gets or sets a value indicating whether the move made is a capture.
        /// </summary>
        public bool IsCapture { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the move made is a check.
        /// </summary>
        public bool IsCheck { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the move made is a mate.
        /// </summary>
        public bool IsMate { get; set; }

        /// <summary>
        /// Gets or sets a special type of move made.
        /// </summary>
        public SpecialMoves? Special { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Core.Piece"/> moved.
        /// </summary>
        public Piece Piece { get; set; }

        /// <summary>
        /// Gets or sets the previous <see cref="Square"/> of the <see cref="Piece"/> moved.
        /// </summary>
        public Square PreviousSquare { get; set; }

        /// <summary>
        /// Gets or sets the current <see cref="Square"/> of the <see cref="Piece"/> moved.
        /// </summary>
        public Square CurrentSquare { get; set; }

        /// <summary>
        /// Gets or sets the type of <see cref="Core.Piece"/> that the <see cref="Pieces.Pawn"/> promoted to.
        /// </summary>
        public Pieces? PromotionPieceType { get; set; }

        /// <summary>
        /// Gets the Portable Game Notation of the <see cref="Move"/>.
        /// </summary>
        public string PGN
        {
            get
            {
                switch (this.Special)
                {
                    case SpecialMoves.KCastle:
                        return "0-0" + (this.IsMate ? "#" : (this.IsCheck ? "+" : string.Empty));
                    case SpecialMoves.QCastle:
                        return "0-0-0" + (this.IsMate ? "#" : (this.IsCheck ? "+" : string.Empty));
                    case SpecialMoves.Promotion:
                        return $"{this.PreviousSquare.File}{(this.IsCapture ? "x" : string.Empty)}{this.CurrentSquare}={this.PromotionPieceType}{(this.IsMate ? "#" : (this.IsCheck ? "+" : string.Empty))}";
                    case null:
                        return $"{this.PromotionPieceType}{this.GetIdentifier()}{(this.IsCapture ? "x" : string.Empty)}{this.CurrentSquare}{(this.IsMate ? "#" : (this.IsCheck ? "+" : string.Empty))}";
                    default:
                        throw new ChessException("Unrecognised special move.");
                }
            }
        }

        /// <summary>
        /// Gets the Long Algebraic Notation of the <see cref="Move"/>.
        /// </summary>
        public string LAN
        {
            get
            {
                return this.PreviousSquare.ToString() + this.CurrentSquare.ToString();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Move"/> class.
        /// </summary>
        /// <param name="piece">The <see cref="Core.Piece"/> moved.</param>
        /// <param name="previousSquare">The previous <see cref="Square"/> of the <see cref="Core.Piece"/> moved.</param>
        /// <param name="currentSquare">The current <see cref="Square"/> of the <see cref="Core.Piece"/> moved.</param>
        /// <param name="isCapture">A value indicating whether the move made is a capture.</param>
        /// <param name="isCheck">A value indicating whether the move made is a check.</param>
        /// <param name="isMate">A value indicating whether the move made is a mate.</param>
        /// <param name="special">The type of special move made.</param>
        /// <param name="promotionPieceType">The type of <see cref="Core.Piece"/> that the <see cref="Pieces.Pawn"/> promoted to.</param>
        public Move(Piece piece, Square previousSquare, Square currentSquare, bool isCapture, bool isCheck, bool isMate, SpecialMoves special, Pieces? promotionPieceType = null)
        {
            this.Piece = piece;
            this.PreviousSquare = previousSquare;
            this.CurrentSquare = currentSquare;
            this.IsCapture = isCapture;
            this.IsCheck = isCheck;
            this.IsMate = isMate;
            this.Special = special;
            this.PromotionPieceType = promotionPieceType;
        }

        private string GetIdentifier()
        {
            bool rank = false;
            bool file = false;

            foreach (Piece piece in this.Piece.Board.Pieces.Where(i => i.Type == this.Piece.Type))
            {
                if (piece == this.Piece)
                {
                    continue;
                }

                if (piece.LegalSquares.Contains(this.CurrentSquare))
                {
                    if (piece.Square.Rank == this.Piece.Square.Rank)
                    {
                        rank = true;
                    }
                    else if (piece.Square.File == this.Piece.Square.File)
                    {
                        file = true;
                    }
                }
            }

            if (rank)
            {
                if (file)
                {
                    return this.PreviousSquare.ToString();
                }
                else
                {
                    return this.PreviousSquare.File;
                }
            }
            else
            {
                if (file)
                {
                    return this.PreviousSquare.Rank.ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
        }
    }
}
