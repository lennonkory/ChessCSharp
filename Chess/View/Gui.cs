using Chess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Chess.View
{
    public partial class Gui : Form
    {
        private int moveX = 0;
        private int moveY = 0;

        private PieceBox old;
        private bool move = false;

        private PieceBox[,] squares;

        IInputParser input;

        protected ICommandListener cl;

        private ICollection<Location> selectedLocations;

        public Gui()
        {
            InitializeComponent();
            Size s = this.boardBox.Size;
            moveX = (int)Math.Round(((float)s.Width * 0.85) / 8.0);
            moveY = (int)Math.Round(((float)s.Height * 0.83) / 8.0);
            squares = new PieceBox[8, 8];
            input = new ChessParser();
        }

        public void Message(string message)
        {
            this.label1.Text = message;
        }

        public void SetBoard(Square[,] s)
        {

            int startY = 66;
            int startX = 101;
            int i = 0;

            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {

                    Piece piece = s[y, x].GetPiece();

                    squares[piece.Location.Ycord, piece.Location.Xcord] = new PieceBox(piece, startX, startY, this.moveX, this.moveY, i);
                    squares[piece.Location.Ycord, piece.Location.Xcord].Click += new System.EventHandler(this.select_piece);
                    this.Controls.Add(squares[piece.Location.Ycord, piece.Location.Xcord]);

                    i++;
                }
            }

            this.boardBox.SendToBack();
        }

        private void boardBox_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("CATT");
        }

        public void ShowMoves(ICollection<Chess.Location> moves)
        {
            if (moves == null)
            {
                return;
            }

            selectedLocations = moves;

            foreach (Location l in moves)
            {
                squares[l.Ycord, l.Xcord].BackColor = Color.Red;
            }
        }

        private void clearSelectedMoves()
        {
            if (selectedLocations == null)
            {
                return;
            }

            foreach (Location l in selectedLocations)
            {
                squares[l.Ycord, l.Xcord].SetBackGroundColor();
            }

            selectedLocations = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.label1.Text = "X: " + MousePosition.X + " Y: " + MousePosition.Y;

            IBoardParser parser = new ChessBoardParser();

            ICollection<Piece> p = parser.ParseBoard("C:\\Users\\Kory\\Documents\\Code\\ChessNoMerge\\ChessCSharp\\Chess\\boards\\board1.txt");

            Square[,] s = new Square[8, 8];

            foreach (Piece pp in p)
            {
                Location loc = pp.Location;
                s[loc.Ycord, loc.Xcord] = new Square("white", pp);
            }

            SetBoard(s);
        }

        private void test(object sender, EventArgs e)
        {
            PieceBox p = (PieceBox)sender;

            this.label1.Text = "X: " + MousePosition.X + " Y: " + MousePosition.Y;
            this.label1.Text += "\n" + p.Location;
            this.label1.Text += "\n" + p.GetPieceName();
            Chess.Location l = p.GetPieceLocation();
            this.label1.Text += "\n" + l;
            this.label1.Text += "\n" + squares[l.Ycord, l.Xcord].GetPieceName();

            if (!move)
            {
                if (p.Selected)
                {
                    p.SetBackGroundColor();
                    p.Selected = false;
                    move = false;
                }
                else
                {
                    //Don't high light empty squares
                    p.BackColor = Color.Aqua;
                    p.Selected = true;
                    old = p;
                    move = true;
                }
            }
            else
            {
                if (p.Selected)
                {
                    p.SetBackGroundColor();
                    p.Selected = false;
                }
                else
                {
                    p.Selected = false;
                    old.Selected = false;
                    Point temp = p.Location;
                    p.Location = old.Location;

                    old.Location = temp;

                    Chess.Location t = p.GetPieceLocation();

                    PieceBox tempBox = squares[t.Ycord, t.Xcord];
                    Location oldLocation = old.GetPieceLocation();

                    squares[t.Ycord, t.Xcord] = squares[oldLocation.Ycord, oldLocation.Xcord];
                    squares[oldLocation.Ycord, oldLocation.Xcord] = tempBox;

                    p.SetPieceLocation(old.GetPieceLocation());
                    old.SetPieceLocation(t);

                    p.SetBackGroundColor();
                    old.SetBackGroundColor();
                }

                move = false;
            }

        }

        private void select_piece(object sender, EventArgs e)
        {
            
            PieceBox p = (PieceBox)sender;

            this.label1.Text = "X: " + MousePosition.X + " Y: " + MousePosition.Y;
            this.label1.Text += "\n" + p.Location;
            this.label1.Text += "\n" + p.GetPieceName();
            Chess.Location l = p.GetPieceLocation();
            this.label1.Text += "\n" + l;
            this.label1.Text += "\n" + squares[l.Ycord, l.Xcord].GetPieceName();

            if (!move)
            {
                if (p.Selected)
                {
                    p.SetBackGroundColor();
                    p.Selected = false;
                    move = false;
                    clearSelectedMoves();
                }
                else
                {
                    //Don't high light empty squares
                    p.BackColor = Color.Aqua;
                    p.Selected = true;
                    old = p;
                    move = true;

                    Debug.WriteLine("Loc:" + p.GetPieceLocation());
                    this.cl.SendMessage(p.GetPieceLocation());
                }
            }
            else
            {
                if (p.Selected)
                {
                    p.SetBackGroundColor();
                    p.Selected = false;
                }
                else
                {
                    p.Selected = false;
                    old.Selected = false;

                    Move m = new Chess.Move(old.GetPieceLocation(), p.GetPieceLocation());
                    this.cl.SendMessage(m);
                }
                clearSelectedMoves();
                move = false;
            }
        }

        public void MovePiece(Move m, Piece p)
        {
            Location from = m.From;
            Location to = m.To;

            PieceBox toPiece = squares[to.Ycord, to.Xcord];
            PieceBox fromPiece = squares[from.Ycord, from.Xcord];

            toPiece.Selected = false;
            fromPiece.Selected = false;

            Point temp = toPiece.Location;
            toPiece.Location = fromPiece.Location;

            fromPiece.Location = temp;

            Chess.Location t = toPiece.GetPieceLocation();

            PieceBox tempBox = squares[t.Ycord, t.Xcord];
            Location oldLocation = fromPiece.GetPieceLocation();

            squares[t.Ycord, t.Xcord] = squares[oldLocation.Ycord, oldLocation.Xcord];
            squares[oldLocation.Ycord, oldLocation.Xcord] = tempBox;

            toPiece.SetPieceLocation(fromPiece.GetPieceLocation());
            fromPiece.SetPieceLocation(t);

            toPiece.SetBackGroundColor();
            fromPiece.SetBackGroundColor();

            squares[from.Ycord, from.Xcord].SetPiece(from);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string inputText = this.inputBox.Text;
            this.cl.SendMessage(inputText);

            /*
            if (input.ParseInput(inputText) == InputType.MOVE)
            {
                Move m = input.CreateMove(inputText);
                MovePiece(m);
            }
            else {
                label1.Text = "INVALID MOVE";
            }
            */
        }

        public void SetCommandListener(ICommandListener cl)
        {
            this.cl = cl;
        }

    }
}
