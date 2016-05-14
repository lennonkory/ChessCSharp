using System;

namespace Chess
{
	public class ChessRules : Rules
	{
		public ChessRules ()
		{
		}

		public override bool gameOver()
		{
			Console.WriteLine ("Chess Rules");
			return false;
		}

		public override bool validMove(Board board, Move move)
		{
			return true;
		}

	}
}

