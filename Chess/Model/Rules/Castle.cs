using System;
using System.Collections.Generic;

namespace Chess
{
	public class Castle : RulesDecorator
	{
		public Castle (Rules r) : base(r)
		{
		}

		public override bool gameOver(Board b)
		{
			base.gameOver (b);
			Console.WriteLine ("Rules Decorator Castle");
			return false;
		}

		private bool checkMoves(Board b, Move m, int x)
		{
			int k = b.getPiece (m.From).Moves;
			int r = b.getPiece (x, m.From.Ycord).Moves;

			return (k == r && r == 0);

		}

		private bool castle(Board board, Move move){

			int x = 0;
			int kingX = move.From.Xcord;
			int kingDirection = 0;

			if (move.To.Xcord - move.From.Xcord > 0) {//Castling right
				x = 7;
				kingDirection = 1;
			}
			else 
			{
				x = 0;
				kingDirection = -1;
			}

			if(!checkMoves(board,move,x))
			{
				return false;
			}

			string c = board.getPieceColour (move.From);

			if (c.Equals ("white")) {
				c = "black";
			} 
			else 
			{
				c = "white";
			}

			ICollection<Piece> pieces = board.getPlayersPieces (c);

			foreach(Piece p in pieces)
			{
				kingX += kingDirection;

				MoveType mt = p.canMove(board, this, new Location(kingX, move.To.Ycord));

				if(mt == MoveType.NORMAL)
				{
					return false;
				}

				kingX += kingDirection;
				mt = p.canMove(board, this, new Location(kingX, move.To.Ycord));

				if(mt == MoveType.NORMAL)
				{
					return false;
				}
				kingX = move.From.Xcord;

			}

			return true;
		}


		public override bool validMove(Board board, Move move)
		{
			
			base.validMove (board, move);

			if (move.Type == MoveType.CASTLE) {
				this.castle (board, move);
			}

			Console.WriteLine ("Rules Decorator Castle");
			return true;
		}

	}
}

