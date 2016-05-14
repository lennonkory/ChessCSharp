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

		public override bool gameOver ()
		{
			rules.gameOver ();
			return false;
		}

		public override bool validMove(Board board, Move move)
		{
			return this.rules.validMove (board, move);
		}

	}
}

