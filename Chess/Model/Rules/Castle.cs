using System;
using System.Collections.Generic;

namespace Chess
{
	public class Castle : RulesDecorator
	{
		public Castle (Rules r) : base(r)
		{
		}

		public override bool GameOver(Board b, int colour)
		{
			base.GameOver (b, colour);
			Console.WriteLine ("Rules Decorator Castle");
			return false;
		}

		private bool checkMoves(Board b, Move m, int x)
		{
			int k = b.GetPiece (m.From).Moves;
			int r = b.GetPiece (x, m.From.Ycord).Moves;

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

			string c = board.GetPieceColour (move.From);

			if (c.Equals ("white")) {
				c = "black";
			} 
			else 
			{
				c = "white";
			}

			ICollection<Piece> pieces = board.GetPlayersPieces (c);

			foreach(Piece p in pieces)
			{
				kingX += kingDirection;

				MoveType mt = p.CanMove(board, this, new Location(kingX, move.To.Ycord));

				if(mt == MoveType.NORMAL)
				{
					return false;
				}

				kingX += kingDirection;
				mt = p.CanMove(board, this, new Location(kingX, move.To.Ycord));

				if(mt == MoveType.NORMAL)
				{
					return false;
				}
				kingX = move.From.Xcord;

			}

			return true;
		}


		public override bool ValidMove(Board board, Move move, int colour)
		{
			
			base.ValidMove (board, move, colour);

			if (move.Type == MoveType.CASTLE) {
				this.castle (board, move);
			}

			Console.WriteLine ("Rules Decorator Castle");
			return true;
		}

	}
}

