using System;

namespace DesignPatterns.Core
{
    public struct Vector2 : IEquatable<Vector2>
    {
        public static readonly Vector2 Zero = new Vector2(0, 0);
        public static readonly Vector2 One = new Vector2(1, 1);
        public static readonly Vector2 Up = new Vector2(0, 1);
        public static readonly Vector2 Down = new Vector2(0, -1);
        public static readonly Vector2 Left = new Vector2(-1, 0);
        public static readonly Vector2 Right = new Vector2(1, 0);

        public readonly bool Initialized;
        public readonly int X;
        public readonly int Y;

        public Vector2(int x, int y)
        {
            X = x;
            Y = y;
            Initialized = true;
        }

        public Vector2 Clamp(Vector2 min, Vector2 max)
        {
            int newX = this.X;
            int newY = this.Y;
            newX = Math.Max(min.X, newX);
            newX = Math.Min(max.X, newX);
            newY = Math.Max(min.Y, newY);
            newY = Math.Min(max.Y, newY);
            return new Vector2(newX, newY);
        }

        public bool Equals(Vector2 other)
        {
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            return obj is Vector2 other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }

        public static bool operator ==(Vector2 left, Vector2 right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Vector2 left, Vector2 right)
        {
            return !left.Equals(right);
        }

        public static Vector2 operator +(Vector2 left, Vector2 right)
        {
            return new Vector2(left.X + right.X, left.Y + right.Y);
        }

        public static Vector2 operator*(Vector2 a, Vector2 b)
        {
            return new Vector2(a.X * b.X, a.Y * b.Y);
        }

        public static Vector2 operator*(Vector2 a, int b)
        {
            return new Vector2(a.X * b, a.Y * b);
        }

        public static Vector2 operator*(int a, Vector2 b)
        {
            return new Vector2(a * b.X, a * b.Y);
        }
    }
}