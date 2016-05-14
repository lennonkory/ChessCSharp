using System;
using System.Collections.Generic;

namespace Chess
{
	public interface BoardParser
	{

		ICollection<Piece> parseBoard (string fileName);


	}
}

