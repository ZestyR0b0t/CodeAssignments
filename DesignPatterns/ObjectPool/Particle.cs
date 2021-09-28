using System;
using DesignPatterns.Core;

namespace DesignPatterns.ObjectPool
{
    public class Particle : IEntity
    {
        private const int MsBetweenMovement = 50;
        private static readonly Vector2 Direction = new Vector2(0, -1);
        private static readonly Vector2 StartPos = new Vector2(Screen.Width / 2, Screen.Height / 2);

        private int _msSinceLastMove = 0;
        private byte[] _data;

        public bool IsDead { get; private set; }
        public Vector2 Position { get; private set; } = StartPos;
        public DrawData Display { get; } = new DrawData(ConsoleColor.Yellow, '@');

        public Particle()
        {
            // Allocate beefy array to prove a point
            _data = new byte[65_536];
        }

        public void Update(int deltaTimeMs)
        {
            if (IsDead)
            {
                return;
            }

            _msSinceLastMove += deltaTimeMs;
            if (_msSinceLastMove < MsBetweenMovement)
            {
                return;
            }

            _msSinceLastMove = 0;

            Display.PreviousPosition = Position;
            Position += Direction;
            if (Position.X >= Screen.Width || Position.X < 0 || Position.Y >= Screen.Height || Position.Y < 0)
            {
                IsDead = true;
                ParticleMgr.Instance.MarkForRemoval(this);
                return;
            }
        }

        public void Reset()
        {
            IsDead = false;
            _msSinceLastMove = 0;
            Display.PreviousPosition = default(Vector2);
            Position = StartPos;
        }
    }
}