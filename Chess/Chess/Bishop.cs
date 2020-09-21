 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Chess.Directions;

namespace Chess
{
    class Bishop : Piece
    {
        public Bishop(int x, int y, string name, bool color, PictureBox picturebox)
        {
            X = x;
            Y = y;
            Name = name;
            white = color;
            pbox = picturebox;
        }
        

        
        public override Piece CalculateMoves()
        {
            availableMoves = new Coord[4][];
            availableMoves[0] = GetDiagonalMovementArray(maxDistance, DiagonalDirection.ForwardLeft,X,Y);
            availableMoves[1] = GetDiagonalMovementArray(maxDistance, DiagonalDirection.ForwardRight, X, Y);
            availableMoves[2] = GetDiagonalMovementArray(maxDistance, DiagonalDirection.BackwardLeft, X, Y);
            availableMoves[3] = GetDiagonalMovementArray(maxDistance, DiagonalDirection.BackwardRight, X, Y);
            ClearMoves(availableMoves);
            return this;
        }
    }
}
