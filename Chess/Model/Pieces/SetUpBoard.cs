using System;
using System.Collections.Generic;

namespace Chess
{
    /// <summary>
    /// Sets up a board for playing. Adds pieces to the board.
    /// </summary>
	public interface ISetUpBoard
	{
        /// <summary>
        /// Given a set of pieces this method places them into the correct squares (squares are part of a board).
        /// All squares that so not a a piece associated with this will have empty pieces placed on them.
        /// </summary>
        /// <param name="pieces">The pieces to be placed on the board.</param>
        /// <returns>An array of squares.</returns>
		Square[,] SetUpBoard(ICollection<Piece> pieces);

        /// <summary>
        /// Creates a standard starting Board.
        /// </summary>
        /// <returns>An array of squares.</returns>
		Square[,] SetUpBoard();
	}
}

