using System;
using System.Collections.Generic;

namespace Chess
{
	public class ChessRules : Rules
	{
		public Piece KingWhite {
			get;
			set;
		}

		public Piece KingBlack {
			get;
			set;
		}
		
		public ChessRules ()
		{

		}

		public override void setBoard(Board board)
		{
			Piece p = board.findPieceByNameAndColour ("King", "white");
			Console.WriteLine ("KING: " + p.Location.ToString());
			if (p != null)
			{
				KingWhite = p;
			}

			p = board.findPieceByNameAndColour ("King", "black");
			if (p != null)
			{
				KingBlack = p;
			}

		}

		public override bool gameOver(Board b)
		{
			checkmate (b, 0);
			return false;
		}

		public override bool validMove(Board board, Move move)
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

			ICollection<Location> moves = k.getMoves (b, this);


			//Check to see if King is in check at current location
			bool check = inCheck (b, colour);

			foreach(Location l in moves )
			{
				
				Piece p = b.movePiece (new Move(k.Location, l));

				check = inCheck (b, colour);

				if(!check)
				{
					return false;
				}

				//Move King back
				k.Location = kingLocation;
				p.Location = l;
				b.setPiece (k);
				b.setPiece (p);

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

			ICollection<Piece> pieces = b.getPlayersPieces (c);

			foreach(Piece p in pieces)
			{
				//Console.Write (p + " ");
				MoveType mt = p.canMove(b, this, k.Location);
				if(mt == MoveType.NORMAL)
				{
					return true;
				}
			}

			return false;

		}

	}
}

