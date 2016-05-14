using System;

namespace Chess
{
	public class CommandTextListener : CommandListener
	{
		Controller controller;
		
		public CommandTextListener (Controller c)
		{
			this.controller = c;
		}

		public void sendMessage()
		{
			while (true) 
			{
				Console.Write (": ");
				string message = Console.ReadLine ();
				if (message.Equals ("q")) 
				{
					break;
				}
				this.controller.play (message);
			}
		}

	}
}

