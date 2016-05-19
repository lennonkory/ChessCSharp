using System;
using System.Collections.Generic;

namespace Chess
{
	public interface IBoardParser
	{

		ICollection<Piece> ParseBoard (string fileName);


	}
}

