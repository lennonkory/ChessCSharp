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

			Rules r = new ChessRules ();
			r = new Draw (r);
			r = new Castle (r);
			r.gameOver ();

		}
	}
}
