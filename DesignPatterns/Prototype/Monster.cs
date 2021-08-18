using System;

namespace DesignPatterns.Prototype
{
    public abstract class Monster
    {
        private readonly int _maxHealth;
        public int Health { get; set; }
        public int X { get; protected set; }
        public int Y { get; protected set; }

        protected Monster(int maxHealth)
        {
            _maxHealth = maxHealth;
            Health = _maxHealth;
        }

        public void SetPosition(int x, int y)
        {
            X = x;
            Y = y;
        }

        public abstract Monster Clone();
    }
}