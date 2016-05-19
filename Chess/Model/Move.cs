using System;

namespace Chess
{
    /// <summary>
    /// This class contains information about a move a
    /// player wants to make.
    /// Its main properties are To and From.
    /// To is where the player wants to move their piece to.
    /// From is where the player wnats to move their piece from.
    /// </summary>
    /// <see cref="Location"/>
	public class Move
	{
		private Location to;
		private Location from;

        /// <summary>
        /// The type of move
        /// maybe used for castling. UPDATE THIS.
        /// </summary>
		public MoveType Type {
			get;
			set;
		}

        /// <summary>
        /// Where on the board the piece is going.
        /// </summary>
		public Location To{
			get { return to;}
			set { to = value;}
		}

        /// <summary>
        /// Where the piece is coming from.
        /// </summary>
		public Location From{
			get { return from;}
			set { from = value;}
		}

        /// <summary>
        /// Creates a new Move.
        /// </summary>
        /// <param name="f"></param>
        /// <param name="t"></param>
		public Move (Location f, Location t)
		{
			To = new Location (t);
			From = new Location (f);
		}

        /// <summary>
        /// ToString.
        /// </summary>
        /// <returns></returns>
		public override string ToString ()
		{
			return string.Format ("[Move: To={0}, From={1}]", To, From);
		}

	}
}

