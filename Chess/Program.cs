using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Chess
{
    class MainClass
	{
        /// <summary>
        /// Used to Test functionallity above unit testing.
        /// </summary>
        /// <param name="b"></param>
        /// <param name="m"></param>
		public static void test(Board b, Move m)
		{

			b.MovePiece (m);

			if (m.To.Xcord - m.From.Xcord > 0) {//Castling right
				b.MovePiece (new Move (new Location (7, m.To.Ycord), new Location (5, m.To.Ycord)));
			}
			else 
			{
				b.MovePiece (new Move (new Location (0, m.To.Ycord), new Location (3, m.To.Ycord)));
			}

		}

        /// <summary>
        /// Sets up a chess game. This functionality will be replace with a Factory pattern.
        /// </summary>
		public static void Play()
		{
			IBoardParser bp = new ChessBoardParser ();
			string boardName = "board2.txt";
			ICollection<Piece> pieces = bp.ParseBoard ("../../boards/"+boardName);

			Board b = new Board (new SetUpChessBoard(), pieces);
			View v = new TextView ();

			Rules r = new ChessRules ();

			Game g = new ChessGame (b, null, null, r);

			Controller c = new Controller (v,g);

			v.SetCommandListener (new CommandTextListener(c));

			c.Start ();

		}
		
        /// <summary>
        /// Main starting point of program.
        /// </summary>
        /// <param name="args"></param>
		public static void Main (string[] args)
		{

            Play();
		
		}
	}
}
