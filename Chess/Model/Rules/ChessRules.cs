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
			int colour = board.getPieceColourInt (move.From);

			Console.WriteLine(inCheck (board,colour));

			return true;
		}

		private bool checkmate(Board b, int colour)
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

			Console.WriteLine (k.Location);

			ICollection<Location> pieces = k.getMoves (b, this);

			foreach(Location l in pieces )
			{
				MoveType mt = k.canMove (b, this, l);

			}
			return false;
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
			
			Console.WriteLine (k.Location);

			ICollection<Piece> pieces = b.getPlayersPieces (c);

			foreach(Piece p in pieces)
			{
				Console.Write (p + " ");
				Console.WriteLine (p.canMove(b, this, k.Location));
			}

			return false;

		}

	}
}

