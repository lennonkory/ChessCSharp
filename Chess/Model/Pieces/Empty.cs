using System;
using System.Collections;
using System.Collections.Generic;

namespace Chess
{
	public class Empty : Piece
	{
		public Empty (Location l) : base (l)
		{
			this.Name = "Empty";
			Symbol = " ";
		}

		//SHOULD this return an empty list?
		public override ICollection<Location> getMoves (Board board, Rules rules)
		{
			return null;
		}

		public override MoveType canMove (Board board, Rules rules, Location to)
		{
			return MoveType.INVALID;
		}

	}
}

