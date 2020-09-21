using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    class Rook : Piece
    {
        public Rook(int x, int y, string name, bool color, PictureBox picturebox)
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
            availableMoves[0] = GetMovementArray(maxDistance, Directions.Direction.Forward,X,Y);
            availableMoves[1] = GetMovementArray(maxDistance, Directions.Direction.Right,X,Y);
            availableMoves[2] = GetMovementArray(maxDistance, Directions.Direction.Left,X,Y);
            availableMoves[3] = GetMovementArray(maxDistance, Directions.Direction.Backward,X,Y);
            ClearMoves(availableMoves);
            return this;
        }
    }
}
