using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Diagnostics;

namespace Chess
{
	public class ChessBoardParser : IBoardParser
	{
		private Piece CreatePiece(char p, int x, int y)
		{
			switch (p) 
			{
				case 'r':
					return new Rook ("black", new Location(x,y));
				case 'n':
					return new Knight ("black", new Location(x,y));
				case 'b':
					return new Bishop ("black", new Location(x,y));
				case 'k':
					return new King ("black", new Location(x,y));
				case 'q':
					return new Queen ("black", new Location(x,y));
				case 'p':
					return new Pawn ("black", new Location(x,y));

				case 'R':
					return new Rook ("white", new Location(x,y));
				case 'N':
					return new Knight ("white", new Location(x,y));
				case 'B':
					return new Bishop ("white", new Location(x,y));
				case 'K':
					return new King ("white", new Location(x,y));
				case 'Q':
					return new Queen ("white", new Location(x,y));
				case 'P':
					return new Pawn ("white", new Location(x,y));
				default:
					return new Empty(new Location(x,y));
			}

			return null;
		}

		public ICollection<Piece> ParseBoard (string fileName)
		{

			ICollection<Piece> pieces = new List<Piece> ();

			if(!File.Exists(fileName))
			{
				return null;
			}

			int y = 0;
			int x = 0;

			string [] lines = File.ReadAllLines(fileName);

			foreach(string i in lines)
			{
				
				foreach(char c in i)
				{
					Piece p = CreatePiece (c,x,y);
					pieces.Add (p);
					x++;
				}
				y++;
				x = 0;
			}

			return pieces;
		}
	}
}

