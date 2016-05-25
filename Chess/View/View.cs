using System;
using System.Collections.Generic;

namespace Chess
{
	public abstract class PlayerView
	{

		protected ICommandListener cl;

		public abstract void ShowMessage(string message);
        public abstract void SetBoard(Square [,] squares);
		public abstract void DrawBoard();
        public abstract void MovePiece(Move move, Piece p);
		public abstract void ShowMoves(ICollection<Location> locations);
		public abstract void Start ();

		public void SetCommandListener(ICommandListener cl)
		{
			this.cl = cl;
		}

	}
}

