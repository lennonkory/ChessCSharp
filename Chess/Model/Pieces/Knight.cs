using System;
using System.Collections.Generic;

namespace Chess
{
	public class Knight : Piece
	{
		public Knight (string c, Location l) : base(c, l)
		{
			this.Name = "Knight";

			if (c.Equals ("white")) {
                //Symbol = "\u2658";
                Symbol = "N";
            } 
			else 
			{
				//Symbol = "\u265E";
                Symbol = "n";
            }
		}

		public override ICollection<Location> GetMoves (Board board, Rules rules)
		{
			ICollection<Location> list = new List<Location>();

			int x = this.Location.Xcord;
			int y = this.Location.Ycord;

			//Moving left

			x += 1;
			y += 2;

			Location to = new Location (x,y);

			if(to.IsValid()){
				if (!PlayerPieceOnLocation(board, to))
				{
					list.Add(to);
				}
			}

			y = this.Location.Ycord - 2;
			to = new Location (x,y);

			if(to.IsValid()){
				if (!PlayerPieceOnLocation(board, to))
				{
					list.Add(to);
				}
			}

			x = this.Location.Xcord + 2;
			y = this.Location.Ycord + 1;

			to = new Location (x,y);

			if(to.IsValid()){
				if (!PlayerPieceOnLocation(board, to))
				{
					list.Add(to);
				}
			}
				
			y = this.Location.Ycord - 1;

			to = new Location (x,y);

			if(to.IsValid()){
				if (!PlayerPieceOnLocation(board, to))
				{
					list.Add(to);
				}
			}

			//moving right
			x = this.Location.Xcord - 1;
			y = this.Location.Ycord + 2;

			to = new Location (x,y);

			if(to.IsValid()){
				if (!PlayerPieceOnLocation(board, to))
				{
					list.Add(to);
				}
			}
				
			y = this.Location.Ycord - 2;

			to = new Location (x,y);

			if(to.IsValid()){
				if (!PlayerPieceOnLocation(board, to))
				{
					list.Add(to);
				}
			}

			x = this.Location.Xcord - 2;
			y = this.Location.Ycord + 1;

			to = new Location (x,y);

			if(to.IsValid()){
				if (!PlayerPieceOnLocation(board, to))
				{
					list.Add(to);
				}
			}

			y = this.Location.Ycord - 1;

			to = new Location (x,y);

			if(to.IsValid()){
				if (!PlayerPieceOnLocation(board, to))
				{
					list.Add(to);
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

			Location from = this.Location;



			if(Math.Abs(to.Xcord - from.Xcord) == 1 && Math.Abs(to.Ycord - from.Ycord) == 2)
			{
				return MoveType.NORMAL;
			}

			if(Math.Abs(to.Xcord - from.Xcord) == 2 && Math.Abs(to.Ycord - from.Ycord) == 1)
			{
				return MoveType.NORMAL;
			}

			return mt;

		}

	}
}

