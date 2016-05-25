using System;

namespace Chess
{
    /// <summary>
    /// Information about where a piece is on a board.
    /// A board is a 2D array of squares. Location has two main
    /// variables X and Y. X for column and Y for row.
    /// Example X = 0 and Y = 0 is the top left corner of the board.
    /// </summary>
	public class Location
	{
		private int xcord;
		private int ycord;
		private int sideIndex = 0;
		private char bottomIndex = ' ';

        /// <summary>
        /// The x coordinate (column).
        /// </summary>
		public int Xcord
		{
			get { return this.xcord;}
		}

        /// <summary>
        /// The y coordinate (row)
        /// </summary>
		public int Ycord
		{
			get { return this.ycord;}
		}

        /// <summary>
        /// Creates a new location given
        /// X (column) and Y (row) points.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
		public Location(int x, int y){
			this.xcord = x;
			this.ycord = y;
		}

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="l"></param>
		public Location(Location l){
			this.xcord = l.Xcord;
			this.ycord = l.ycord;
		}

		/// <summary>
        /// Sets new location.
        /// </summary>
        /// <remarks>VALIDATE THIS</remarks>
        /// <param name="x"></param>
        /// <param name="y"></param>
		public void SetLocation(int x, int y){
			this.xcord = x;
			this.ycord = y;
		}

        /// <summary>
        /// Sets a new location.
        /// </summary>
        /// <param name="l">The new location</param>
		public void SetLocation(Location l){
			this.xcord = l.xcord;
			this.ycord = l.ycord;
		}

		private void SetIndex()
		{
			sideIndex = 8 - ycord;

			switch(xcord)
			{
				case 0:
					bottomIndex = 'A';
					break;
				case 1:
					bottomIndex = 'B';
					break;
				case 2:
					bottomIndex = 'C';
					break;
				case 3:
					bottomIndex = 'D';
					break;
				case 4:
					bottomIndex = 'E';
					break;
				case 5:
					bottomIndex = 'F';
					break;
				case 6:
					bottomIndex = 'G';
					break;
				case 7:
					bottomIndex = 'H';
					break;
			}

		}

        /// <summary>
        /// ToString method.
        /// </summary>
        /// <returns></returns>
		public override string ToString ()
		{
			SetIndex ();
			return "X: " + this.Xcord + "("+bottomIndex +")" + " Y: " + this.Ycord + "("+sideIndex +")";
		}

        /// <summary>
        /// Tests if a location is valid.
        /// </summary>
        /// <remarks>It maybe best to not allow the creation of a location if its not valid.</remarks>
        /// <returns>True if valid false if not.</returns>
		public bool IsValid()
		{
			if((xcord > 7 || xcord < 0) || (ycord > 7 || ycord < 0) )
			{
				return false;
			}
			return true;
		}

        /// <summary>
        /// Tests if a location is valid.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>True if valid false if not.</returns>
		public static bool IsValid(int x, int y){
			if(x > 7 || x < 0 || y > 7 || y < 0 )
			{
				return false;
			}
			return true;
		}
	}
}

