using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Chess
{
    class MainClass
	{
        /// <summary>
        /// Used to Test functionallity above unit testing.
        /// </summary>
        /// <param name="b"></param>
        /// <param name="m"></param>
		public static void test(Board b, Move m)
		{

			b.MovePiece (m);

			if (m.To.Xcord - m.From.Xcord > 0) {//Castling right
				b.MovePiece (new Move (new Location (7, m.To.Ycord), new Location (5, m.To.Ycord)));
			}
			else 
			{
				b.MovePiece (new Move (new Location (0, m.To.Ycord), new Location (3, m.To.Ycord)));
			}

		}

        /// <summary>
        /// Sets up a chess game. This functionality will be replace with a Factory pattern.
        /// </summary>
		public static void Play()
		{
			IBoardParser bp = new ChessBoardParser ();
			string boardName = "board2.txt";
			ICollection<Piece> pieces = bp.ParseBoard ("../../boards/"+boardName);

			Board b = new Board (new SetUpChessBoard(), pieces);
			View v = new TextView ();

			Rules r = new ChessRules ();

			Game g = new ChessGame (b, null, null, r);

			Controller c = new Controller (v,g);

			v.SetCommandListener (new CommandTextListener(c));

			c.Start ();

		}
		
        /// <summary>
        /// Main starting point of program.
        /// </summary>
        /// <param name="args"></param>
		public static void Main (string[] args)
		{


            using (SqlConnection con = new SqlConnection("Data Source=KORY-PC;Integrated Security=True"))
            {
                //
                // Open the SqlConnection.
                //
                con.Open();
                //
                // The following code uses an SqlCommand based on the SqlConnection.
                //
                using (SqlCommand command = new SqlCommand("SELECT * FROM Cat", con))

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("{0} {1} {2}",
                        reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
                    }
                }

                using (SqlCommand command = new SqlCommand("SELECT name FROM Cat Where name = 'Snack'", con))

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("{0} {1} {2}",
                        reader.GetString(0),2,3);
                    }
                }
            }

            Console.ReadLine();
		
		}
	}
}
