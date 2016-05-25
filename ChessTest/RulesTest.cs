using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chess;
using System.Diagnostics;

namespace ChessTest
{
    /// <summary>
    /// Summary description for RulesTest
    /// </summary>
    [TestClass]
    public class RulesTest
    {

        Board board;
        static Rules rules;
        static IBoardParser parser;

        public RulesTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            rules = new ChessRules();
            parser = new ChessBoardParser();
        }
        
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup(){}
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestWrongFoolsMate()
        {

            ICollection<Piece> pieces = RulesTest.parser.ParseBoard("C:\\Users\\Kory\\Documents\\Code\\ChessNoMerge\\ChessCSharp\\Chess\\boards\\foolmate.txt");

            board = new Board(new SetUpChessBoard(),pieces);
            rules.SetBoard(board);
            bool over = rules.GameOver(board, 1);

            Assert.IsFalse(over, "Not checkmate");


        }
    }
}
