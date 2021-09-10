using System;
using DesignPatterns.Core;

namespace DesignPatterns.ObjectPool
{
    public class Screen
    {
        public const int Width = 75;
        public const int Height = 25;

        private static readonly Vector2 TopLeft = new Vector2(0, 0);
        private const ConsoleColor BorderColor = ConsoleColor.Blue;

        public Screen()
        {
            Console.CursorVisible = false;
        }

        public void Draw()
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
            foreach (Particle p in ParticleMgr.Instance.Particles)
            {
                if (!p.IsDead)
                {
                    Console.SetCursorPosition( p.Position.X + 1, p.Position.Y + 1);
                    Console.ForegroundColor = p.Display.Color;
                    Console.Write(p.Display.Character);
                }

                // erase old pos
                if (p.Display.PreviousPosition.Initialized && p.Position != p.Display.PreviousPosition)
                {
                    Console.SetCursorPosition( p.Display.PreviousPosition.X + 1, p.Display.PreviousPosition.Y + 1);
                    Console.Write(' ');
                    // FIXME: Figure out a way to make this not erase other entities if they happen to be in the previous position
                }
            }

            Console.ResetColor();
        }
    }
}