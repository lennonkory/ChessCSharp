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

            if (this.board.GetPieceColourInt(move.From) != playerTurn )//Not players Turn
			{
				SendMessage ("Player " + (playerTurn + 1) +" it's not your Turn");
				return TurnType.NOT_PLAYERS_TURN;
			}

			MoveType mt = board.GetPiece (move.From).CanMove (board, rules, move.To);

            Console.WriteLine(mt);

			//Move piece and updates board
			if (mt == MoveType.NORMAL) {

                Piece p = board.MovePiece (move);

                if (rules.ValidMove(board, move, playerTurn))
                {
                    DrawBoard(move, p);
                    //Check for game over.
                    
                    playerTurn++;
                    playerTurn %= 2;

                    if (rules.GameOver(board, playerTurn))
                    {
                        SendMessage("GameOver!!");
                        return TurnType.VALID;
                    }

                    SendMessage("Player " + (playerTurn + 1) + " it's your Turn");

                }
                else {
                    //Add better message
                    //GetErrorMessage method would be a good idea
                    board.UndoLastMove();
                    SendMessage("Invalid move player " + (playerTurn + 1) + " in check");
                }
				
			} 
			else if (mt == MoveType.CASTLE) {
				if(rules.ValidMove (this.board, move, playerTurn))
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

