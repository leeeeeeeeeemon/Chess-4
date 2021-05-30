// Baryshev Emil 220
// Chess 3
// 13.03.2021
using System;

class Program
{
    static void Main()
    {
        King test = new King(3, 8);
        Console.WriteLine(test.Move(3, 7) ? "YES" : "NO");
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