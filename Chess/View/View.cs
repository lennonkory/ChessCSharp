using System;
using System.Collections.Generic;

namespace Chess
{
	public abstract class View
	{

		protected ICommandListener cl;
		
		public View (){}

		public abstract void ShowMessage(string message);
		public abstract void DrawBoard( Board board);
		public abstract void ShowMoves(Board board, ICollection<Location> locations);
		public abstract void Start ();

		public void SetCommandListener(ICommandListener cl)
		{
			this.cl = cl;
		}

	}
}

