using System;

namespace Chess
{
	public class ChessParser : InputParser
	{
		private bool checkFirstChar(char c)
		{
			return c >= 'A' && c <= 'Z' ? true : false;
		}
		private bool checkSecondChar(char c)
		{
			return c >= '0' && c <= '7' ? true : false;
		}
		
		public InputType parseInput(string input)
		{
			char[] dems = { ':'};
			string[] tokens = input.Split (dems);

			if(tokens.Length == 1)
			{
				char one = tokens [0] [0];
				char two = tokens [0] [1];
				return checkFirstChar(one) && checkSecondChar(two) ? InputType.LIST : InputType.INVALID;
			}

			if(tokens.Length == 2)
			{
				try{
					char one = tokens [0] [0];
					char two = tokens [0] [1];
					bool first = checkFirstChar(one) && checkSecondChar(two);

					one = tokens [1] [0];
					two = tokens [1] [1];
					bool second = checkFirstChar(one) && checkSecondChar(two);

					return first && second ? InputType.MOVE : InputType.INVALID;
				}
				catch(Exception e){
					return InputType.INVALID;
				}
			}

			return InputType.INVALID;
		}

		public Move createMove(string input)
		{
			char[] dems = { ':'};
			string[] tokens = input.Split (dems);

			Location from = createLocation (tokens[0]);
			Location to = createLocation (tokens[1]);

			return new Move(from, to);
		}

		private int convertToInt(char c)
		{
			int t = 0;
			switch(c)
			{
			case 'A':
				t = 0;
				break;
			case 'B':
				t = 1;
				break;
			case 'C':
				t = 2;
				break;
			case 'D':
				t = 3;
				break;
			case 'E':
				t = 4;
				break;
			case 'F':
				t = 5;
				break;
			case 'G':
				t = 6;
				break;
			case 'H':
				t = 7;
				break;
			}
			return t;
		}

		public Location createLocation(string input)
		{
			char one = input [0];
			char two = input [1];

			int x = convertToInt(one);
			int y = int.Parse (two.ToString());


			if(Location.isValid(x,y))
			{
				return new Location (x, y);
			}

			return null;
		}
	}
}

