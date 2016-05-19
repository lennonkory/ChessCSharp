using System;
using System.Collections.Generic;

namespace Chess
{
    /// <summary>
    /// Chess rules that must be followed.
    /// </summary>
	public class ChessRules : Rules
	{
        /// <summary>
        /// Where the white king is. Used to speed up searching for kings.
        /// </summary>
		public Piece KingWhite {
			get;
			set;
		}

        /// <summary>
        /// Where the black king is. Used to speed up searching for kings.
        /// </summary>
		public Piece KingBlack {
			get;
			set;
		}
		
        /// <summary>
        /// 
        /// </summary>
		public ChessRules ()
		{

		}

        /// <summary>
        /// Sets the location of the kings. If rules maintains the location of the kings
        /// it does not need to search for the king each time inCheck is called (which is every move).
        /// </summary>
        /// <param name="board">The current board.</param>
        /// <see cref="Board"/>
		public override void SetBoard(Board board)
		{
			Piece p = board.FindPieceByNameAndColour ("King", "white");
			Console.WriteLine ("KING: " + p.Location.ToString());

			if (p != null)
			{
				KingWhite = p;
			}

			p = board.FindPieceByNameAndColour ("King", "black");
			if (p != null)
			{
				KingBlack = p;
			}

		}

        /// <summary>
        /// Checks if the game is over.
        /// </summary>
        /// <param name="b">The current board.</param>
        /// <returns>true if game is over, false if not</returns>
        /// <see cref="Board"/>
		public override bool GameOver(Board b)
		{
			checkmate (b, 0);
			return false;
		}

        /// <summary>
        /// Checks if a move is valid or not
        /// </summary>
        /// <param name="board"></param>
        /// <param name="move"></param>
        /// <returns></returns>
		public override bool ValidMove(Board board, Move move)
		{
			Console.WriteLine ("Chess rules");

			return true;
		}

		//Public only for testing
		public bool checkmate(Board b, int colour)
		{
			Piece k = null;

			//GetType opp colour
			if (colour == 0) {
				k = KingWhite;
			} 
			else
			{
				k = KingBlack;
			}

			//Console.WriteLine (k.Location);

			Location kingLocation = new Location(k.Location);

			ICollection<Location> moves = k.GetMoves (b, this);


			//Check to see if King is in check at current location
			bool check = inCheck (b, colour);

			foreach(Location l in moves )
			{
				
				Piece p = b.MovePiece (new Move(k.Location, l));

				check = inCheck (b, colour);

				if(!check)
				{
					return false;
				}

				//Move King back
				k.Location = kingLocation;
				p.Location = l;
				b.SetPiece (k);
				b.SetPiece (p);

			}

			//What is the king is the only piece??

			return check;

		}

		public bool inCheck(Board b, int colour )
		{

			Piece k = null;

			string c = "";

			//GetType opp colour
			if (colour == 0) {
				c = "black";
				k = KingWhite;
			} 
			else
			{
				c = "white";
				k = KingBlack;
			}
			
			//Console.WriteLine (k.Location);

			ICollection<Piece> pieces = b.GetPlayersPieces (c);

			foreach(Piece p in pieces)
			{
				//Console.Write (p + " ");
				MoveType mt = p.CanMove(b, this, k.Location);
				if(mt == MoveType.NORMAL)
				{
					return true;
				}
			}

			return false;

		}

	}
}

