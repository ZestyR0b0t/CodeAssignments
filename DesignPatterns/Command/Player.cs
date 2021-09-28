using System;
using DesignPatterns.Core;

namespace DesignPatterns.Command
{
    public class Player : IEntity
    {
        private const int MoveStepDistance = 1;

        public DrawData Display { get; private set; }

        public Vector2 Position { get; private set; }

        public bool IsDead => false;

        public Player()
        {
            Position = new Vector2(0, 0);
            Display = new DrawData(ConsoleColor.Yellow, '@');
        }

        public void MoveUp()
        {
            Move(Vector2.Down);
        }

        public void MoveDown()
        {
            Move(Vector2.Up);
        }

        public void MoveLeft()
        {
            Move(Vector2.Left);
        }

        public void MoveRight()
        {
            Move(Vector2.Right);
        }

        //Helper method to make it more general
        private void Move(Vector2 dir)
        {
            Display.PreviousPosition = Position;

            Position += (dir * MoveStepDistance);
            Position = Position.Clamp(Screen.TopLeft, Screen.BottomRight);
        }
    }
}