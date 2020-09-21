using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Chess.Directions;

namespace Chess
{
    public abstract class Piece
    {
        public int X;
        public int Y;
        public string Name;
        public bool white;
        public PictureBox pbox; 
        protected const int maxDistance = 7;
        protected Coord[][] availableMoves; 
        protected Coord[][] availableAttacks;

        /*public bool IsWhite(Color color)
        {
            get => (color == Color.White);
        }*/

        //pro pesce
        public bool doubleJump;
        public Coord[][] AvailableMoves
        {
            get { return availableMoves; }
        }

        public Coord[][] AvailableAttacks
        {
            get { return availableAttacks; }
        }

        public abstract Piece CalculateMoves();
        public static void killPiece(Piece piece)
        {
            piece.pbox.Left = -100;
            piece.pbox.Top = -100;
            piece.X = 0;
            piece.Y = 0;
        }

        public static Coord[] GetMovementArray(int distance, Direction direction,int xPosition,int yPosition)
        {
            Coord[] movement = new Coord[distance];


            for (int i = 0; i < distance; i++)
            {
                switch (direction)
                {
                    case Direction.Forward:
                        yPosition++;
                        break;
                    case Direction.Backward:
                        yPosition--;
                        break;
                    case Direction.Left:
                        xPosition++;
                        break;
                    case Direction.Right:
                        xPosition--;
                        break;
                    default:
                        break;
                }
                movement[i] = new Coord(xPosition, yPosition);
            }
            return movement;
        }

        public static Coord[] GetDiagonalMovementArray(int distance, DiagonalDirection direction, int xPosition, int yPosition)
        {
            Coord[] movement = new Coord[distance];

            for (int i = 0; i < distance; i++)
            {
                switch (direction)
                {
                    case DiagonalDirection.ForwardLeft:
                        xPosition--;
                        yPosition++;
                        break;
                    case DiagonalDirection.ForwardRight:
                        xPosition++;
                        yPosition++;
                        break;
                    case DiagonalDirection.BackwardLeft:
                        xPosition--;
                        yPosition--;
                        break;
                    case DiagonalDirection.BackwardRight:
                        xPosition++;
                        yPosition--;
                        break;
                    default:
                        break;
                }
                movement[i] = new Coord(xPosition, yPosition);
            }
            return movement;
        }
        public static Coord[] GetKnightMovementArray(int xPosition, int yPosition)
        {
            Coord[] movement = new Coord[8];
           
            movement[0] = new Coord(xPosition+1, yPosition+2);
            movement[1] = new Coord(xPosition+1, yPosition-2);
            movement[2] = new Coord(xPosition-1, yPosition+2);
            movement[3] = new Coord(xPosition-1, yPosition-2);
            movement[4] = new Coord(xPosition+2, yPosition+1);
            movement[5] = new Coord(xPosition+2, yPosition-1);
            movement[6] = new Coord(xPosition-2, yPosition+1);
            movement[7] = new Coord(xPosition-2, yPosition-1);

            return movement;
        }

        public static void ClearMoves(Coord[][] availableMoves)
        {
            foreach(Coord[] availableMove in availableMoves)
            {
                foreach(Coord Move in availableMove)
                {
                    if(Move.X<1 || Move.X>8 || Move.Y<1 || Move.Y > 8)
                    {
                        Move.X = 0;
                        Move.Y = 0;
                    }
                }
            }
        }
    }
}