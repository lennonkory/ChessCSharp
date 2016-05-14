using System;

namespace Chess
{
	public class Square
	{
		public readonly string Colour;
		private Piece piece;
		private bool empty;

		public Square (string colour, Piece p = null)
		{
			this.Colour = colour;
			this.piece = p;

			if(p.colour.Equals("none")){
				empty = true;
			}
			else
			{
				empty = false;
			}
		}

		public bool isEmpty(){
			return empty;
		}

		public void setLocation(Location l){
			this.piece.Location = l;
		}

		public Location getLocation(){
			return this.piece.Location;
		}

		public Piece getPiece(){
			return this.piece;
		}

		//May change this to piece = p;
		//Do I need to make a new copy?
		public void setPiece(Piece p){
			this.piece = p;
		}

		public override string ToString ()
		{
			return "Colour: " + Colour + " " + this.piece.ToString();
		}

	}
}

