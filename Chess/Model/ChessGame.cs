using System;

namespace Chess
{
	public class ChessGame : Game
	{
		public ChessGame (Board board, Player o, Player t) : base(board,o,t)
		{
		}

		public override TurnType turn(Move move)//should return ENUM if invalid (ie why is it invalid)
		{

			if(this.board.getPieceColourInt(move.From) != playerTurn )//Not players turn
			{
				sendMessage ("Player " + (playerTurn + 1) +" it's not your turn");
				return TurnType.NOT_PLAYERS_TURN;
			}

			MoveType mt = board.getPiece (move.From).canMove (board, rules, move.To);

			//Move piece and update board
			if (mt == MoveType.NORMAL) {
				board.movePiece (move);
				drawBoard ();
				playerTurn++;
				playerTurn %= 2;
				sendMessage ("Player " + (playerTurn + 1) +" it's your turn");
			} else if (mt == MoveType.CASTLE) {
				//Do castle stuff
			} 
			else
			{
				sendMessage ("Invalid move player " + (playerTurn + 1));
			}

			return TurnType.VALID;

		}

	}
}

