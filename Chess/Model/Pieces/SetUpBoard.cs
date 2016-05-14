using System;
using System.Collections.Generic;

namespace Chess
{
	public interface SetUpBoard
	{
		Square[,] setUpBoard(ICollection<Piece> pieces);
		Square[,] setUpBoard();
	}
}

