using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chess;
using System.Collections.Generic;
using System.IO;

namespace ChessTest
{
    [TestClass]
    public class PieceTest
    {
        private Board b;

        [TestInitialize()]
        private void Initialize() {
            Console.ReadLine();
            Console.WriteLine("Test");
            b = new Board();
        }



        [TestMethod]
        public void KingValidMove()
        {
            Console.ReadLine();
            b = new Board();
            Location l = new Location(4,7);
            Piece k = new King("white", l);
            b.SetPiece(k);

            Location to = new Location(4, 6);

            MoveType mt = k.CanMove(b, null, to);

            Assert.AreEqual(mt,MoveType.NORMAL);

        }

        [TestMethod]
        public void KingInvalidMove()
        {
           
            Location l = new Location(4, 7);
            Piece k = new King("white", l);
            b = new Board();
            b.SetPiece(k);
            Location to = new Location(4, 1);

            MoveType mt = k.CanMove(b, null, to);

            Assert.AreEqual(mt, MoveType.INVALID);

        }

        [TestMethod]
        public void RookValidMove()
        {

            Location l = new Location(4, 7);

            Piece r = new Rook("white", l);
            b = new Board();
            b.SetPiece(r);
            Location to = new Location(4, 1);

            MoveType mt = r.CanMove(b, null, to);

            Assert.AreEqual(mt, MoveType.NORMAL);

        }

        [TestMethod]
        public void RookInValidMove()
        {

            Location l = new Location(4, 7);

            Piece r = new Rook("white", l);
            b = new Board();
            b.SetPiece(r);
            Location to = new Location(5, 1);

            MoveType mt = r.CanMove(b, null, to);

            Assert.AreEqual(mt, MoveType.INVALID);

        }

        [TestMethod]
        public void CheckMate()
        {
           
            IBoardParser bp = new ChessBoardParser();
            string boardName = "board2.txt";

            string dir = Directory.GetCurrentDirectory();
            string newdir = dir + "../../../../Chess/boards/";
            Directory.SetCurrentDirectory(newdir);
            ICollection<Piece> pieces = bp.ParseBoard("C:\\Users\\Kory\\Documents\\Code\\ChessNoMerge\\ChessCSharp\\Chess\\boards\\board2.txt");

            Assert.IsNotNull(pieces);
            dir = Directory.GetCurrentDirectory();

            System.Diagnostics.Trace.WriteLine(dir);

            Board b = new Board(new SetUpChessBoard(), pieces);
            Rules rules = new ChessRules();
            rules.SetBoard(b);
            bool c = rules.GameOver(b,0);

            Assert.IsFalse(c);

        }


    }
}
