using System;

namespace Chess
{
    /// <summary>
    /// Used for parsing board files to create a board for chess.
    /// </summary>
	public class ChessParser : IInputParser
	{

        private bool CheckFirstChar(char c)
		{
			return c >= 'A' && c <= 'Z' ? true : false;
		}

		private bool CheckSecondChar(char c)
		{
			return c >= '0' && c <= '7' ? true : false;
		}

        private int ConvertToInt(char c)
        {
            int t = 0;
            switch (c)
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

        /// <summary>
        /// Input structure for Move: FROM:TO
        /// EXAMPLE: A5:A6
        /// Input structure for List: Location
        /// EXAMPLE: A5
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public InputType ParseInput(string input)
		{
			char[] dems = { ':'};
			string[] tokens = input.Split (dems);

			if(tokens.Length == 1)
			{
				char one = tokens [0] [0];
				char two = tokens [0] [1];
				return CheckFirstChar(one) && CheckSecondChar(two) ? InputType.LIST : InputType.INVALID;
			}

			if(tokens.Length == 2)
			{
				try{
					char one = tokens [0] [0];
					char two = tokens [0] [1];
					bool first = CheckFirstChar(one) && CheckSecondChar(two);

					one = tokens [1] [0];
					two = tokens [1] [1];
					bool second = CheckFirstChar(one) && CheckSecondChar(two);

					return first && second ? InputType.MOVE : InputType.INVALID;
				}
				catch(Exception e){
					return InputType.INVALID;
				}
			}

			return InputType.INVALID;
		}

        /// <summary>
        /// Input structure: FROM:TO
        /// EXAMPLE: A5:A6
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
		public Move CreateMove(string input)
		{
			char[] dems = { ':'};
			string[] tokens = input.Split (dems);

			Location from = CreateLocation (tokens[0]);
			Location to = CreateLocation (tokens[1]);

			return new Move(from, to);
		}

        /// <summary>
        /// Input structure: Location
        /// Example: A5
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
		public Location CreateLocation(string input)
		{
			char one = input [0];
			char two = input [1];

			int x = ConvertToInt(one);
			int y = int.Parse (two.ToString());

            y = 8 - y;

			if(Location.IsValid(x,y))
			{
				return new Location (x, y);
			}

			return null;
		}
	}
}

