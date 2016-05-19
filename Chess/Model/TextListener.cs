using System;
using System.Collections.Generic;

namespace Chess
{
	public class TextListener : IViewListener
	{
		private View view;

		public TextListener(View v){
			this.view = v;
		}
		
		public void SendMessage(string message){
			this.view.ShowMessage (message);
		}

		public void UpdateTurn(int turn){
			//Console.WriteLine ();
		}

		public void UpdateBoard(Board board)
		{
			this.view.DrawBoard (board);
		}


		public void ShowMoves(Board board, ICollection<Location> moves)
		{
			this.view.ShowMoves (board, moves);
		}
	}
}

