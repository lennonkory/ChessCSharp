using System;
using System.Collections.Generic;

namespace Chess
{
	public class TextView : PlayerView
	{
        private string [,] symbols;

		public TextView ()
		{
            symbols = new string[8, 8];
		}

		public override void DrawBoard(  )
		{
			for(int y = 0; y < 8; y++)
			{
				Console.Write (8 - y + " ");
				for(int x = 0; x < 8; x++)
				{
					
					Console.Write ("[" + symbols[y,x] + "]");
				}
				Console.WriteLine ();
			}
			Console.WriteLine ("   A  B  C  D  E  F  G  H");
		}

        public override void SetBoard(Square[,] pieces)
        {
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    Piece p = pieces[y, x].GetPiece();
                    Location loc =p.Location;
                    symbols[loc.Ycord, loc.Xcord] = p.Symbol;
                }
            }
    
            DrawBoard();
        }

        public override void MovePiece(Move move, Piece p)
        {

            Location to = move.To;
            Location from = move.From;

            string temp = symbols[to.Ycord, to.Xcord];
            symbols[to.Ycord, to.Xcord] = symbols[from.Ycord, from.Xcord];
            symbols[from.Ycord, from.Xcord] = temp;

            Location cap = p.Location;
            symbols[cap.Ycord, cap.Xcord] = p.Symbol;

            DrawBoard();
     
        }

        public override void ShowMessage(string message)
		{
			Console.WriteLine (message);
		}

        public override void ShowMoves(ICollection<Location> locations) {

            foreach (Location l in locations)
            {
                Console.WriteLine(l);
            }
		}

		public override void Start()
		{
			this.cl.SendMessage ();
		}

	}
}

