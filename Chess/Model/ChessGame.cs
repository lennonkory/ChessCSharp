using System;

namespace Chess
{
	public class ChessGame : Game
	{
		
		public ChessGame (Board board, Player o, Player t, Rules rules) : base(board, o, t, rules)
		{

		}

		public override TurnType Turn(Move move)//should return ENUM if invalid (ie why is it invalid)
		{

			if(this.board.GetPieceColourInt(move.From) != playerTurn )//Not players Turn
			{
				SendMessage ("Player " + (playerTurn + 1) +" it's not your Turn");
				return TurnType.NOT_PLAYERS_TURN;
			}

			MoveType mt = board.GetPiece (move.From).CanMove (board, rules, move.To);

			//Move piece and update board
			if (mt == MoveType.INVALID) {
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

