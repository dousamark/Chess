using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Directions
    {
        public enum Direction
        {
            Forward,
            Backward,
            Left,
            Right
        }

        public enum DiagonalDirection
        {
            ForwardLeft,
            ForwardRight,
            BackwardLeft,
            BackwardRight
        }
    }
}
