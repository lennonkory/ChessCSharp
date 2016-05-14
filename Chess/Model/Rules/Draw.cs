using System;

namespace Chess
{
	public class Draw : RulesDecorator
	{
		public Draw (Rules r): base(r)
		{
		}

		public override bool gameOver()
		{
			base.gameOver ();
			Console.WriteLine ("Rules Decorator Draw");
			return false;
		}

		public override bool validMove(Board board, Move move)
		{
			return true;
		}

	}
}

