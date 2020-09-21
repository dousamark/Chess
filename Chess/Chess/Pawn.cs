using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    class Pawn : Piece
    {
        public Pawn(int x, int y, string name, bool color, PictureBox picturebox)
        {
            X = x;
            Y = y;
            Name = name;
            white = color;
            pbox = picturebox;
            doubleJump = true;
        }

        public override Piece CalculateMoves()
        {
            availableMoves = new Coord[1][];
            availableAttacks = new Coord[2][];
            if (white)
            {
                availableAttacks[0] = GetDiagonalMovementArray(1, Directions.DiagonalDirection.ForwardLeft, X, Y);
                availableAttacks[1] = GetDiagonalMovementArray(1, Directions.DiagonalDirection.ForwardRight, X, Y);
                if (doubleJump)
                {
                    availableMoves[0] = GetMovementArray(2, Directions.Direction.Forward, X, Y);
                }
                else { availableMoves[0] = GetMovementArray(1, Directions.Direction.Forward, X, Y); }
            }
            else
            {
                availableAttacks[0] = GetDiagonalMovementArray(1, Directions.DiagonalDirection.BackwardLeft, X, Y);
                availableAttacks[1] = GetDiagonalMovementArray(1, Directions.DiagonalDirection.BackwardRight, X, Y);
                if (doubleJump)
                {
                    availableMoves[0] = GetMovementArray(2, Directions.Direction.Backward, X, Y);
                }
                else { availableMoves[0] = GetMovementArray(1, Directions.Direction.Backward, X, Y); }
            }
            
            ClearMoves(availableMoves);
            return this;
        }
    }
}
