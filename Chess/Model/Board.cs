using System;
using System.Collections.Generic;

namespace Chess
{
    /// <summary>
    /// Board class. Controls all aspects of the board including adding and removing pieces
    /// and returning information about squares and pieces.
    /// <remarks>
    /// Validation of location and x y positions need to be done.
    /// void returns should return bool(or status enum) for success and failure
    /// </remarks>
    /// </summary>
	public class Board
	{

        private Square [,] squares;
		
        /// <summary>
        /// Creates a new standard Board. At pieces are Empty.
        /// This should be used for testing.
        /// </summary>
		public Board ()
		{
			squares = new Square[8, 8];

			string[] colours = new string[2];

			colours [0] = "black";
			colours [1] = "white";

			int colourCount = 0;

			for(int y = 0; y < 8; y++){
				for(int x = 0; x < 8; x++){
					squares [y, x] = new Square (colours[colourCount % 2], new Empty(new Location(x,y)));
					colourCount++;
				}

			}

		}

        /// <summary>
        /// Sets up a board and adds pieces to it.
        /// Generally this is how a Board would be called in production mode.
        /// </summary>
        /// <param name="sb">Definded interface which controls what pieces go on the board.</param>
		public Board(ISetUpBoard sb)
		{
			squares = sb.SetUpBoard();
		}

        /// <summary>
        /// Sets up the board using the ISetUpBoard interface and Selected pieces.
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="pieces"></param>
		public Board(ISetUpBoard sb, ICollection<Piece> pieces)
		{
			squares = sb.SetUpBoard(pieces);
		}
			
        /// <summary>
        /// Returns the colour of a piece given a location.
        /// The location is square in which the piece is on.
        /// </summary>
        /// <param name="l">The Location of the piece.</param>
        /// <returns>The colour ofthe piece.</returns>
		public string GetPieceColour(Location l){
			return squares[l.Ycord,l.Xcord].GetPiece().colour;
		}

        /// <summary>
        /// Checks to see if a Square contains an Enemy piece.
        /// </summary>
        /// <param name="colour">The players colour</param>
        /// <param name="l">The location of the square the player wants to check.</param>
        /// <returns>True if enemy false if players colour or empty.</returns>
		public bool IsEnemy(string colour, Location l){
			string oppColour = squares [l.Ycord, l.Xcord].GetPiece ().colour;

			if (colour.Equals ("white") && oppColour.Equals ("black")) {
				return true;
			}
			if (colour.Equals ("black") && oppColour.Equals ("white")) {
				return true;
			}
			return false;
		}

        /// <summary>
        /// Checks to see if a Square contains an Enemy piece using x and y coordinates.
        /// </summary>
        /// <param name="colour">The players colour</param>
        /// <param name="x">The X (column) position of the square to check.</param>
        /// <param name="y">The Y (row) position of the square to check.</param>
        /// <returns>True if enemy false if players colour or empty.</returns>
		public bool IsEnemy(string colour,int x, int y){
			
			string oppColour = squares [y, x].GetPiece ().colour;

			if(colour.Equals("white") && oppColour.Equals("black")){
				return true;
			}
			if(colour.Equals("black") && oppColour.Equals("white")){
				return true;
			}
			return false;

		}

        /// <summary>
        /// Checks if the square is empty.
        /// </summary>
        /// <param name="to">The square to check.</param>
        /// <returns>True if empty false if a piece is on the square.</returns>
		public bool IsEmpty(Location to){
			return GetPiece(to).colour.Equals("none");
		}

        /// <summary>
        /// Checks if the square is empty.
        /// </summary>
        /// <param name="x">The X (column) position of the square to check.</param>
        /// <param name="y">The Y (row) position of the square to check.</param>
        /// <returns>True if empty false if a piece is on the square.</returns>
		public bool IsEmpty(int x, int y){
			return GetPiece(x,y).colour.Equals("none");
		}

        /// <summary>
        /// Prints the squares of the board. Only used for testing.
        /// </summary>
		public void PrintBoard()
		{
			for(int y = 0; y < 8; y++){
				for(int x = 0; x < 8; x++){
					Console.WriteLine (squares[y,x].ToString());
				}
				Console.WriteLine ();
			}
		}

