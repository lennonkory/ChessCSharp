using System;

namespace Chess
{
    /// <summary>
    /// Abstract class that controls the game being played.
    /// Can be used with Chess or Checkers.
    /// </summary>
    /// <remarks>
    /// There are protected variables that maybe set to private in the future.
    /// Player is not used at (as of May 19) all yet but will be in the future.
    /// </remarks>
	public abstract class Game
	{
		private Player one;
		private Player two;

        /// <summary>
        /// The board thats being used.
        /// </summary>
		protected Board board;

        /// <summary>
        /// Which players turn it is.
        /// </summary>
		protected int playerTurn;

        /// <summary>
        /// The rules that the game will follow.
        /// </summary>
		protected Rules rules;

		private IViewListener vl;

        /// <summary>
        /// Creates a new Game.
        /// </summary>
        /// <param name="board">The board to use.</param>
        /// <param name="o">Player one</param>
        /// <param name="t">Player two</param>
        /// <param name="r">The rules to use.</param>
        /// <see cref="Board"/>
        /// <see cref="Player"/>
        /// <see cref="Rules"/>
		public Game (Board board, Player o, Player t, Rules r)
		{
			this.one = o;
			this.two = t;
			this.board = board;
			this.rules = r;
			playerTurn = 0;

		}

        /// <summary>
        /// Starts a new game.
        /// </summary>
		public void Start()
		{
			playerTurn = 0;
			SendMessage ("Player " + (playerTurn + 1) +" it's your Turn");
			DrawBoard ();
		}

        /// <summary>
        /// Sets the view listener so the Game (model) can update the view.
        /// </summary>
        /// <param name="vl"></param>
		public void SetViewListener(IViewListener vl)
		{
			this.vl = vl;
		}

        /// <summary>
        /// Set this to private after testing.
        /// </summary>
		protected void DrawBoard()
		{
			this.vl.UpdateBoard (this.board);
		}

        /// <summary>
        /// Controls a players turn. A player will request that
        /// a move be made. If the move is succuessful the board and player turn
        /// will be updated, if not the player will be requested to make another move.
        /// </summary>
        /// <param name="move">The move the player wishes to make.</param>
        /// <returns>TurnType (if the move was successful or why it failed)</returns>
        /// <see cref="Move"/>
        /// <see cref="TurnType"/>
		public abstract TurnType Turn(Move move);

        /// <summary>
        /// Sends a message to the view. Maybe private.
        /// </summary>
        /// <param name="message"></param>
		public void SendMessage(string message)
		{
			this.vl.SendMessage (message);
		}

        /// <summary>
        /// REMOVE
        /// </summary>
        /// <param name="m"></param>
		public void Test(Move m)
		{
			this.rules.ValidMove(this.board,m);
		}
	}
}

