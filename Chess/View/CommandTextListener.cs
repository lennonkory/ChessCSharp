using System;

namespace Chess
{
	public class CommandTextListener : ICommandListener
	{

        private Controller controller;
		
		public CommandTextListener (Controller c)
		{
			this.controller = c;
		}

		public void SendMessage()
		{
			while (true) 
			{
				Console.Write (": ");
				string message = Console.ReadLine ();
				if (message.Equals ("q")) 
				{
					break;
				}
				this.controller.Play (message);
			}
		}

	}
}

