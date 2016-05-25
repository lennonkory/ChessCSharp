using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.View
{
    class CommandGuiListener : ICommandListener
    {
        private Controller controller;

        public CommandGuiListener(Controller c)
        {
            this.controller = c;
        }

        public void SendMessage()
        {
            throw new NotImplementedException();
        }

        public void SendMessage(Location location)
        {
            this.controller.GetListOfMoves(location);
        }

        public void SendMessage(string message)
        {
            controller.Play(message);
        }

        public void SendMessage(Move move)
        {
            controller.Play(move);
        }

    }
}
