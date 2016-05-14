using System;
using System.Collections.Generic;

namespace Chess
{
	public class TextListener : ViewListener
	{
		private View view;

		public TextListener(View v){
			this.view = v;
		}
		
		public void sendMessage(string message){
			this.view.showMessage (message);
		}

		public void updateTurn(int turn){
			//Console.WriteLine ();
		}

		public void updateBoard(Board board)
		{
			this.view.drawBoard (board);
		}


		public void showMoves(Board board, ICollection<Location> moves)
		{
			this.view.showMoves (board, moves);
		}
	}
}

