using System;
using System.Collections.Generic;

namespace Chess
{
	public class Rook : Piece
	{
		public Rook (string c, Location l) : base(c, l)
		{
			this.Name = "Rook";
			if (c.Equals ("white")) {
				Symbol = "\u2656";
                Symbol = "R";
            } 
			else 
			{
				Symbol = "\u265C";
                Symbol = "r";
            }
		}

		public override ICollection<Location> getMoves (Board board, Rules rules)
		{

			ICollection<Location> list = new List<Location> ();

			//These variables remain true as long as the piece can keep moving in that direction.
			bool left = true;
			bool right = true;
			bool up = true;
			bool down = true;

			int x = 0;
			int y = 0;

			for(int i = 1; i < 8; i++)
			{
				if (right)
				{
					x = this.Location.Xcord + i; //moving right
					y = this.Location.Ycord;

					if (x > 7) {
						right = false;
					} else if (board.isEmpty (x, y)) {
						list.Add (new Location (x, y));
					} else if (board.isEnemy (this.colour, x, y)) {
						list.Add (new Location (x, y));
						right = false;
					} else 
					{
						right = false;
					}

				}

				if (left)
				{
					x = this.Location.Xcord - i; //moving left
					y = this.Location.Ycord;

					if (x < 0) {
						left = false;
					} else if (board.isEmpty (x, y)) {
						list.Add (new Location (x, y));
					} else if (board.isEnemy (this.colour, x, y)) {
						list.Add (new Location (x, y));
						left = false;
					} else
					{
						left = false;
					}
				}

				if (up)
				{
					x = this.Location.Xcord; //moving up
					y = this.Location.Ycord + i;

					if (y > 7) {
						up = false;
					} else if (board.isEmpty (x, y)) {
						list.Add (new Location (x, y));
					} else if (board.isEnemy (this.colour, x, y)) {
						list.Add (new Location (x, y));
						up = false;
					} 
					else
					{
						up = false;
					}

				}

				if (down)
				{
					x = this.Location.Xcord; //moving down
					y = this.Location.Ycord - i;

					if (y < 0) {
						down = false;
					} else if (board.isEmpty (x, y)) {
						list.Add (new Location (x, y));
					} else if (board.isEnemy (this.colour, x, y)) {
						list.Add (new Location (x, y));
						down = false;
					}
					else 
					{
						down = false;
					}
				}

			}

			return list;
		}

		public override MoveType canMove (Board board, Rules rules, Location to)
		{
			//Check if players own place in the location they are trying to move
			if (playerPieceOnLocation(board, to))
			{
				return MoveType.INVALID;
			}

			Location from = this.Location;

			if (from.Xcord != to.Xcord && from.Ycord != to.Ycord)
			{
				return MoveType.INVALID;
			}



			//Move UP or DOWN
			if(from.Xcord == to.Xcord)
			{
				int move = 0;

				if (to.Ycord - from.Ycord > 0) {//Moving up
					move = 1;
				} 
				else 
				{
					move = -1;//Moving down
				}
				int index = from.Ycord;
				while(index != to.Ycord)
				{
					index += move;
					if(index == to.Ycord)
					{
						return MoveType.NORMAL;
					}
					if(!board.isEmpty(from.Xcord, index)) // Piece can not move through other pieces
					{
						return MoveType.INVALID;
					}
				}

			}

			//Move left or right
			if(from.Ycord == to.Ycord)
			{
				int move = 0;

				if (to.Xcord - from.Xcord > 0) {//Moving up
					move = 1;
				} 
				else 
				{
					move = -1;//Moving down
				}
				int index = from.Xcord;
				while(index != to.Xcord)
				{
					index += move;
					if(index == to.Xcord)
					{
						return MoveType.NORMAL;
					}

					if(!board.isEmpty(index, from.Ycord)) // Piece can not move through other pieces
					{
						return MoveType.INVALID;
					}
				}

			}

			return MoveType.INVALID;
		}

	}
}

