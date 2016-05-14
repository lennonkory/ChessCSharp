using System;

namespace Chess
{
	public interface InputParser
	{
		InputType parseInput(string input);
		Move createMove(string input);
		Location createLocation(string input);
	}
}

