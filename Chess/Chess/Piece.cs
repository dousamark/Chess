using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    class Piece
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool alive { get; set; }
        public string Type { get; set; }
        public bool white { get; set; }
        public PictureBox pbox { get; set; }

        public Piece(int x, int y, string type, bool color, PictureBox picturebox)
        {
            //pozice 1-8 a pak fce render vykresli na pixely 
            X = x;
            Y = y;
            Type = type;
            alive = true;
            white = color;
            pbox = picturebox;
        }
    }
}