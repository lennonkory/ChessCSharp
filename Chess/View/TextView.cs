using System;
using System.Collections.Generic;

namespace Chess
{
	public class TextView : View
	{
		public TextView ()
		{
		}

		public override void DrawBoard( Board board )
		{
			for(int y = 0; y < 8; y++)
			{
				Console.Write (8 - y + " ");
				for(int x = 0; x < 8; x++)
				{
					Piece p = board.GetPiece (x, y);
					Console.Write ("[" + p.Symbol + "]");
				}
				Console.WriteLine ();
			}
			Console.WriteLine ("   A  B  C  D  E  F  G  H");
		}

		public override void ShowMessage(string message)
		{
			Console.WriteLine (message);
		}

		public override void ShowMoves(Board board, ICollection<Location> locations){

			string [,]b = new string[8,8];

			for(int y = 0; y < 8; y++)
			{
				for(int x = 0; x < 8; x++)
				{
					Piece p = board.GetPiece (x,y);
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

		public override void Start()
		{
			this.cl.SendMessage ();
		}

	}
}

