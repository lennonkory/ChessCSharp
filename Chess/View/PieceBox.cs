using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess.View
{
    class PieceBox : PictureBox
    {

        //private Piece piece;
        private string pieceName;
        private Chess.Location pieceLocation;
        private string pieceColour;

        public bool Selected {
            get; set;
        }

        public Chess.Location PieceLocation { get; }

        public PieceBox(Piece p, int startX, int startY, int x, int y, int i) {

            //is this ok??
            this.pieceColour = p.colour;
            this.pieceLocation = new Location(p.Location);
  
            this.pieceName = p.Name;

            getResource(p);

            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Location = new System.Drawing.Point(startX + (p.Location.Xcord * x), startY + (p.Location.Ycord * y));
            this.Name = "p" + i;
            this.Size = new System.Drawing.Size(50, 50);
            this.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.TabIndex = 7;
            this.TabStop = false;
            SetBackGroundColor();
            this.Cursor = Cursors.Hand;

            using (var gp = new GraphicsPath())
            {
                gp.AddEllipse(new Rectangle(0, 0, this.Width - 1, this.Height - 1));
                this.Region = new Region(gp);
            }

            Selected = false;

        }

        public void SetBackGroundColor()
        {

            if (this.pieceLocation.Xcord % 2 == this.pieceLocation.Ycord % 2)
            {
                this.BackColor = Color.White;
            }
            else
            {
                this.BackColor = Color.Gray;
            }

        }

        public void SetPieceLocation(Chess.Location l)
        {
            //Is this ok??
            this.pieceLocation = l;
        }

        public Chess.Location GetPieceLocation()
        {
            return this.pieceLocation;
        }

        public string GetPieceName()
        {
            return this.pieceName;
        }

        //There has to be a better way to do this
        private void getResource(Piece piece)
        {

            if (piece.colour.Equals("white"))
            {

                if (piece.Name.Equals("King"))
                {
                    this.Image = global::Chess.Properties.Resources.wking;
                }
                else if (piece.Name.Equals("Bishop"))
                {
                    this.Image = global::Chess.Properties.Resources.wbishop;
                }
                else if (piece.Name.Equals("Rook"))
                {
                    this.Image = global::Chess.Properties.Resources.wrook;
                }
                else if (piece.Name.Equals("Queen"))
                {
                    this.Image = global::Chess.Properties.Resources.wqueen;
                }
                else if (piece.Name.Equals("Knight"))
                {
                    this.Image = global::Chess.Properties.Resources.wknight;
                }
                else if (piece.Name.Equals("Pawn"))
                {
                    this.Image = global::Chess.Properties.Resources.wpawn;
                }
            }
            else if (piece.colour.Equals("black"))
            {
                if (piece.Name.Equals("King"))
                {
                    this.Image = global::Chess.Properties.Resources.bking;
                }
                else if (piece.Name.Equals("Bishop"))
                {
                    this.Image = global::Chess.Properties.Resources.bbishop;
                }
                else if (piece.Name.Equals("Rook"))
                {
                    this.Image = global::Chess.Properties.Resources.brook;
                }
                else if (piece.Name.Equals("Queen"))
                {
                    this.Image = global::Chess.Properties.Resources.bqueen;
                }
                else if (piece.Name.Equals("Knight"))
                {
                    this.Image = global::Chess.Properties.Resources.bknight;
                }
                else if (piece.Name.Equals("Pawn"))
                {
                    this.Image = global::Chess.Properties.Resources.bpawn;
                }
            }
            else
            {
                this.Image = null;
            }
        }

        public void SetPiece(Location l)
        {
            this.pieceLocation = l;
            this.pieceColour = "none";
            this.pieceName = "Empty";
            this.Image = null;
        }

    }
}
