using System;
using System.Collections.Generic;

namespace Chess
{
	public interface IViewListener
	{
		void SendMessage(string message);
		void UpdateTurn (int turn);
		void UpdateBoard(Board board);
		void ShowMoves(Board board, ICollection<Location> moves);
	}
}

