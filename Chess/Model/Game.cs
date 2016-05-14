using System;

namespace Chess
{
	public abstract class Game
	{
		private Player one;
		private Player two;
		protected Board board;

		protected int playerTurn;

		protected Rules rules;

		private ViewListener vl;

		public Game (Board board, Player o, Player t)
		{
			this.one = o;
			this.two = t;
			this.board = board;
			playerTurn = 0;

		}

		public void start()
		{
			playerTurn = 0;
			sendMessage ("Player " + (playerTurn + 1) +" it's your turn");
			drawBoard ();
		}


		public void setViewListener(ViewListener vl)
		{
			this.vl = vl;
		}

		protected void drawBoard()
		{
			this.vl.updateBoard (this.board);
		}

		public abstract TurnType turn(Move move);

		public void sendMessage(string message)
		{
			this.vl.sendMessage (message);
		}
	}
}

