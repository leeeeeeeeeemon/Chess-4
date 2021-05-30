using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess4WPF
{
    class rule
    {
        public static bool tryKingMove(int x1, int y1, int x2, int y2)
        {
            King test = new King(x1, y1);
            return test.Move(x2,y2);
        }
    }

    class Figure
    {
        protected int X;
        protected int Y;

        public Figure(int newX, int newY)
        {
            X = newX;
            Y = newY;
        }

        public virtual bool Move(int newX, int newY)
        {
            return false;
        }
    }

    class Rook : Figure
    {
        public Rook(int newX, int newY) : base(newX, newY)
        {
        }

        public override bool Move(int newX, int newY)
        {
            if (X == newX || Y == newY)
            {
                X = newX;
                Y = newY;
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    class Queen : Figure
    {
        public Queen(int newX, int newY) : base(newX, newY)
        {
        }

        public override bool Move(int newX, int newY)
        {
            if (X == newX || Y == newY ||
                        Math.Abs(X - newX) == Math.Abs(Y - newY))
            {
                X = newX;
                Y = newY;
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    class Bishop : Figure
    {
        public Bishop(int newX, int newY) : base(newX, newY)
        {
        }

        public override bool Move(int newX, int newY)
        {
            if (Math.Abs(X - newX) == Math.Abs(Y - newY))
            {
                X = newX;
                Y = newY;
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    class Knight : Figure
    {
        public Knight(int newX, int newY) : base(newX, newY)
        {
        }

        public override bool Move(int newX, int newY)
        {
            if ((Math.Abs(X - newX) == 2 && Math.Abs(Y - newY) == 1) ||
                    (Math.Abs(X - newX) == 1 && Math.Abs(Y - newY) == 2))
            {
                X = newX;
                Y = newY;
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    class King : Figure
    {
        public King(int newX, int newY) : base(newX, newY)
        {
        }

        public override bool Move(int newX, int newY)
        {
            if (Math.Abs(X - newX) <= 1 && Math.Abs(Y - newY) <= 1)
            {
                X = newX;
                Y = newY;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}


