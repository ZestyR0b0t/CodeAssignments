using System;

namespace DesignPatterns.State
{
    public class PowerPellet : IEntity
    {
        private const char DefaultChar = '*';

        public DrawData Display { get; private set; }
        public Vector2 Position { get; private set; }

        public PowerPellet(int x, int y)
        {
            Position = new Vector2(x, y);
            Display = new DrawData(ConsoleColor.Red, DefaultChar);
        }
    }
}