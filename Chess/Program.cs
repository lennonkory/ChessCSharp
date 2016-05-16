using System;
using System.Collections;
using System.Collections.Generic;

namespace Chess
{
	class MainClass
	{
		public static void test(Board b, Move m)
		{

			b.movePiece (m);

			if (m.To.Xcord - m.From.Xcord > 0) {//Castling right
				b.movePiece (new Move (new Location (7, m.To.Ycord), new Location (5, m.To.Ycord)));
			}
			else 
			{
				b.movePiece (new Move (new Location (0, m.To.Ycord), new Location (3, m.To.Ycord)));
			}

		}

		public static void play()
		{
			BoardParser bp = new ChessBoardParser ();
			string boardName = "board2.txt";
			ICollection<Piece> pieces = bp.parseBoard ("../../boards/"+boardName);

			Board b = new Board (new SetUpChessBoard(), pieces);
			View v = new TextView ();

			Rules r = new ChessRules ();

			Game g = new ChessGame (b, null, null, r);

			Controller c = new Controller (v,g);

			v.setCommandListener (new CommandTextListener(c));

			c.start ();

		}
		
		public static void Main (string[] args)
		{

			play ();
		
		}
	}
}