        /// <summary>
        /// Returns a square based on its location.
        /// </summary>
        /// <param name="x">The X (column) position of the square.</param>
        /// <param name="y">The Y (row) position of the square.</param>
        /// <returns>A square.</returns>
		public Square GetSquare(int x, int y)
		{
			return squares [y, x];
		}

        /// <summary>
        /// Returns a piece given a location.
        /// </summary>
        /// <param name="l">The location of the piece.</param>
        /// <returns>A piece</returns>
		public Piece GetPiece(Location l)
		{
			return squares [l.Ycord, l.Xcord].GetPiece();
		}

        /// <summary>
        /// Returns a piece given a location.
        /// </summary>
        /// <param name="x">The X (column) position of the piece.</param>
        /// <param name="y">The Y (row) position of the piece</param>
        /// <returns>A piece.</returns>
		public Piece GetPiece(int x, int y)
		{
			return squares [y, x].GetPiece();
		}

        /// <summary>
        /// Sets a piece.
        /// <remarks>
        /// There is no need to pass in a location as
        /// a piece contains its own location.
        /// The location of the piece MUST be set.
        /// </remarks>
        /// </summary>
        /// <param name="p">The piece to set.</param>
		public void SetPiece(Piece p){
			squares [p.Location.Ycord, p.Location.Xcord].SetPiece (p);
		}

        /// <summary>
        /// Moves a piece from one square to another.
        /// All nessacary updates will be made in this method.
        /// <remarks>This method assumes that the move is valid.
        /// No validation for Move is done in this method.
        /// </remarks>
        /// </summary>
        /// <param name="move"></param>
        /// <returns>Returns piece that was cpatured.</returns>
		public Piece MovePiece(Move move)
		{

			Location to = move.To;
			Location from = move.From;
			//REMEMBER CHECK FOR CASTLE

			if (!IsEmpty (to)) { //Player captures piece
				// Remember to remove pieces from players.

			}

			Piece p = squares [from.Ycord, from.Xcord].GetPiece ();
			Piece captured = squares [to.Ycord, to.Xcord].GetPiece ();

			p.Location = to;

			squares [to.Ycord, to.Xcord].SetPiece (p);
			squares [from.Ycord, from.Xcord].SetPiece (new Empty (from));

			p.Moves++;

			return captured;

		}

        /// <summary>
        /// Returns an integer value of the colour of a piece.
        /// 0 = white.
        /// 1 = black.
        /// -1 = Empty.
        /// </summary>
        /// <param name="l">Location of the piece.</param>
        /// <returns>integer representation of colour.</returns>
		public int GetPieceColourInt(Location l){

            string c = squares [l.Ycord, l.Xcord].GetPiece ().colour;

			switch(c){
				case "white":
					return 0;
				case "black":
					return 1;
			}

			return -1;

		}

        /// <summary>
        /// Returns the name of a piece.
        /// </summary>
        /// <param name="location">Location of the piece on the board.</param>
        /// <returns>The name of the piece.</returns>
		public string GetPieceName(Location location)
		{
			return squares [location.Ycord, location.Xcord].GetPieceName ();
		}

        /// <summary>
        /// Returns the name of a piece.
        /// </summary>
        /// <param name="x">The X (column) position of the piece.</param>
        /// <param name="y">The Y (row) position of the piece.</param>
        /// <returns>The name of the piece.</returns>
		public string GetPieceName(int x, int y)
		{
			return squares [y, x].GetPieceName ();
		}

		public Piece FindPieceByNameAndColour(string name, string colour)
		{
			foreach(Square s in squares)
			{
				
				Piece p = s.GetPiece ();

				if(p.colour.Equals(colour) && p.Name.Equals(name))
				{
					return p;
				}
			}
			return null;
		}


        /// <summary>
        /// Returns all the pieces that belong to a player.
        /// </summary>
        /// <remarks>Can spped this up by having a list of pieces for each player</remarks>
        /// <param name="colour">The players colour.</param>
        /// <returns>Collection of pieces.</returns>
        public ICollection<Piece> GetPlayersPieces(string colour)
		{
			ICollection<Piece> pieces = new List<Piece> ();
			
			foreach(Square s in squares)
			{
				Piece p = s.GetPiece ();
				if (p.colour.Equals (colour)) 
				{
					pieces.Add (p);
				}
			}

			return pieces;
		}

	}

}

