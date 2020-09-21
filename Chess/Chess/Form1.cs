using Chess.Properties;
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
        public const int columns = 8;
        public const int rows = 8;

        Point MouseDownLocation;
        readonly double borderSize = 29.5;
        readonly int tileSize = 60;

        bool WhitePlaying = true;
        Piece PawnReadyToChange = null;
        //nevyuzivam 0ovych rad
        readonly Coord[,] coords = new Coord[columns + 1, rows + 1];
        public List<Piece> pieces = new List<Piece>();

        //kdyby zbyl cas na zhezceni nabindovani obrazku na pictureboxy
        /*private static Dictionary<(string Type, Color Color), Bitmap> availiableTypes =
            new Dictionary<(string Type, Color Color), Bitmap>
            {
                {("pawn",Color.White), Resources.WhitePawn }
            };*/

        private void SetCoords(Coord[,] coords)
        {
            for (int i = 0; i < rows + 1; i++)
            {
                for (int j = 0; j < columns + 1; j++)
                {
                    coords[i, j] = new Coord((int)borderSize + i * tileSize, (int)borderSize + (rows - j - 1) * tileSize);
                }
            }
        }
        private void InitializeBoard()
        {
            //inicializace pesaku
            for (int i = 1; i < 9; i++)
            {
                CreatePictureBox("pawn" + i.ToString(), true, i, 2);
                CreatePictureBox("pawn" + (i + 8).ToString(), false, i, 7);
            }

            //inicializace koni
            CreatePictureBox("knight1", true, 2, 1);
            CreatePictureBox("knight2", true, 7, 1);
            CreatePictureBox("knight3", false, 2, 8);
            CreatePictureBox("knight4", false, 7, 8);

            //inicializace strelcu
            CreatePictureBox("bishop1", true, 3, 1);
            CreatePictureBox("bishop2", true, 6, 1);
            CreatePictureBox("bishop3", false, 3, 8);
            CreatePictureBox("bishop4", false, 6, 8);

            //inicializace vezi
            CreatePictureBox("rook1", true, 1, 1);
            CreatePictureBox("rook2", true, 8, 1);
            CreatePictureBox("rook3", false, 1, 8);
            CreatePictureBox("rook4", false, 8, 8);

            //inicializace kraloven
            CreatePictureBox("queen1", true, 4, 1);
            CreatePictureBox("queen2", false, 4, 8);

            //inicializace kralu
            CreatePictureBox("king1", true, 5, 1);
            CreatePictureBox("king2", false, 5, 8);

            SetCoords(coords);
            SetPiecesPosition();
        }
        private void CreatePictureBox(string name, bool white, int positionX, int positionY)
        {
            PictureBox picture = new PictureBox
            {
                Width = 55,
                Height = 55
            };

            Bitmap image = GetPieceBackground(name, white);
            picture.SizeMode = PictureBoxSizeMode.StretchImage;
            picture.Image = (Image)image;
            picture.Name = name;
            Controls.Add(picture);
            picture.MouseMove += Picture_MouseMove;
            picture.MouseDown += Picture_MouseDown;
            picture.MouseUp += Picture_MouseUp;
            picture.BringToFront();

            if ((name.StartsWith("bishop"))) { pieces.Add(new Bishop(positionX, positionY, name, white, picture)); }
            if ((name.StartsWith("knight"))) { pieces.Add(new Knight(positionX, positionY, name, white, picture)); }
            if ((name.StartsWith("pawn"))) { pieces.Add(new Pawn(positionX, positionY, name, white, picture)); }
            if ((name.StartsWith("king"))) { pieces.Add(new King(positionX, positionY, name, white, picture)); }
            if ((name.StartsWith("rook"))) { pieces.Add(new Rook(positionX, positionY, name, white, picture)); }
            if ((name.StartsWith("queen"))) { pieces.Add(new Queen(positionX, positionY, name, white, picture)); }
        }
        private Bitmap GetPieceBackground(string name, bool white)
        {
            if (white)
            {
                if (name.StartsWith("pawn")) { return Resources.WhitePawn; }
                else if (name.StartsWith("knight")) { return Resources.WhiteKnight; }
                else if (name.StartsWith("bishop")) { return Resources.WhiteBishop; }
                else if (name.StartsWith("rook")) { return Resources.WhiteRook; }
                else if (name.StartsWith("king")) { return Resources.WhiteKing; }
                else { return Resources.WhiteQueen; }
            }
            else
            {
                if (name.StartsWith("pawn")) { return Resources.BlackPawn; }
                else if (name.StartsWith("knight")) { return Resources.BlackKnight; }
                else if (name.StartsWith("bishop")) { return Resources.BlackBishop; }
                else if (name.StartsWith("rook")) { return Resources.BlackRook; }
                else if (name.StartsWith("king")) { return Resources.BlackKing; }
                else { return Resources.BlackQueen; }
            }
        }
        private void SetPiecesPosition()
        {
            foreach (Piece piece in pieces)
            {
                if (piece.X != 0)
                {
                    piece.pbox.Left = coords[piece.X - 1, piece.Y - 1].X;
                    piece.pbox.Top = coords[piece.X - 1, piece.Y - 1].Y;
                }
            }
        }
        private void Picture_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                ((PictureBox)sender).Left = e.X + ((PictureBox)sender).Left - MouseDownLocation.X;
                ((PictureBox)sender).Top = e.Y + ((PictureBox)sender).Top - MouseDownLocation.Y;
            }
        }
        private void Picture_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                MouseDownLocation = e.Location;
            }
            foreach (Piece piece in pieces)
            {
                if (((PictureBox)sender).Name == piece.Name)
                {
                    piece.CalculateMoves();
                }
            }
        }
        private void Picture_MouseUp(object sender, MouseEventArgs e)
        {
            foreach (Piece piece in pieces)
            {
                if (((PictureBox)sender).Name == piece.Name)
                {
                    int x = 0;
                    int y = 0;
                    while ((e.X + ((PictureBox)sender).Left - MouseDownLocation.X + (int)borderSize) > coords[x, y].X)
                    {
                        x++;
                        if (x == rows) { break; }
                    }
                    while ((e.Y + ((PictureBox)sender).Top - MouseDownLocation.Y - (int)borderSize) < coords[x, y].Y)
                    {

                        y++;
                        if (y == columns) { break; }
                    }
                    if (CheckBoardifValid(piece, x, y))
                    {
                        piece.X = x;
                        piece.Y = y;
                        WhitePlaying = !WhitePlaying;
                        if (piece.Name.StartsWith("pawn"))
                        {
                            piece.doubleJump = false;
                            if ((piece.white && y==8) || (!piece.white && y == 1))
                            {
                                PawnReadyToChange = piece;
                            }
                            
                        }
                    }
                }
            }

            if (PawnReadyToChange != null)
            {
                //prioritne menim na kralovnu
                PawnToBeSwitched(PawnReadyToChange, "queen");
            }
                
            SetPiecesPosition();
        }
        private void PawnToBeSwitched(Piece piece, string desiredPiece)
        {
            CreatePictureBox(desiredPiece + "FromPawn" + piece.Name.Substring(piece.Name.LastIndexOf('n')), piece.white, piece.X, piece.Y);
            pieces.Remove(piece);
            Piece.killPiece(piece);
            PawnReadyToChange = null;
        }
        private bool CheckBoardifValid(Piece piece, int toX, int toY)
        {
            bool moveIsPossible = false;
            //jestli hraje spravny hrac
            if (!WhitePlaying && piece.white) { return false; }
            if (WhitePlaying && !piece.white) { return false; }

            //jestli nethahnul mimo plochu
            if (toX > rows || toX < 1) { return false; }
            if (toY > columns || toY < 1) { return false; }

            CheckIfMovesAreBlocked(piece);

            foreach (Coord[] availiableMove in piece.AvailableMoves)
            {
                foreach(Coord Move in availiableMove)
                {
                    if((Move.X!= piece.X || Move.Y != piece.Y) && Move.X==toX && Move.Y== toY)
                    {
                        moveIsPossible = true;
                        
                        //sem se dostane pouze pokud je zde volno nebo nepratelska jednotka tedy nemusim testovat barvu
                        foreach(Piece testedPiece in pieces)
                        {
                            if(testedPiece.X==toX && testedPiece.Y == toY) { Piece.killPiece(testedPiece); }
                        }
                    }
                }
            }
            //pokud se jedna o pesaka take se musi otestovat utoky
            if (piece.Name.StartsWith("pawn"))
            {
                foreach (Piece testedPiece in pieces)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        if (piece.white!=testedPiece.white && testedPiece.X == piece.AvailableAttacks[i][0].X && testedPiece.Y == piece.AvailableAttacks[i][0].Y)
                        {
                            if(toX== testedPiece.X && toY== testedPiece.Y)
                            {
                                moveIsPossible = true;
                                Piece.killPiece(testedPiece);
                            }
                            
                        }
                    }
                }
            }

            return moveIsPossible;
        }
        private void CheckIfMovesAreBlocked(Piece piece)
        {
            for (int i = 0; i < piece.AvailableMoves.Length; i++)
            {
                for (int j = 0; j < piece.AvailableMoves[i].Length; j++)
                {
                    if (piece.AvailableMoves[i][j].X != 0 && piece.AvailableMoves[i][j].Y != 0) 
                    {
                        foreach (Piece testedPiece in pieces)
                        {
                            if (testedPiece.X == piece.AvailableMoves[i][j].X && testedPiece.Y == piece.AvailableMoves[i][j].Y)
                            {
                                ClearBlockedPieces(piece, testedPiece);
                            }
                        }
                    }
                }
            }
        }
        private void ClearBlockedPieces(Piece piece, Piece testedPiece)
        {
            int x = testedPiece.X;
            int y = testedPiece.Y;

            if (piece.Name.StartsWith("knight")) { return; }
            //pokud je prvni figurka na kterou narazi jine barvy a neni to zrovna testovan pesak, tak na to je mozny tah, tedy tento necha
            if (piece.white != testedPiece.white && !piece.Name.StartsWith("pawn"))
            {
                if (x > piece.X) { x++; } else if (x < piece.X) { x--; }
                if (y > piece.Y) { y++; } else if (y < piece.Y) { y--; }
            }

            while (true)
            {
                //najde v moznych tazich ten, ktery ma vyresetovat
                foreach (Coord[] availableMove in piece.AvailableMoves)
                {
                    foreach (Coord Move in availableMove)
                    {
                        if (Move.X == x && Move.Y == y)
                        {
                            Move.X = 0;
                            Move.Y = 0;
                            //uz nema cenu hledat dalsi tedy vyskoci ven z loopu
                            goto EndOfLoop;
                        }
                    }
                }
                EndOfLoop:

                if (x > 8 || x < 1 || y > 8 || y < 1)
                {
                    break;
                }

                if (x > piece.X) { x++; } else if (x < piece.X) { x--; }
                if (y > piece.Y) { y++; } else if (y < piece.Y) { y--; }
            }
        }
    }
}