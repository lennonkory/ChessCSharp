using System;
using System.Collections.Generic;

namespace Chess
{
	public class TextView : View
	{
		public TextView ()
		{
		}

		public override void drawBoard( Board board )
		{
			for(int y = 0; y < 8; y++)
			{
				for(int x = 0; x < 8; x++)
				{
					Piece p = board.getPiece (x, y);
					Console.Write ("[" + p.Symbol + "]");
				}
				Console.WriteLine ();
			}
		}

		public override void showMessage(string message)
		{
			Console.WriteLine (message);
		}

		public override void showMoves(Board board, ICollection<Location> locations){

			string [,]b = new string[8,8];

			for(int y = 0; y < 8; y++)
			{
				for(int x = 0; x < 8; x++)
				{
					Piece p = board.getPiece (x,y);
					b[y,x]= "[" + p.Symbol + "]";
				}

			}

			foreach(Location l in locations){
				b[l.Ycord, l.Xcord] = "[*]";
			}

			for(int y = 0; y < 8; y++)
			{
				for(int x = 0 ; x < 8; x++)
				{
					Console.Write (b[y,x]);
				}
				Console.WriteLine ();
			}
		}

		public override void start()
		{
			this.cl.sendMessage ();
		}

	}
}

