using System;

namespace Chess
{
    /// <summary>
    /// A board is made up of squares. A suqare has a Colour and a piece.
    /// </summary>
    /// <remarks>Colour of a square is not the same as the colour of a piece.
    /// A square must always have a piece on it. If a sqaure is 'empty' is has an empty piece on it.
    /// </remarks>
	public class Square
	{
        /// <summary>
        /// The colour of the square.
        /// </summary>
		public readonly string Colour;
		private Piece piece;
		private bool empty;

        /// <summary>
        /// Creates a new square.
        /// </summary>
        /// <param name="colour">The colour of the square.</param>
        /// <param name="p"></param>
		public Square (string colour, Piece p)
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

        /// <summary>
        /// Checks if a Square is empty.
        /// </summary>
        /// <remarks>This functionality is not setup yet (May 17)</remarks>
        /// <returns>True if empty false if not.</returns>
		public bool IsEmpty(){
			return empty;
		}

        /// <summary>
        /// Sets a new location for the square.
        /// </summary>
        /// <param name="l">New location</param>
        /// <see cref="Location"/>
		public void SetLocation(Location l){
			this.piece.Location = l;
		}

        /// <summary>
        /// Returns the current location of the square.
        /// </summary>
        /// <returns>Location of the square.</returns>
        /// <see cref="Location"/>
		public Location GetLocation(){
			return this.piece.Location;
		}

        /// <summary>
        /// Return the piece on the square.
        /// </summary>
        /// <returns>A piece.</returns>
		public Piece GetPiece(){
			return this.piece;
		}

		//May change this to piece = p;
		//Do I need to make a new copy?
        /// <summary>
        /// Sets a new piece on the square
        /// </summary>
        /// <param name="p"></param>
		public void SetPiece(Piece p){
			this.piece = p;
		}

        /// <summary>
        /// ToString
        /// </summary>
        /// <returns></returns>
		public override string ToString ()
		{
			return "Colour: " + Colour + " " + this.piece.ToString();
		}

        /// <summary>
        /// Return the name of the piece on the square.
        /// </summary>
        /// <returns>Name of the piece.</returns>
		public string GetPieceName()
		{
			return piece.Name;
		}

	}
}

