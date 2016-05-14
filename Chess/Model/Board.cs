using System;
using System.Collections.Generic;

namespace Chess
{
	public class Board
	{
		private Square [,] squares;
		
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

		public Board(SetUpBoard sb)
		{
			squares = sb.setUpBoard();
		}

		//STUB
		public string getPieceColour(Location l){
			return squares[l.Ycord,l.Xcord].getPiece().colour;
		}

		public bool isEnemy(string colour, Location l){
			string oppColour = squares [l.Ycord, l.Xcord].getPiece ().colour;

			if (colour.Equals ("white") && oppColour.Equals ("black")) {
				return true;
			}
			if (colour.Equals ("black") && oppColour.Equals ("white")) {
				return true;
			}
			return false;
		}

		public bool isEnemy(string colour,int x, int y){
			
			string oppColour = squares [y, x].getPiece ().colour;

			if(colour.Equals("white") && oppColour.Equals("black")){
				return true;
			}
			if(colour.Equals("black") && oppColour.Equals("white")){
				return true;
			}
			return false;

		}

		public bool isEmpty(Location to){
			return getPiece(to).colour.Equals("none");
		}

		public bool isEmpty(int x, int y){
			return getPiece(x,y).colour.Equals("none");
		}

		public void printBoard()
		{
			for(int y = 0; y < 8; y++){
				for(int x = 0; x < 8; x++){
					Console.WriteLine (squares[y,x].ToString());
				}
				Console.WriteLine ();
			}
		}

		public Square getSquare(int x, int y)
		{
			return squares [y, x];
		}

		public Piece getPiece(Location l)
		{
			return squares [l.Ycord, l.Xcord].getPiece();
		}

		public Piece getPiece(int x, int y)
		{
			return squares [y, x].getPiece();
		}

		public void setPiece(Piece p){
			squares [p.Location.Ycord, p.Location.Xcord].setPiece (p);
		}

		public void movePiece(Move move)
		{
			Location to = move.To;
			Location from = move.From;
			//REMEMBER CHECK FOR CASTLE

			if (!isEmpty (to)) { //Player captures piece
				// Remember to remove pieces from players.

			}
			Piece p = squares [from.Ycord, from.Xcord].getPiece ();
			p.Location = to;
			squares [to.Ycord, to.Xcord].setPiece (p);
			squares [from.Ycord, from.Xcord].setPiece (new Empty (from));


		}

		public int getPieceColourInt(Location from){
			string c = squares [from.Ycord, from.Xcord].getPiece ().colour;

			switch(c){
				case "white":
					return 0;
				case "black":
					return 1;
			}

			return -1;
		}

		public string getPieceName(Location location)
		{
			return squares [location.Ycord, location.Xcord].getPieceName ();
		}

		public string getPieceName(int x, int y)
		{
			return squares [y, x].getPieceName ();
		}

		public Piece findPieceByNameAndColour(string name, string colour)
		{
			foreach(Square s in squares)
			{
				
				Piece p = s.getPiece ();

				if(p.colour.Equals(colour) && p.Name.Equals(name))
				{
					return p;
				}
			}
			return null;
		}

		//Can spped this up by having a list of pieces for each player
		public ICollection<Piece> getPlayersPieces(string colour)
		{
			ICollection<Piece> pieces = new List<Piece> ();
			
			foreach(Square s in squares)
			{
				Piece p = s.getPiece ();
				if (p.colour.Equals (colour)) 
				{
					pieces.Add (p);
				}
			}

			return pieces;
		}

	}
}

