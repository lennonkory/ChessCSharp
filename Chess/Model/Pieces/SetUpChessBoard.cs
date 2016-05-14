using System;
using System.Collections.Generic;

namespace Chess
{
	public class SetUpChessBoard : SetUpBoard
	{
		public SetUpChessBoard ()
		{
		}

		public Square[,] setUpBoard(ICollection<Piece> pieces)
		{
			Square[,] s = new Square[8, 8];

			string[] colours = new string[2];

			colours [0] = "black";
			colours [1] = "white";

			int colourCount = 0;

			foreach (Piece p in pieces) 
			{
				Location loc = p.Location;

				s [loc.Ycord, loc.Xcord] = new Square (colours[colourCount % 2], p);
				colourCount++;

			}

			for(int y = 2 ; y < 6; y++)
			{
				for(int x = 0 ; x < 8; x++)
				{
					s [y, x] = new Square (colours[colourCount % 2], new Empty(new Location(x,y)));
					colourCount++;
				}
			}

			return s;
		}

		public Square[,] setUpBoard()
		{
			Square[,] s = new Square[8, 8];

			string[] colours = new string[2];

			colours [0] = "black";
			colours [1] = "white";

			int colourCount = 1;

			s[7,0] = new Square (colours[0], new Rook("white", new Location(0,0)));
			s[7,1] = new Square (colours[1], new Knight("white", new Location(1,0)));
			s[7,2] = new Square (colours[0], new Bishop("white", new Location(2,0)));
			s[7,3] = new Square (colours[1], new Queen("white", new Location(3,0)));
			s[7,4] = new Square (colours[0], new King("white", new Location(4,0)));
			s[7,5] = new Square (colours[1], new Bishop("white", new Location(5,0)));
			s[7,6] = new Square (colours[0], new Knight("white", new Location(6,0)));
			s[7,7] = new Square (colours[1], new Rook("white", new Location(7,0)));

			s[0,0] = new Square (colours[1], new Rook("black", new Location(0,7)));
			s[0,1] = new Square (colours[0], new Knight("black", new Location(1,7)));
			s[0,2] = new Square (colours[1], new Bishop("black", new Location(2,7)));
			s[0,3] = new Square (colours[0], new Queen("black", new Location(3,7)));
			s[0,4] = new Square (colours[1], new King("black", new Location(4,7)));
			s[0,5] = new Square (colours[0], new Bishop("black", new Location(5,7)));
			s[0,6] = new Square (colours[1], new Knight("black", new Location(6,7)));
			s[0,7] = new Square (colours[0], new Rook("black", new Location(7,7)));

			for(int i = 0; i < 8; i++)
			{
				s[6,i] = new Square (colours[colourCount % 2], new Pawn("white", new Location(i,6)));
				s[1, 7-i] = new Square (colours[colourCount % 2], new Pawn("black", new Location(7-i,1)));
				colourCount++;
			}

			colourCount = 0;

			for(int y = 2 ; y < 6; y++){

				for(int x = 0; x < 8; x++)
				{
					s [y, x] = new Square (colours[colourCount % 2], new Empty(new Location(x,y)));
					colourCount++;
				}
				colourCount++;
			}

			return s;
		}

	}
}

