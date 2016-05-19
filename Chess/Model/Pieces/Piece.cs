using System;
using System.Collections.Generic;

namespace Chess
{
    /// <summary>
    /// Contains all information and actions need to use a piece. This is an
    /// abstract class for chess pieces or checkers pieces.
    /// </summary>
	public abstract class Piece
	{

		private Location location;
        /// <summary>
        /// The colour ofthe piece.
        /// </summary>
		public readonly string colour;
		private string name;

        /// <summary>
        /// The number of moves the piece has made.
        /// <remarks>This can be used for castling and certain draw rules.</remarks>
        /// </summary>
		public int Moves {
			get;
			set;
		}

        /// <summary>
        /// The symbol of the piece.
        /// <remarks>The goal was (and this is) to use unicode chess chars
        /// for the symbol. However the command prompt for windows doesn't support it.</remarks>
        /// </summary>
		public string Symbol {
			get;set;
		}

        /// <summary>
        /// The name of the piece.
        /// </summary>
		public string Name
		{
			get{ return name;}
			set{ name = value;}
		}

        /// <summary>
        /// The lcoation of the piece.
        /// Where it is on the board.
        /// <see cref="Location"/>
        /// </summary>
		public Location Location{
			get{ return location;}
			set{ location = value;}
		}

        /// <summary>
        /// Constructor to create a piece.
        /// </summary>
        /// <param name="c">The colour of the piece.</param>
        /// <param name="l">The piece's lcoation on the board.</param>
        /// <see cref="Location"/>
		public Piece (string c, Location l)
		{
			this.colour = c;
			this.location = new Location (l);
			Moves = 0;
		}

        /// <summary>
        /// Constructor to create an Empty piece.
        /// </summary>
        /// <param name="l">The piece's lcoation on the board.</param>
		public Piece (Location l)
		{
			this.colour = "none";
			this.location = new Location (l);
			Moves = 0;
		}

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="p">The piece to copy.</param>
		public Piece (Piece p)
		{
			this.colour = p.colour;
			this.location = new Location (p.location);
			Moves = p.Moves;
		}

        /// <summary>
        /// Returns a list of all possible moves that piece can make.
        /// <remarks>As of May 19 this returns moves the piece can mark reqardless of other factors. Ie 
        /// It is illegal to move a piece if it places your king in check, however this will return that move as valid.
        /// The rules object will need to be used to check or illegal moves.
        /// </remarks>
        /// </summary>
        /// <param name="board">The board the piece is on.</param>
        /// <param name="rules">The rules that govern the game.</param>
        /// <see cref="Board"/>
        /// <see cref="Rules"/>
        /// <returns>Collection of possible moves.</returns>
		public abstract ICollection<Location> GetMoves (Board board, Rules rules);

        /// <summary>
        /// Validates if a piece can be moved to a certain location.
        /// </summary>
        /// <remarks>As of May 19 this returns moves the piece can mark reqardless of other factors. Ie 
        /// It is illegal to move a piece if it places your king in check, however this will return that move as valid.
        /// The rules object will need to be used to check or illegal moves.
        /// </remarks>
        /// <param name="board">The board the piece is on.</param>
        /// <param name="rules">The rules that govern the game.</param>
        /// <param name="to">Where the piece wants to move.</param>
        /// <see cref="Board"/>
        /// <see cref="Rules"/>
        /// <see cref="Location"/>
        /// <see cref="MoveType"/>
        /// <returns>Returns Movetype (type of move the player is trying to make).</returns>
        public abstract MoveType CanMove (Board board, Rules rules, Location to);

        /// <summary>
        /// Checks in a players piece is on a certain location.
        /// </summary>
        /// <remarks>Used to speed up checking for valid moves.
        /// There is no point checking if a move is valid if the
        /// player is trying to move onto a square where he or she already
        /// has a piece.
        /// </remarks>
        /// <param name="b">The board the piece is on.</param>
        /// <param name="to">Location to check</param>
        /// <returns>True if the location contains a piece that is the players colour false otherwise.</returns>
		public bool PlayerPieceOnLocation(Board b, Location to)
		{
			return b.GetPieceColour (to).Equals (this.colour); 
		}

        /// <summary>
        /// ToString method
        /// </summary>
        /// <returns></returns>
		public override string ToString()
		{
			return "Name: " + this.Name + " Location: " + this.Location + " Colour: " + this.colour;
		}

	}
}

