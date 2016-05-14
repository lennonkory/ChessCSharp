using System;
using System.Collections;
using System.Collections.Generic;

namespace Chess
{
	class MainClass
	{
		public static void Main (string[] args)
		{

			BoardParser bp = new ChessBoardParser ();
			string boardName = "board2.txt";
			ICollection<Piece> pieces = bp.parseBoard ("../../boards/"+boardName);

			Board b = new Board (new SetUpChessBoard(), pieces);
			View v = new TextView ();

			ChessRules r = new ChessRules ();
			r.setBoard (b);
			Game g = new ChessGame (b,null,null,r);

			Move m = new Move (new Location(4,5), new Location(4,2));
			Piece p = b.getPiece (4,5);

			ICollection<Location> moves = p.getMoves (b,r);

			foreach(var l in moves)
			{
				Console.WriteLine (l);
			}
			v.drawBoard (b);

			r.inCheck (b, 0);
		}
	}
}
