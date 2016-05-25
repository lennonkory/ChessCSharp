using System;

namespace Chess
{
	public class Draw : RulesDecorator
	{
		public Draw (Rules r): base(r)
		{
		}

		public override bool GameOver(Board b, int colour)
		{
			base.GameOver (b, colour);
			Console.WriteLine ("Rules Decorator Draw");
			return false;
		}

		public override bool ValidMove(Board board, Move move, int colour)
		{
			return true;
		}

	}
}

