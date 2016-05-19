using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chess;

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

    }
}
