namespace Chess.Core
{
    using System.Linq;

    /// <summary>
    /// Represents a square on a <see cref="Board"/>.
    /// </summary>
    public class Square
    {
        /// <summary>
        /// Gets or sets the <see cref="Core.Board"/> the <see cref="Square"/> is on.
        /// </summary>
        public Board Board { get; set; }

        /// <summary>
        /// Gets or sets the x and y coordinates of the <see cref="Square"/>.
        /// </summary>
        public Position Coordinates { get; set; }

        /// <summary>
        /// Gets the number of the square's file.
        /// </summary>
        public string File
        {
            get
            {
                return ((char)this.Coordinates.X + 64).ToString();
            }
        }

        /// <summary>
        /// Gets or sets the piece <see cref="Core.Piece"/> on the <see cref="Square"/>.
        /// </summary>
        public Piece? Piece { get; set; }

        /// <summary>
        /// Gets the letter of the square's rank.
        /// </summary>
        public int Rank
        {
            get
            {
                return this.Coordinates.Y;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Square"/> class.
        /// </summary>
        /// <param name="board">The <see cref="Core.Board"/> the <see cref="Square"/> is on.</param>
        /// <param name="position">The <see cref="Coordinates"/> of the <see cref="Square"/> on the <see cref="Board"/>.</param>
        public Square(Board board, Position position)
        {
            if (board.Squares.Where(i => i.Coordinates == position).Any())
            {
                throw new ChessException($"Square with coordinates {position} already exists.");
            }
            else if (position.X > 8 || position.Y > 8 || position.X < 1 || position.Y < 1)
            {
                throw new ChessException($"Position {position} is out of range.");
            }

            this.Board = board;
            this.Coordinates = position;
        }

        /// <summary>
        /// Returns the <see cref="Square"/> n squares below of the current <see cref="Square"/>.
        /// </summary>
        /// <param name="n">The number of squares.</param>
        /// <returns>The <see cref="Square"/> n squares below of the current <see cref="Square"/>.</returns>
        public Square GetNthSquareDown(int n)
        {
            int y = this.Coordinates.Y - (8 * n);
            int x = this.Coordinates.X;

            if (y < 0 || y >= 8)
            {
                throw new ChessException("Y-coordinate out of range.");
            }

            int sqID = (y * 8) + x;

            if (sqID >= 64 || sqID < 0)
            {
                throw new ChessException("Square out of range.");
            }

            return this.Board.Squares[sqID];
        }

        /// <summary>
        /// Returns the <see cref="Square"/> n squares left of the current <see cref="Square"/>.
        /// </summary>
        /// <param name="n">The number of squares.</param>
        /// <returns>The <see cref="Square"/> n squares left of the current <see cref="Square"/>.</returns>
        public Square GetNthSquareLeft(int n)
        {
            int y = this.Coordinates.Y;
            int x = this.Coordinates.X - n;

            if (x < 0 || x >= 8)
            {
                throw new ChessException("X-coordinate out of range.");
            }

            int sqID = (y * 8) + x;

            if (sqID >= 64 || sqID < 0)
            {
                throw new ChessException("Square out of range.");
            }

            return this.Board.Squares[sqID];
        }

        /// <summary>
        /// Returns the <see cref="Square"/> n squares right of the current <see cref="Square"/>.
        /// </summary>
        /// <param name="n">The number of squares.</param>
        /// <returns>The <see cref="Square"/> n squares right of the current <see cref="Square"/>.</returns>
        public Square GetNthSquareRight(int n)
        {
            int y = this.Coordinates.Y;
            int x = this.Coordinates.X + n;

            if (x < 0 || x >= 8)
            {
                throw new ChessException("X-coordinate out of range.");
            }

            int sqID = (y * 8) + x;

            if (sqID >= 64 || sqID < 0)
            {
                throw new ChessException("Square out of range.");
            }

            return this.Board.Squares[sqID];
        }

        /// <summary>
        /// Returns the <see cref="Square"/> n squares above of the current <see cref="Square"/>.
        /// </summary>
        /// <param name="n">The number of squares.</param>
        /// <returns>The <see cref="Square"/> n squares above of the current <see cref="Square"/>.</returns>
        public Square GetNthSquareUp(int n)
        {
            int y = this.Coordinates.Y + (8 * n);
            int x = this.Coordinates.X;

            if (y < 0 || y >= 8)
            {
                throw new ChessException("Y-coordinate out of range.");
            }

            int sqID = (y * 8) + x;

            if (sqID >= 64 || sqID < 0)
            {
                throw new ChessException("Square out of range.");
            }

            return this.Board.Squares[sqID];
        }

        /// <summary>
        /// Returns the <see cref="Square"/> n squares directly opposite the current <see cref="Square"/>.
        /// </summary>
        /// <returns>The <see cref="Square"/> n squares directly opposite the current <see cref="Square"/>.</returns>
        public Square GetOppositeSquare()
        {
            int y = 7 - this.Coordinates.Y;
            int x = this.Coordinates.X;

            return this.Board.Squares[(y * 8) + x];
        }

        /// <summary>
        /// Returns a string that represents the <see cref="Coordinates"/> of this <see cref="Square"/>.
        /// </summary>
        /// <returns>The string representation of the <see cref="Coordinates"/> of this <see cref="Square"/>.</returns>
        public override string ToString()
        {
            return $"{this.File}{this.Rank}";
        }
    }
}