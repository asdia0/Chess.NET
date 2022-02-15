namespace Chess.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Represents the board for a <see cref="Game"/>.
    /// </summary>
    public class Board
    {
        /// <summary>
        /// Gets or sets the rights to castle.
        /// </summary>
        public CastlingAvailability CastlingAvailability { get; set; }

        /// <summary>
        /// Gets or sets the en passant target (holy hell!) square.
        /// </summary>
        public Square EnPassantTarget { get; set; }

        /// <summary>
        /// Gets or sets the Forsyth-Edwards Notation for the current board position.
        /// </summary>
        public string FEN
        {
            get
            {
                string fen = string.Empty;

                for (int rank = 7; rank >= 0; rank--)
                {
                    int count = 0;

                    for (int file = 0; file <= 7; file++)
                    {
                        int id = (rank * 8) + file;

                        if (this.Squares[id].Piece == null)
                        {
                            count++;
                        }
                        else
                        {
                            fen += count.ToString();
                            count = 0;
                            fen += this.Squares[id].Piece.Colour == Colours.White ? this.Squares[id].Piece.Type.ToString().ToUpper() : this.Squares[id].Piece.Type.ToString().ToLower();
                        }
                    }

                    if (rank != 1)
                    {
                        fen += "/";
                    }
                }

                fen += " ";

                fen += char.ToLower(this.Turn.ToString()[0]) + " ";

                fen += this.CastlingAvailability.ToString() + " ";

                fen += this.EnPassantTarget.ToString() + " ";

                fen += this.HalfMoves.ToString() + " ";

                fen += this.Game.MoveList.Count.ToString();

                return fen;
            }

            set
            {
                string fen = value;

                fen.Replace("/", string.Empty);

                List<string> components = fen.Split(" ").ToList();

                string p = components[0];

                foreach (char c in p)
                {
                    if (char.IsDigit(c))
                    {
                        string replacement = string.Empty;

                        for (int i = 0; i < int.Parse(c.ToString()); i++)
                        {
                            replacement += "-";
                        }

                        p.Replace(c.ToString(), replacement);
                    }
                }

                for (int rank = 7; rank >= 0; rank--)
                {
                    for (int file = 0; file <= 7; file++)
                    {
                        int id = (rank * 8) + file;

                        if (p[id] == '-')
                        {
                            this.Squares[id].Piece = null;
                        }
                        else
                        {
                            this.Squares[id].Piece = new((Core.Pieces)Enum.Parse(typeof(Core.Pieces), p[id].ToString().ToUpper()), char.IsUpper(p[id]) ? Colours.White : Colours.Black, this.Squares[id]);
                        }
                    }
                }

                this.Turn = components[1] == "w" ? Colours.White : Colours.Black;

                if (components[2] == "-")
                {
                    this.CastlingAvailability = new(false, false, false, false);
                }
                else
                {
                    bool wk = false;
                    bool wq = false;
                    bool bk = false;
                    bool bq = false;

                    if (components[2].Contains("K"))
                    {
                        wk = true;
                    }

                    if (components[2].Contains("Q"))
                    {
                        wq = true;
                    }

                    if (components[2].Contains("k"))
                    {
                        bk = true;
                    }

                    if (components[2].Contains("q"))
                    {
                        bq = true;
                    }

                    this.CastlingAvailability = new(wk, wq, bk, bq);
                }

                if (components[3] == "-")
                {
                    this.EnPassantTarget = null;
                }
                else
                {
                    this.EnPassantTarget = this.Squares[((int)(components[3][0] % 32) * 8) + components[3][1]];
                }

                this.HalfMoves = int.Parse(components[4]);

                this.Moves = int.Parse(components[5]);
            }
        }

        /// <summary>
        /// Gets or sets the game the board is being played in.
        /// </summary>
        public Game Game { get; set; }

        /// <summary>
        /// Gets or sets the number of half moves since the last capture or pawn advance.
        /// </summary>
        public int HalfMoves { get; set; }

        /// <summary>
        /// Gets or sets the number of whole moves played. Starts at 1.
        /// </summary>
        public int Moves { get; set; }

        /// <summary>
        /// Gets or sets the list of <see cref="Piece"/>s belonging to the <see cref="Board"/>.
        /// </summary>
        public List<Piece> Pieces { get; set; }

        /// <summary>
        /// Gets or sets the list of <see cref="Square"/>s belonging to the <see cref="Board"/>.
        /// </summary>
        public List<Square> Squares { get; set; }

        /// <summary>
        /// Gets or sets the colour to move next.
        /// </summary>
        public Colours Turn { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Board"/> class with standard dimensions and pieces.
        /// </summary>
        /// <param name="game">The game the board is being played in.</param>
        /// <param name="FEN">The position to start from.</param>
        public Board(Game game, string FEN = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1")
        {
            for (int id = 0; id < 64; id++)
            {
                this.Squares[id] = new Square(this, new(id));
            }

            this.Game = game;
            this.FEN = FEN;
        }
    }
}