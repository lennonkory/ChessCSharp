using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    /// <summary>
    /// Used for adding functionality to a piece.
    /// </summary>
    public abstract class PieceDecorator : Piece
    {

        private Piece piece;

        /// <summary>
        /// Constructor to create decorator.
        /// </summary>
        /// <param name="p">The piece to decorate.</param>
        public PieceDecorator(Piece p) : base(p){
            this.piece = p;
        }

        /// <summary>
        /// <see cref="Piece.CanMove(Board, Rules, Location)"/>
        /// </summary>
        /// <param name="board"></param>
        /// <param name="rules"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public override MoveType CanMove(Board board, Rules rules, Location to)
        {
           return this.piece.CanMove(board,rules,to);
        }

        /// <summary>
        /// <see cref="Piece.GetMoves(Board, Rules)"/>
        /// </summary>
        /// <param name="board"></param>
        /// <param name="rules"></param>
        /// <returns></returns>
        public override ICollection<Location> GetMoves(Board board, Rules rules)
        {
            return this.piece.GetMoves(board, rules);
        }
    }
}
