using System;

namespace Chess
{
	public class ChessGame : Game
	{
		
		public ChessGame (Board board, Player o, Player t, Rules rules) : base(board, o, t, rules)
		{

		}

		public override TurnType Turn(Move move)
		{

            Console.WriteLine(move);

            if (this.board.GetPieceColourInt(move.From) != playerTurn )//Not players Turn
			{
               
                Console.WriteLine("{0} {1}",this.board.GetPieceColourInt(move.From),playerTurn);
				SendMessage ("Player " + (playerTurn + 1) +" it's not your Turn");
				return TurnType.NOT_PLAYERS_TURN;
			}

			MoveType mt = board.GetPiece (move.From).CanMove (board, rules, move.To);
            Console.WriteLine(mt);
			//Move piece and update board
			if (mt == MoveType.NORMAL) {
				board.MovePiece (move);
				DrawBoard ();
				playerTurn++;
				playerTurn %= 2;
				SendMessage ("Player " + (playerTurn + 1) + " it's your Turn");
			} 
			else if (mt == MoveType.CASTLE) {
				if(rules.ValidMove (this.board, move))
				{
					
				}
			} 
			else
			{
				SendMessage ("Invalid move player " + (playerTurn + 1));
			}

			return TurnType.VALID;

		}
			
	}
}

