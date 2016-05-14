using System;

namespace Chess
{
	public class Controller
	{
		private View view;
		private Game game;
		private InputParser ip;

		public Controller (View view, Game game)
		{
			this.view = view;
			this.game = game;
			this.ip = new ChessParser ();

			game.setViewListener (new TextListener(this.view));

		}

		public void start()
		{
			game.start ();
			view.start ();

		}

		public void play(string command)
		{
			InputType parse = ip.parseInput (command);

			if(parse == InputType.INVALID)
			{
				view.showMessage ("Invalid command: " + command);
			}
			else if(parse == InputType.LIST)
			{
				
			}
			else
			{
				Move move = ip.createMove (command);
				this.game.turn (move);
			}

		}
			

	}
}

