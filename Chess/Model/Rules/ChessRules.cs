using System;
using System.Collections.Generic;

namespace Chess
{
    /// <summary>
    /// Chess rules that must be followed.
    /// </summary>
	public class ChessRules : Rules
	{
        /// <summary>
        /// Where the white king is. Used to speed up searching for kings.
        /// </summary>
		public Piece KingWhite {
			get;
			set;
		}

        /// <summary>
        /// Where the black king is. Used to speed up searching for kings.
        /// </summary>
		public Piece KingBlack {
			get;
			set;
		}
		
        /// <summary>
        /// 
        /// </summary>
		public ChessRules ()
		{

		}

        /// <summary>
        /// Sets the location of the kings. If rules maintains the location of the kings
        /// it does not need to search for the king each time inCheck is called (which is every move).
        /// </summary>
        /// <param name="board">The current board.</param>
        /// <see cref="Board"/>
		public override void SetBoard(Board board)
		{
			Piece p = board.FindPieceByNameAndColour ("King", "white");

			if (p != null)
			{
				KingWhite = p;
			}

			p = board.FindPieceByNameAndColour ("King", "black");

			if (p != null)
			{
				KingBlack = p;
			}

		}

        /// <summary>
        /// Checks if the game is over.
        /// </summary>
        /// <param name="b">The current board.</param>
        /// <returns>true if game is over, false if not</returns>
        /// <see cref="Board"/>
		public override bool GameOver(Board b, int colour)
		{
			return checkmate (b, colour);
		}

        /// <summary>
        /// Checks if a move is valid or not
        /// </summary>
        /// <param name="board"></param>
        /// <param name="move"></param>
        /// <returns></returns>
		public override bool ValidMove(Board board, Move move, int colour)
		{

            bool valid = false;

            valid = !inCheck(board, colour);

			return valid;
		}

        private void setKing(Location l, int colour)
        {
            if (colour == 0)
            {
                KingWhite.Location = l;
            }
            else
            {
                KingBlack.Location = l;
            }
        }

        //Public only for testing
        public bool checkmate(Board b, int colour)
        {
            Location k = null;
            string c = "";

            //GetType opp colour
            if (colour == 0) {
                k = KingWhite.Location;
                c = "white";

            }
            else
            {
                k = KingBlack.Location;
                c = "black";
            }

            //Console.WriteLine (k.Location);

            PlayerView v = new TextView();
            v.SetBoard(b.Squares);

            ICollection<Piece> pieces = b.GetPlayersPieces(c);
            bool check;

            foreach (Piece piece in pieces)
            {
                ICollection<Location> m = piece.GetMoves(b, this);

                foreach (Location l in m)
                {
                    Move move = new Move(piece.Location, l);

                    b.MovePiece(move);
                    v.SetBoard(b.Squares);

                    if (piece.Name.Equals("King"))
                    {
                        this.setKing(l, colour);
                    }

                    check = this.inCheck(b,colour);

                    b.UndoLastMove();

                    if (piece.Name.Equals("King"))
                    {
                        this.setKing(k, colour);
                    }

                    if (!check) {
                        return false;
                    }
                }

            }

            /*
            Location kingLocation = new Location(k.Location);

			ICollection<Location> moves = k.GetMoves (b, this);

            Console.WriteLine("Moves: {0}", moves.Count );

			//Check to see if King is in check at current location
			bool check = inCheck (b, colour);

			foreach(Location l in moves )
			{
				
				Piece p = b.MovePiece (new Move(k.Location, l));

				check = inCheck (b, colour);

                //Move King back
                k.Location = kingLocation;
                p.Location = l;
                b.SetPiece(k);
                b.SetPiece(p);

                if (!check)
				{
					return false;
				}

			}

			//What if the king is the only piece??
            */
			return true;

		}

		public bool inCheck(Board b, int colour )
		{

			Piece k = null;

			string c = "";

			//GetType opp colour
			if (colour == 0) {
				c = "black";
				k = KingWhite;
			} 
			else
			{
				c = "white";
				k = KingBlack;
			}
			
			//Console.WriteLine (k.Location);

			ICollection<Piece> pieces = b.GetPlayersPieces (c);

			foreach(Piece p in pieces)
			{
				Console.WriteLine (p + "  " + k.Location);
				MoveType mt = p.CanMove(b, this, k.Location);
                
				if(mt == MoveType.NORMAL)
				{
                    Console.WriteLine(p.Name);
                    return true;
				}
			}

			return false;

		}

	}
}

