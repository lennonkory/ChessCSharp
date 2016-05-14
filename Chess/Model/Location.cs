using System;

namespace Chess
{
	public class Location
	{
		private int xcord;
		private int ycord;

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

		public override string ToString ()
		{
			return "X: " + this.Xcord + " Y: " + this.Ycord;
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

