using System;
using System.Collections.Generic;

namespace Chess
{
	public abstract class View
	{
		public CommandListener cl;
		
		public View ()
		{
		}

		public abstract void showMessage(string message);
		public abstract void drawBoard( Board board);
		public abstract void showMoves(Board board, ICollection<Location> locations);
		public abstract void start ();
		public void setCommandListener(CommandListener cl)
		{
			this.cl = cl;
		}

	}
}

