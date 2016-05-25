using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.View
{
    class GuiView : PlayerView
    {
        private Gui gui;

        public GuiView(Gui g)
        {
            this.gui = g;
        }

        public override void DrawBoard()
        {
            throw new NotImplementedException();
        }

        public override void MovePiece(Move move, Piece p)
        {
            this.gui.MovePiece(move, p);
        }

        public override void SetBoard(Square[,] squares)
        {
            this.gui.SetBoard(squares);
        }

        public override void ShowMessage(string message)
        {
            this.gui.Message(message);
        }

        public override void ShowMoves(ICollection<Location> locations)
        {
            this.gui.ShowMoves(locations);
        }

        public override void Start()
        {
            this.gui.SetCommandListener(this.cl);
        }
    }
}
