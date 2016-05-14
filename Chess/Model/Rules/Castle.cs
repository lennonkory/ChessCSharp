using System;

namespace Chess
{
	public class Castle : RulesDecorator
	{
		public Castle (Rules r) : base(r)
		{
		}

		public override bool gameOver()
		{
			base.gameOver ();
			Console.WriteLine ("Rules Decorator Castle");
			return false;
		}

		public override bool validMove(Board board, Move move)
		{
			return true;
		}

	}
}

