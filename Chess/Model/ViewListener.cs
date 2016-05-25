using System;
using System.Collections.Generic;

namespace Chess
{
	public interface IViewListener
	{
		void SendMessage(string message);
		void UpdateTurn (int turn);
		void UpdateBoard(Move move, Piece p);
        void SetBoard(Square[,] squares);
        void ShowMoves(ICollection<Location> moves);
	}
}

