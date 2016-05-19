using System;

namespace Chess
{
	public class Draw : RulesDecorator
	{
		public Draw (Rules r): base(r)
		{
		}

		public override bool GameOver(Board b)
		{
			base.GameOver (b);
			Console.WriteLine ("Rules Decorator Draw");
			return false;
		}

		public override bool ValidMove(Board board, Move move)
		{
			return true;
		}

	}
}

