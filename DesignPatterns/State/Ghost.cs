using System;
using DesignPatterns.Core;

namespace DesignPatterns.State
{
    public class Ghost : IEntity
    {
        // TODO: Ghost behavior!
        // When ghost is alive, by default, ghost should chase Pac-Man. The ghost should be magenta while alive.
        // If Pac-Man has eaten an energizer, though, the ghost should turn cyan color, and run away from Pac-Man.
        // If Pac-Man eats a ghost while on an energizer, the ghost should die.
        // If the ghost is dead, it should make its way "home" (box in the middle of the screen).
        // When dead, the ghost should become white, and should use a different character for its display.
        // Once the ghost has reached "home", it should come back to life and resume its normal chase behavior.
        //
        // By the way, PacMan is invincible in this version, so don't worry about killing him.
        private const char DeadChar = '%';
        private const char DefaultChar = 'Ω';
        private const int MsBetweenMovement = 500; // Rather than representing speed the right way, we're doing it this way :painlaugh:

        private readonly PacMan _pacMan; // Would be better to pass World into Ghost and retrieve this from there, but this will do for the demo.
        private int _msSinceLastMove = 0;
        private bool _isScared;

        public DrawData Display { get; private set; }

        public bool IsDead { get; private set; }

        public Vector2 Position { get; private set; }

        public Ghost(PacMan pacMan)
        {
            _pacMan = pacMan;
            Position = World.GhostHome;
            Display = new DrawData(ConsoleColor.Magenta, DefaultChar);
        }

        public void Update(int deltaTimeMs)
        {
            _isScared = _pacMan.IsEnergized;

            if (!_isScared)
            {
                Display.Color = ConsoleColor.Magenta;
                MoveTowardsPos(_pacMan.Position, deltaTimeMs); // TODO: Only do this when not scared, and not dead
            }

            // TODO: If pac-man has eaten an energizer, get scared
            if (_isScared)
            {
                Display.Color = ConsoleColor.Cyan;
                MoveAwayFromPos(_pacMan.Position, deltaTimeMs);

            }

            // TODO: If ghost is scared and pac-man at the same pos as ghost, ghost dies (eval this before moving ghost away from pac-man)
            if (_isScared && (Position == _pacMan.Position))
            {
                IsDead = true;
                Display.Color = ConsoleColor.White;
            }

            // TODO: If ghost is dead and is not yet at "home", move towards home
            if (IsDead && (Position != World.GhostHome))
            {
                MoveTowardsPos(World.GhostHome, deltaTimeMs);
            }

            // TODO: If ghost is dead and is at home, resurrect ghost
            if (IsDead && (Position == World.GhostHome))
            {
                IsDead = false;
                _isScared = false;
            }
        }

        // No reason to change the implementation of the method below. Yes, it sucks.
        private void MoveTowardsPos(Vector2 target, int deltaTimeMs)
        {

            _msSinceLastMove += deltaTimeMs;
            if (_msSinceLastMove < MsBetweenMovement)
            {
                return;
            }

            _msSinceLastMove = 0;
            Display.PreviousPosition = Position;

            int newX = Position.X;
            int newY = Position.Y;

            int xDelta = target.X - Position.X;
            int yDelta = target.Y - Position.Y;
            if (xDelta > 0)
            {
                newX += 1;
            }
            else if (xDelta < 0)
            {
                newX -= 1;
            }

            if (yDelta > 0)
            {
                newY += 1;
            }
            else if (yDelta < 0)
            {
                newY -= 1;
            }

            newX = Math.Clamp(newX, 0, World.Width);
            newY = Math.Clamp(newY, 0, World.Height);
            Position = new Vector2(newX, newY);
        }

        private void MoveAwayFromPos(Vector2 target, int deltaTimeMs)
        {
            _msSinceLastMove += deltaTimeMs;
            if (_msSinceLastMove < MsBetweenMovement)
            {
                return;
            }
            _msSinceLastMove = 0;
            Display.PreviousPosition = Position;
            int newX = Position.X;
            int newY = Position.Y;
            int xDelta = target.X - Position.X;
            int yDelta = target.Y - Position.Y;
            if (xDelta > 0)
            {
                newX -= 1;
            }
            else
            {
                newX += 1;
            }
            if (yDelta > 0)
            {
                newY -= 1;
            }
            else
            {
                newY += 1;
            }
            newX = Math.Clamp(newX, 0, World.Width);
            newY = Math.Clamp(newY, 0, World.Height);
            Position = new Vector2(newX, newY);
        }
    }
}