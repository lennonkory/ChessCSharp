using System;

namespace Chess
{
	public abstract class RulesDecorator : Rules
	{
		private Rules rules;
		
		public RulesDecorator (Rules r)
		{
			this.rules = r;
		}

		public override void SetBoard(Board b)
		{
			rules.SetBoard (b);
		}

		public override bool GameOver (Board b, int colour)
		{
			rules.GameOver (b, colour);
			return false;
		}

		public override bool ValidMove(Board board, Move move, int colour)
		{
			bool check = this.rules.ValidMove (board, move, colour);
			Console.WriteLine ("Rules Decorator");
			return check;
		}

	}
}

