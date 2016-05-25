using System;

namespace Chess
{
	public interface ICommandListener
	{
		void SendMessage();
        void SendMessage(string message);
        void SendMessage(Move move);
        void SendMessage(Location location);
    }
}

