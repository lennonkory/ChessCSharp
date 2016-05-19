using System;

namespace Chess
{
	/// <summary>
    /// Contains details about the rules of the game.
    /// </summary>
	public abstract class Rules
	{
        /// <summary>
        /// Creates new rules.
        /// </summary>
		public Rules ()
		{
		}

        /// <summary>
        /// Sets any underlying variables that rules may need.
        /// This method should always be called at the start of a new Game.
        /// MAYBE place it in the constructor?
        /// </summary>
        /// <param name="b"></param>
		public abstract void SetBoard(Board b);

        /// <summary>
        /// Checks to see if the game is over.
        /// </summary>
        /// <param name="b"></param>
        /// <returns>Returns true if the game is over</returns>
        public abstract bool GameOver(Board b);

        /// <summary>
        /// Validates a move.
        /// </summary>
        /// <param name="board">The current board</param>
        /// <param name="move">the move to validate</param>
        /// <returns>True if the move is valid false if not.</returns>
        /// <see cref="Board"/>
        /// <see cref="Move"/>
		public abstract bool ValidMove(Board board, Move move);

	}
}

