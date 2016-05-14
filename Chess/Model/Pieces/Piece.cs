using System;
using System.Collections.Generic;

namespace Chess
{
	public abstract class Piece
	{

		private Location location;
		public readonly string colour;
		private string name;

		public string Symbol {
			get;set;
		}

		public string Name
		{
			get{ return name;}
			set{ name = value;}
		}

		public Location Location{
			get{ return location;}
			set{ location = value;}
		}

		public Piece (string c, Location l)
		{
			this.colour = c;
			this.location = new Location (l);
		}

		public Piece (Location l)
		{
			this.colour = "none";
			this.location = new Location (l);
		}

		public Piece (Piece p)
		{
			this.colour = p.colour;
			this.location = new Location (p.location);
		}

		public abstract ICollection<Location> getMoves (Board board, Rules rules);

		public abstract MoveType canMove (Board board, Rules rules, Location to);

		public bool playerPieceOnLocation(Board b, Location to)
		{
			return b.getPieceColour (to).Equals (this.colour); 
		}

		public override string ToString()
		{
			return "Name: " + this.Name + " Location: " + this.Location;
		}

	}
}

