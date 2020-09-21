using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    class Knight : Piece
    {
        public Knight(int x, int y, string name, bool color, PictureBox picturebox)
        {
            X = x;
            Y = y;
            Name = name;
            white = color;
            pbox = picturebox;
        }

        public override Piece CalculateMoves()
        {
            availableMoves = new Coord[1][];
            availableMoves[0] = GetKnightMovementArray(X,Y);
            return this;
        }
    }
}
