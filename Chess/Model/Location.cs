using System;

namespace Chess
{
	public class Location
	{
		private int xcord;
		private int ycord;
		private int sideIndex = 0;
		private char bottomIndex = ' ';

		public int Xcord
		{
			get { return this.xcord;}
		}

		public int Ycord
		{
			get { return this.ycord;}
		}


		public Location(int x, int y){
			this.xcord = x;
			this.ycord = y;
		}

		public Location(Location l){
			this.xcord = l.Xcord;
			this.ycord = l.ycord;
		}

		//Create validations for x and y;
		public void setLocation(int x, int y){
			this.xcord = x;
			this.ycord = y;
		}

		public void setLocation(Location l){
			this.xcord = l.xcord;
			this.ycord = l.ycord;
		}

		private void setIndex()
		{
			sideIndex = 8 - ycord;

			switch(xcord)
			{
				case 0:
					bottomIndex = 'A';
					break;
				case 1:
					bottomIndex = 'B';
					break;
				case 2:
					bottomIndex = 'C';
					break;
				case 3:
					bottomIndex = 'D';
					break;
				case 4:
					bottomIndex = 'E';
					break;
				case 5:
					bottomIndex = 'F';
					break;
				case 6:
					bottomIndex = 'G';
					break;
				case 7:
					bottomIndex = 'H';
					break;
			}

		}

		public override string ToString ()
		{
			setIndex ();
			return "X: " + this.Xcord + "("+bottomIndex +")" + " Y: " + this.Ycord + "("+sideIndex +")";
		}

		public bool isValid()
		{
			if((xcord > 8 || xcord < 0) || (ycord > 8 || ycord < 0) )
			{
				return false;
			}
			return true;
		}

		public static bool isValid(int x, int y){
			if(x > 7 || x < 0 || y > 7 || y < 0 )
			{
				return false;
			}
			return true;
		}
	}
}

