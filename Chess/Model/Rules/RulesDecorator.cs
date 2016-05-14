﻿using System;

namespace Chess
{
	public abstract class RulesDecorator : Rules
	{
		private Rules rules;
		
		public RulesDecorator (Rules r)
		{
			this.rules = r;
		}

		public override void setBoard(Board b)
		{
			rules.setBoard (b);
		}

		public override bool gameOver (Board b)
		{
			rules.gameOver (b);
			return false;
		}

		public override bool validMove(Board board, Move move)
		{
			return this.rules.validMove (board, move);
		}

	}
}

