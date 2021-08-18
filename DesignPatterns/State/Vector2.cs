using System;

namespace DesignPatterns.State
{
    public struct Vector2 : IEquatable<Vector2>
    {
        public readonly bool Initialized;
        public readonly int X;
        public readonly int Y;

        public Vector2(int x, int y)
        {
            X = x;
            Y = y;
            Initialized = true;
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
    }
}