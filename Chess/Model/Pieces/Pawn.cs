using System;
using System.Collections;
using System.Collections.Generic;

namespace Chess
{
	public class Pawn : Piece
	{
		private bool firstMove;

		public Pawn (string c, Location l) : base(c, l)
		{
			firstMove = true;

			this.Name = "Pawn";

			if (c.Equals ("white")) {
                //Symbol = "\u2659";
                Symbol = "P";
            } 
			else 
			{
				//Symbol = "\u265F";
                Symbol = "p";
            }

		}

		//NEED TO CHECK ALL Y AND X FOR GOING OFF BOARD
		public override ICollection<Location> GetMoves (Board board, Rules rules)
		{
			ICollection<Location> list = new List<Location> ();

			int x = this.Location.Xcord;
			int y = 0;
			int oldy = y;

			if (this.colour.Equals ("white")) {
				y = this.Location.Ycord - 1;
			}
			else 
			{
				y = this.Location.Ycord + 1;
			}

			oldy = y;

			if(y < 8 && y >= 0){
				
				Location to = new Location (x,y);

				if (board.IsEmpty(to))
				{
					list.Add (to);
				}
				
			}
				
			if (this.colour.Equals ("white")) {
				y = this.Location.Ycord - 2;
			}
			else 
			{
				y = this.Location.Ycord + 2;
			}

			if(y < 8 && y >= 0){
				Location to = new Location (x,y);

				if (board.IsEmpty(to) && this.firstMove)
				{
					list.Add (to);
				}

			}
				
			//NEED TO EDIT FOR WEIRD PAWN ATTACK

			x = this.Location.Xcord - 1;

			y = oldy;

			if(y < 8 && y >= 0 && x < 8 && x >= 0){

				Location to = new Location (x,y);

				if (board.IsEnemy(this.colour, to))
				{
					list.Add (to);
				}

			}
				

			x  = this.Location.Xcord + 1;

			if(y < 8 && y >= 0 && x < 8 && x >= 0){

				Location to = new Location (x,y);

				if (board.IsEnemy(this.colour, to))
				{
					list.Add (to);
				}

			}

			return list;

		}

		public override MoveType CanMove (Board board, Rules rules, Location to)
		{

			MoveType mt = MoveType.INVALID;


			if (PlayerPieceOnLocation(board, to))
			{
				return MoveType.INVALID;
			}

			//Non attack move

			if(this.Location.Xcord == to.Xcord)
			{
				//CHECK IF OPP piece is in location

				if(this.colour.Equals("white"))
				{

					if((this.Location.Ycord - 1 == to.Ycord) || (this.Location.Ycord - 2 == to.Ycord && firstMove == true)){
						firstMove = false;
						return MoveType.NORMAL;
					}
				}
				else
				{
					if((this.Location.Ycord + 1 == to.Ycord) || (this.Location.Ycord + 2 == to.Ycord == true  && firstMove == true)){
						firstMove = false;
						return MoveType.NORMAL;
					}
				}
			}

			//Attacking
			if (board.IsEnemy (this.colour, to)) {//Check if OPP piece is there/ Will need to change for weird pawn rule.
				if ((this.Location.Xcord - 1 == to.Xcord) || (this.Location.Xcord + 1 == to.Xcord)) {
					if (this.colour.Equals ("white")) {
						if (this.Location.Ycord - 1 == to.Ycord) {
							return MoveType.NORMAL;
						}
					} else {
						if (this.Location.Ycord + 1 == to.Ycord) {
							return MoveType.NORMAL;
						}	
					}
				}
			}
			return mt;

		}

	}
}

