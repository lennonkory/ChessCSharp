using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Chess
{
    /// <summary>
    /// Controller for Chess/Checkers game.
    /// </summary>
	public class Controller
	{
        private static string SaveLocation = "C:\\Users\\Kory\\Documents\\Code\\ChessNoMerge\\ChessCSharp\\Chess\\saves\\";
        private PlayerView view;
		private Game game;
		private IInputParser ip;

        /// <summary>
        /// Creates a new Controller object.
        /// </summary>
        /// <param name="view">The view the users wish to use. (Text or GUI)</param>
        /// <param name="game">The type of Game the users wish to play.</param>
		public Controller (PlayerView view, Game game)
		{
			this.view = view;
			this.game = game;
			this.ip = new ChessParser ();

			game.SetViewListener (new TextListener(this.view));

		}

        /// <summary>
        /// Initializes game and view objects.
        /// </summary>
		public void Start()
		{
			game.Start ();
			view.Start ();
            //SaveGame("game1.txt");

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
		public void Play(string command)
		{
		
			InputType parse = ip.ParseInput (command);

			if(parse == InputType.INVALID)
			{
				view.ShowMessage ("Invalid command: " + command);
			}
			else if(parse == InputType.LIST)
			{
				
			}
			else
			{
				Move move = ip.CreateMove (command);
				this.game.Turn (move);
			}

		}

        public void Play(Move move) {
            this.game.Turn(move);
            SaveGame("game1.txt");
        }

        public void SaveGame(string filename)
        {

            string en = game.GetStringPieces();
            File.WriteAllText(SaveLocation + filename, en);
        }

        public void GetListOfMoves(Location l)
        {
            game.ListMoves(l);
        }
	}
}

