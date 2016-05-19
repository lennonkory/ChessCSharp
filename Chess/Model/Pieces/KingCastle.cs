using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class KingCastle : PieceDecorator
    {
        public KingCastle(Piece p) : base(p) { }


        public override MoveType CanMove(Board board, Rules rules, Location to)
        {

            return base.CanMove(board, rules, to);
        }

        public override ICollection<Location> GetMoves(Board board, Rules rules)
        {
            return base.GetMoves(board, rules);
        }
    }
}
