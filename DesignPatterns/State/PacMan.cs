using System;

namespace DesignPatterns.State
{
    public class PacMan : IEntity
    {
        private const char DefaultChar = 'O';
        private const char EnergizedChar = 'Ø';
        private const int EnergizedDurationMs = 5000;

        private readonly World _world;
        private int _energizedTimeRemainingMs;

        public DrawData Display { get; private set; }

        public Vector2 Position { get; private set; }

        public bool IsEnergized { get; private set; }

        public PacMan(World world)
        {
            _world = world;
            Position = new Vector2(0, 0);
            Display = new DrawData(ConsoleColor.Yellow, DefaultChar);
        }

        public void Update(int deltaTimeMs)
        {
            if (IsEnergized)
            {
                _energizedTimeRemainingMs += deltaTimeMs;
                if (_energizedTimeRemainingMs > EnergizedDurationMs)
                {
                    _energizedTimeRemainingMs = 0;
                    IsEnergized = false;
                    Display.Character = DefaultChar;
                }
            }
            else
            {
                IEntity entity = _world.GetEntityAtPos(Position);
                if (entity != null && entity is PowerPellet)
                {
                    IsEnergized = true;
                    Display.Character = EnergizedChar;
                    _world.RemoveFromWorld(entity);
                }
            }
        }

        public void Move(Direction direction)
        {
            Display.PreviousPosition = Position;

            int newX = Position.X;
            int newY = Position.Y;
            switch (direction)
            {
                case Direction.North:
                    newY -= 1;
                    break;
                case Direction.South:
                    newY += 1;
                    break;
                case Direction.East:
                    newX += 1;
                    break;
                case Direction.West:
                    newX -= 1;
                    break;
                default:
                    return;
            }

            newX = Math.Clamp(newX, 0, World.Width);
            newY = Math.Clamp(newY, 0, World.Height);
            Position = new Vector2(newX, newY);
        }
    }
}