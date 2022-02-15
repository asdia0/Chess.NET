namespace Chess.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Represents a piece.
    /// </summary>
    public class Piece
    {
        private Square square;

        /// <summary>
        /// Gets or sets a value indicating whether the <see cref="Piece"/> is still on the <see cref="Board"/>.
        /// </summary>
        public bool IsCaptured { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Core.Square"/> the <see cref="Piece"/> is on.
        /// </summary>
        public Square Square
        {
            get
            {
                return this.Square;
            }

            set
            {
                if (value.Board != this.Board)
                {
                    throw new ChessException("Mismatching boards.");
                }

                this.square = value;
            }
        }

        /// <summary>
        /// Gets or sets the type of <see cref="Piece"/>.
        /// </summary>
        public Pieces Type { get; set; }

        /// <summary>
        /// Gets the list of <see cref="Square"/>s the <see cref="Piece"/> can move to in the current <see cref="Board"/> position.
        /// </summary>
        public List<Square> LegalSquares
        {
            get
            {
                // TODO: Get legal squares

                return new();
            }
        }

        public List<Move> LegalMoves
        {
            get
            {
                // TODO: Get legal moves

                return new();
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="Colours"/> of the <see cref="Piece"/>.
        /// </summary>
        public Colours Colour { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Core.Board"/> the <see cref="Piece"/> is on.
        /// </summary>
        public Board Board { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Piece"/> class.
        /// </summary>
        /// <param name="type">The type of <see cref="Piece"/>.</param>
        /// <param name="colour">The <see cref="Core.Colours"/> of the <see cref="Piece"/>.</param>
        /// <param name="square">The <see cref="Core.Square"/> the <see cref="Piece"/> is on.</param>
        public Piece(Pieces type, Colours colour, Square square)
        {
            if (square.Piece != null)
            {
                throw new ChessException($"Square {square.Coordinates} is already occupied!");
            }

            this.IsCaptured = false;
            this.Type = type;
            this.Colour = colour;
            this.Square = square;
            this.Board = square.Board;
        }
    }
}
