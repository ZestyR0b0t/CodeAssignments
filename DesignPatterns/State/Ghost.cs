using System;
using DesignPatterns.State.StateMachineStuff;using DesignPatterns.Core;

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
        private const int MsBetweenMovement = 500; // Rather than representing speed the right way, we're doing it this way :painlaugh:

        public PacMan PacMan { get; private set; } // Would be better to pass World into Ghost and retrieve this from there, but this will do for the demo.
        private int _msSinceLastMove = 0;

        public enum States
        {
            Chase, 
            Scared, 
            Dead
        }

        public StateMachine<Ghost, States> MyStateMachine { get; set; }

        public DrawData Display { get; private set; }

        public bool IsDead { get; private set; }

        public Vector2 Position { get; private set; }

        public Ghost(PacMan pacMan)
        {
            PacMan = pacMan;
            Position = World.GhostHome;
            Display = new DrawData();
            MyStateMachine = new StateMachine<Ghost, States>(States.Chase, this);
        }

        public void Update(int deltaTimeMs)
        {
            MyStateMachine.CurrentState.Update(this, deltaTimeMs);
            }

        // No reason to change the implementation of the method below. Yes, it sucks.
        public void MoveTowardsPos(Vector2 target, int deltaTimeMs)
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

        public void MoveAwayFromPos(Vector2 target, int deltaTimeMs)
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