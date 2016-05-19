using System;
using System.Collections.Generic;

namespace Chess
{
	public abstract class Player
	{
		private string colour;
		private ICollection<Piece> pieces;

		public string Colour{
			get{ return colour;}
		}
		
		public Player (string colour)
		{
			this.colour = colour;
		}

		public void RemovePiece(Piece p){
			pieces.Remove (p);
		}

		public void AddPiece(Piece p)
		{
			pieces.Add (p);
		}

		public abstract void Input ();

	}
}

