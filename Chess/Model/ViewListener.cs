using System;
using System.Collections.Generic;

namespace Chess
{
	public interface ViewListener
	{
		void sendMessage(string message);
		void updateTurn (int turn);
		void updateBoard(Board board);
		void showMoves(Board board, ICollection<Location> moves);
	}
}

