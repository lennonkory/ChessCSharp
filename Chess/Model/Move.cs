using System;

namespace Chess
{
	public class Move
	{
		private Location to;
		private Location from;

		public MoveType Type {
			get;
			set;
		}

		public Location To{
			get { return to;}
			set { to = value;}
		}

		public Location From{
			get { return from;}
			set { from = value;}
		}

		public Move (Location f, Location t)
		{
			To = new Location (t);
			From = new Location (f);
		}

		public override string ToString ()
		{
			return string.Format ("[Move: To={0}, From={1}]", To, From);
		}

	}
}

