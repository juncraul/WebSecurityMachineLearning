﻿namespace Mathematics;

public class Vector2(double x, double y)
{
    public double X { get; set; } = x;
    public double Y { get; set; } = y;

    public static Vector2 operator -(Vector2 a, Vector2 b)
    {
        return new Vector2(a.X - b.X, a.Y - b.Y);
    }

    public static Vector2 operator +(Vector2 a, Vector2 b)
    {
        return new Vector2(a.X + b.X, a.Y + b.Y);
    }

    public static Vector2 operator *(double a, Vector2 b)
    {
        return new Vector2(a * b.X, a * b.Y);
    }

    public static Vector2 operator *(Vector2 a, double b)
    {
        return b * a;
    }

    public static double Dot(Vector2 a, Vector2 b)
    {
        return a.X * b.X + a.Y * b.Y;
    }

    public double Magnitude()
    {
        return Math.Sqrt(X * X + Y * Y);
    }

    public Vector2 Normalize()
    {
        return this * (1 / Magnitude());
    }

    public Vector2 Rotate(double radian)
    {
        var cosA = Math.Cos(radian);
        var sinA = Math.Sin(radian);
        return new Vector2(X * cosA - Y * sinA, X * sinA + Y * cosA);
    }

    public int GetHashCode(Vector2 obj)
    {
        var hashX = obj.X.GetHashCode();

        var hashY = obj.Y.GetHashCode();

        return hashX ^ hashY;
    }
}