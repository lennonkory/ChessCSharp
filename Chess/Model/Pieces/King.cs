using System;
using System.Collections;
using System.Collections.Generic;

namespace Chess
{
	public class King : Piece
	{
		public King (string c, Location l) : base(c, l)
		{
			this.Name = "King";

			if (c.Equals ("white")) {
				//Symbol = "\u2654";
                Symbol = "K";
            } 
			else 
			{
				//Symbol = "\u265A";
                Symbol = "k";
            }

		}

		public override ICollection<Location> GetMoves (Board board, Rules rules)
		{
			ICollection<Location> list = new List<Location>();

			for(int i = -1; i < 2; i++){
				for(int j = -1; j < 2; j++)
				{
					int x = this.Location.Xcord + i;
					int y = this.Location.Ycord + j;

					if (x >= 0 && x <= 7 && y >= 0 && y <= 7) {

						Location to = new Location (x, y);

						if (!PlayerPieceOnLocation(board, to)) {//check rules
							list.Add (to);
						}
					}
				}
			}

			return list;
		}
	
		public override MoveType CanMove (Board board, Rules rules, Location to)
		{

			MoveType mt = MoveType.INVALID;

			//Check if players own place in the location they are trying to move
			if (PlayerPieceOnLocation(board, to))
			{
				return MoveType.INVALID;
			}

			if (to.Xcord - 1 == this.Location.Xcord || to.Xcord + 1 == this.Location.Xcord) {
				if (to.Ycord - 1 == this.Location.Xcord || to.Ycord + 1 == this.Location.Xcord || to.Ycord == this.Location.Ycord) {
					//check rules
					return MoveType.NORMAL;
				} 
				else 
				{
                    return MoveType.INVALID;
				}
			}
			else if (to.Xcord == this.Location.Xcord) 
			{
         
				if (to.Ycord - 1 == this.Location.Ycord || to.Ycord + 1 == this.Location.Ycord) {
					//check rules
					return MoveType.NORMAL;
				} 
				else 
				{
                    return MoveType.INVALID;
				}
			}

			return mt;

		}

	}
}

