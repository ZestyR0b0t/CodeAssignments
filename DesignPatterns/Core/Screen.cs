using System;
using System.Collections.Generic;

namespace DesignPatterns.Core
{
    public class Screen
    {
        public const int Width = 75;
        public const int Height = 25;

        public static readonly Vector2 TopLeft = new Vector2(0, 0);
        public static readonly Vector2 BottomRight = new Vector2(Width, Height);
        private const ConsoleColor BorderColor = ConsoleColor.Blue;

        public Screen()
        {
            Console.CursorVisible = false;
        }

        public void Draw<T>(T entity) where T : IEntity
        {
            Draw(new HashSet<T>(){entity});
        }

        public void Draw<T>(ISet<T> entities) where T : IEntity
        {
            Console.SetCursorPosition(TopLeft.X, TopLeft.Y);
            Console.ForegroundColor = BorderColor;
            // draw top border
            Console.Write('╔');
            for (int i = 0; i <= Width; i++)
            {
                Console.Write('=');
            }
            Console.WriteLine('╗');


            // Draw sides and map content
            for (int i = 0; i <= Height; i++)
            {
                Console.Write('║');

                int currentY = Console.CursorTop;

                Console.SetCursorPosition(Width + 2, currentY);
                Console.WriteLine('║');
            }

            // draw bottom border
            Console.Write('╚');
            for (int i = 0; i <= Width; i++)
            {
                Console.Write('=');
            }
            Console.Write('╝');

            // draw stuff in world
            foreach (IEntity e in entities)
            {
                if (!e.IsDead)
                {
                    Console.SetCursorPosition( e.Position.X + 1, e.Position.Y + 1);
                    Console.ForegroundColor = e.Display.Color;
                    Console.Write(e.Display.Character);
                }

                // erase old pos
                if (e.Display.PreviousPosition.Initialized && e.Position != e.Display.PreviousPosition)
                {
                    Console.SetCursorPosition( e.Display.PreviousPosition.X + 1, e.Display.PreviousPosition.Y + 1);
                    Console.Write(' ');
                    // FIXME: Figure out a way to make this not erase other entities if they happen to be in the previous position
                }
            }

            Console.ResetColor();
        }
    }
}