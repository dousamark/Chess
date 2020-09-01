using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
        }
        private Point MouseDownLocation;
        private int borderSize = 50;
        private int tileSize = 91;
        

        private void pawn_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {

                pawn.Left = centerPiece(e.X + pawn.Left - MouseDownLocation.X);
                pawn.Top = centerPiece(e.Y + pawn.Top - MouseDownLocation.Y);
                //MessageBox.Show("");

            }
        }

        private void pawn_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
               MouseDownLocation = e.Location;
                //MessageBox.Show((e.X).ToString());
            }
        }
        private int centerPiece(int width)
        {
            int squareX = (width-borderSize)/tileSize;
            return squareX * tileSize + borderSize;
        }
    }

}
