using System;
using System.Collections.Generic;

namespace Chess
{
	public class Queen : Piece
	{

		private Piece rook;
		private Piece bishop;

		public Queen (string c, Location l) : base(c, l)
		{
			this.Name = "Queen";

			if (c.Equals ("white")) {
                //Symbol = "\u2655";
                Symbol = "Q";
            } 
			else 
			{
				//Symbol = "\u265B";
                Symbol = "q";
            }

			rook = new Rook (this.colour, this.Location);
			bishop = new Bishop (this.colour, this.Location);

		}

		public override ICollection<Location> getMoves (Board board, Rules rules)
		{

			List<Location> list = new List<Location>();
			rook.Location = this.Location;
			bishop.Location = this.Location;

			list.AddRange (rook.getMoves(board, rules));
			list.AddRange (bishop.getMoves(board, rules));

			return list;

		}

		public override MoveType canMove (Board board, Rules rules, Location to)
		{
			//Set location
			rook.Location = this.Location;
			if (rook.canMove (board, rules, to) == MoveType.INVALID)
			{
				bishop.Location = this.Location;
				return bishop.canMove (board, rules, to);
			}
				return MoveType.NORMAL;
		}
			
	}
}

