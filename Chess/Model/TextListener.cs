using System;
using System.Collections.Generic;

namespace Chess
{
	public class TextListener : IViewListener
	{
		private PlayerView view;

		public TextListener(PlayerView v){
			this.view = v;
		}
		
		public void SendMessage(string message){
			this.view.ShowMessage (message);
		}

		public void UpdateTurn(int turn){
			//Console.WriteLine ();
		}

		public void UpdateBoard(Move move, Piece p)
		{
			this.view.MovePiece(move, p);
		}


		public void ShowMoves(ICollection<Location> moves)
		{
			this.view.ShowMoves (moves);
		}

        public void SetBoard(Square[,] squares)
        {
            this.view.SetBoard(squares);
        }
    }
}

