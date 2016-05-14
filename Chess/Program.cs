using System;
using System.Collections;
using System.Collections.Generic;

namespace Chess
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			/*
			Board b = new Board (new SetUpChessBoard());
			View v = new TextView ();
			Game g = new ChessGame (b, new Human("white"), new Human("black"));
			Controller c = new Controller (v,g);

			v.setCommandListener (new CommandTextListener(c));

			c.start ();
			*/

			Board b = new Board (new SetUpChessBoard());

			Rules r = new ChessRules ();
			r.setBoard (b);

			Game g = new ChessGame (b, new Human("white"), new Human("black"), r);
			Move m = new Move (new Location(4, 7), new Location(4,0));
			g.test (m);
		}
	}
}
