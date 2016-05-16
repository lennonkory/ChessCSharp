using System;
using System.Collections.Generic;

namespace Chess
{
	public class Bishop : Piece
	{
		public Bishop (string c, Location l) : base(c, l)
		{
			this.Name = "Bishop";

			if (c.Equals ("white")) {
                //Symbol = "\u2657";
                Symbol = "B";
			} 
			else 
			{
                //Symbol = "\u265D";
                Symbol = "b";
            }
		}

		private void addToList(Board board, int x, int y, int xDirection, int yDirection, ICollection<Location> list)
		{
			for(int i = 0 ; i < 8; i++)//Avoid infinit loop
			{
				x += xDirection;
				y += yDirection;

				//Console.WriteLine ("X:{0} Y:{1}",x,y);

				if (!Location.isValid (x, y)) 
				{
					return;
				}

				if(board.isEnemy(this.colour, x,y)){
					list.Add (new Location(x,y));
					return;
				}

				if(!board.isEmpty(x,y))
				{
					return;
				}

				list.Add (new Location(x,y));

			}
		}

		public override ICollection<Location> getMoves (Board board, Rules rules)
		{
			ICollection<Location> list = new List<Location>();

			int x = this.Location.Xcord;
			int y = this.Location.Ycord;
		
			addToList (board,x,y,1,1,list);
			addToList (board,x,y,1,-1,list);
			addToList (board,x,y,-1,1,list);
			addToList (board,x,y,-1,-1,list);

			return list;
		}

		public override MoveType canMove (Board board, Rules rules, Location to)
		{
			MoveType mt = MoveType.INVALID;

			//Check if players own place in the location they are trying to move
			if (playerPieceOnLocation(board, to))
			{
				return MoveType.INVALID;
			}

			Location from = this.Location;

			int x = 0;
			int y = 0;

			int xDirection = 0;
			int yDirection = 0;

			if (to.Ycord > from.Ycord) {//moving down
				yDirection = 1;
			} else {
				yDirection = -1;//moving up
			}
			if (to.Xcord > from.Xcord) {//moving right
				xDirection = 1;
			} else {
				xDirection = -1;//moving left
			}

			x = from.Xcord;
			y = from.Ycord;

			for(int i = 0 ; i < 8; i++)//Avoid infinit loop
			{
				x += xDirection;
				y += yDirection;

				//Console.WriteLine ("X:{0} Y:{1}",x,y);

				if (!Location.isValid (x, y)) 
				{
					return MoveType.INVALID;
				}

				if(x == to.Xcord && y == to.Ycord){
					return MoveType.NORMAL;
				}
			
				if(!board.isEmpty(x,y))
				{
			
					return MoveType.INVALID;
				}

			}

			return mt;

		}

	}
}

