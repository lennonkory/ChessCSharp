using System;

namespace Chess
{
	//Make abstract
	public abstract class Rules
	{
		public Rules ()
		{
		}

		public abstract void setBoard(Board b);

		//Returns true if the game is over
		public abstract bool gameOver();

		public abstract bool validMove(Board board, Move move);

	}
}

