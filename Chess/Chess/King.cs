using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    class King : Piece
    {
        public King(int x, int y, string name, bool color, PictureBox picturebox)
        {
            X = x;
            Y = y;
            Name = name;
            white = color;
            pbox = picturebox;
        }

        public override Piece CalculateMoves()
        {
            availableMoves = new Coord[8][];
            availableMoves[0] = GetMovementArray(1, Directions.Direction.Forward, X, Y);
            availableMoves[1] = GetMovementArray(1, Directions.Direction.Right, X, Y);
            availableMoves[2] = GetMovementArray(1, Directions.Direction.Left, X, Y);
            availableMoves[3] = GetMovementArray(1, Directions.Direction.Backward, X, Y);

            availableMoves[4] = GetDiagonalMovementArray(1, Directions.DiagonalDirection.ForwardLeft, X, Y);
            availableMoves[5] = GetDiagonalMovementArray(1, Directions.DiagonalDirection.ForwardRight, X, Y);
            availableMoves[6] = GetDiagonalMovementArray(1, Directions.DiagonalDirection.BackwardLeft, X, Y);
            availableMoves[7] = GetDiagonalMovementArray(1, Directions.DiagonalDirection.BackwardRight, X, Y);

            ClearMoves(availableMoves);
            return this;
        }
        public void IsChecked()
        {

        }
    }
}
