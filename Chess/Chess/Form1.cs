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
            InitializeBoard();
        }
        string SysPath = "C:\\Users\\dousa\\source\\repos\\Chess\\";
        Point MouseDownLocation;
        int borderSize = 28;
        int tileSize = 60;
        bool WhitePlaying = true;
        List<Piece> pieces = new List<Piece>();
        private void InitializeBoard()
        {
            //inicializace pesaku
            for (int i = 1; i < 9; i++)
            {
                createPiece("pawn" + i.ToString(), true, i, 2);
                createPiece("pawn" + (i+8).ToString(), false, i, 7);
            }

            //inicializace koni
            createPiece("knight1", true, 2, 1);
            createPiece("knight2", true, 7, 1);
            createPiece("knight3", false, 2, 8); 
            createPiece("knight4", false, 7, 8);

            //inicializace strelcu
            createPiece("bishop1", true, 3, 1);
            createPiece("bishop2", true, 6, 1);
            createPiece("bishop3", false, 3, 8);
            createPiece("bishop4", false, 6, 8);

            //inicializace vezi
            createPiece("rook1", true, 1, 1);
            createPiece("rook2", true, 8, 1);
            createPiece("rook3", false, 1, 8);
            createPiece("rook4", false, 8, 8);

            //inicializace kraloven
            createPiece("queen1", true, 4, 1);
            createPiece("queen2", false, 4, 8);

            //inicializace kralu
            createPiece("king1", true, 5, 1);
            createPiece("king2", false, 5, 8);
        }

        private void createPiece(string name, bool white, int positionX, int positionY)
        {
            PictureBox picture = new PictureBox();
            picture.Width = 55;
            picture.Height = 55;
            Bitmap image = new Bitmap(getPieceStringPath(name, white));
            picture.SizeMode = PictureBoxSizeMode.StretchImage;
            picture.Image = (Image)image;
            picture.Name = name;

            //prozatimni pozice jenom na kontrolu, dodelam s renderem podle positionX a positionY
            picture.Location = new Point(positionX*50, positionY*50);

            Controls.Add(picture);
            picture.MouseMove += Picture_MouseMove;
            picture.MouseDown += Picture_MouseDown;
            picture.BringToFront();

            var currentPiece = new Piece(positionX, positionY, name, white, picture);
            pieces.Add(currentPiece);
        }

        private string getPieceStringPath(string name, bool white)
        {
            string StringPath = "";
            if (white)
            {
                if (name.StartsWith("pawn")) { StringPath = SysPath + "PiecesPhotos\\" + "White" + "Pawn.png"; }
                else if (name.StartsWith("knight")) { StringPath = SysPath + "PiecesPhotos\\" + "White" + "Knight.png"; }
                else if (name.StartsWith("bishop")) { StringPath = SysPath + "PiecesPhotos\\" + "White" + "Bishop.png"; }
                else if (name.StartsWith("rook")) { StringPath = SysPath + "PiecesPhotos\\" + "White" + "Rook.png"; }
                else if (name.StartsWith("king")) { StringPath = SysPath + "PiecesPhotos\\" + "White" + "King.png"; }
                else if (name.StartsWith("queen")) { StringPath = SysPath + "PiecesPhotos\\" + "White" + "Queen.png"; }
            }
            else
            {
                if (name.StartsWith("pawn")) { StringPath = SysPath + "PiecesPhotos\\" + "Black" + "Pawn.png"; }
                else if (name.StartsWith("knight")) { StringPath = SysPath + "PiecesPhotos\\" + "Black" + "Knight.png"; }
                else if (name.StartsWith("bishop")) { StringPath = SysPath + "PiecesPhotos\\" + "Black" + "Bishop.png"; }
                else if (name.StartsWith("rook")) { StringPath = SysPath + "PiecesPhotos\\" + "Black" + "Rook.png"; }
                else if (name.StartsWith("king")) { StringPath = SysPath + "PiecesPhotos\\" + "Black" + "King.png"; }
                else if (name.StartsWith("queen")) { StringPath = SysPath + "PiecesPhotos\\" + "Black" + "Queen.png"; }
            }

            return StringPath;
        }

        private void Picture_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                foreach(Piece piece in pieces)
                {
                    if(((PictureBox)sender).Name==piece.Type)
                    {
                        piece.pbox.Left = centerPiece(e.X + piece.pbox.Left - MouseDownLocation.X);
                        piece.pbox.Top = centerPiece(e.Y + piece.pbox.Top - MouseDownLocation.Y);
                    }
                }
            }
        }

        private void Picture_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                MouseDownLocation = e.Location;
            }
        }
        private int centerPiece(int width)
        {
            int square = (width - borderSize) / tileSize;
            return (square * tileSize+borderSize);
        }
    }

}