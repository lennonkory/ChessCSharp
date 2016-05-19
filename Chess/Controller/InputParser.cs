using System;

namespace Chess
{
    /// <summary>
    /// Interface for IInputParse.
    /// <remarks>Used to parse input from a user.</remarks>
    /// </summary>
	public interface IInputParser
	{
        /// <summary>
        /// Takes in user input as a string and parses that string.
        /// </summary>
        /// <remarks>The user will enter in their command. There are two types of commands:
        /// The user can try to move a piece from one square to another or the user can request to see a list
        /// of possible moves a piece can make.
        /// Note that this parse only gets that the structure of the command is correct not if the move
        /// itself are valid.
        /// </remarks>
        /// <param name="input">The string that the user entered</param>
        /// <returns>InputType. INVALID: The move requested is not a valid move
        /// LIST: The user is asking to see a list of moves their selected piece can make.
        /// MOVE: The user wishes to make a move.
        /// </returns>
		InputType ParseInput(string input);

        /// <summary>
        /// Creates a move based on an input string.
        /// </summary>
        /// <remarks>It is important to note that this method assumes that the input string is
        /// valid. Therefore it is important that a call to this function only be
        /// made AFTER pasreInput as been called and the caller varifies the move is
        /// in correct format.</remarks>
        /// <param name="input">String contains the move the user wishes to make.</param>
        /// <returns>The Move the player wishes to make. Moves consist of a Location from and a Location to.</returns>
		Move CreateMove(string input);

        /// <summary>
        /// Creates a Location object.
        /// </summary>
        /// <remarks>The Location is the piece that the user wants to view all possible moves from.
        /// CreateLocation assume that the string is in proper form. ParseInput should be called
        /// and varified before this method is called.
        /// </remarks>
        /// <param name="input">string containing the Location of the piece.</param>
        /// <returns>Location object.</returns>
		Location CreateLocation(string input);
	}
}

