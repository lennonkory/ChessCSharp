using Chess.View;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms;

namespace Chess
{
    class MainClass
	{
        /// <summary>
        /// Used to Test functionallity above unit testing.
        /// </summary>
		public static void test()
		{
            ICollection<Piece> pieces = new ChessBoardParser().ParseBoard("C:\\Users\\Kory\\Documents\\Code\\ChessNoMerge\\ChessCSharp\\Chess\\boards\\foolmate.txt");

            Board board = new Board(new SetUpChessBoard(), pieces);
            Rules rules = new ChessRules();
            rules.SetBoard(board);
            bool over = rules.GameOver(board, 1);

            Console.WriteLine(over);
            Console.ReadLine();
        }

        /// <summary>
        /// Sets up a chess game. This functionality will be replace with a Factory pattern.
        /// </summary>
		public static void Play(Gui gui)
		{
            
            IBoardParser bp = new ChessBoardParser ();
			string boardName = "game1.txt";
			ICollection<Piece> pieces = bp.ParseBoard ("../../saves/"+boardName);

            Board b = new Board (new SetUpChessBoard(), pieces);
            PlayerView v = new GuiView (gui);

			Rules r = new ChessRules ();
            r.SetBoard(b);

			Game g = new ChessGame (b, null, null, r);

			Controller c = new Controller (v,g);

			v.SetCommandListener (new CommandTextListener(c));
      
            c.Start ();

		}

        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Gui g = new Gui();
            Play(g);
            Application.Run(g);
            
           // test();
            
        }
    }
}
