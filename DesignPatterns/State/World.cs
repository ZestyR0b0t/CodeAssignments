using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text;

namespace DesignPatterns.State
{
    public class World
    {
        public const int Width = 75;
        public const int Height = 25;
        public static readonly Vector2 GhostHome = new Vector2(Width / 2, Height / 2);

        private static readonly Vector2 TopLeft = new Vector2(0, 0);
        private static readonly Random RandomGen = new Random();
        private const ConsoleColor BorderColor = ConsoleColor.Blue;

        private readonly IList<IEntity> _worldEntities = new List<IEntity>();

        public World()
        {
            Console.CursorVisible = false;
            SpawnPellet();
        }

        public void AddToWorld(IEntity thing)
        {
            _worldEntities.Add(thing);
        }

        public void RemoveFromWorld(IEntity thing)
        {
            _worldEntities.Remove(thing);

            if (thing is PowerPellet)
            {
                SpawnPellet();
            }
        }

        public IEntity GetEntityAtPos(Vector2 pos)
        {
            foreach (IEntity entity in _worldEntities)
            {
                if (entity.Position == pos)
                {
                    return entity;
                }
            }

            return null;
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
            foreach (IEntity thing in _worldEntities)
            {
                Console.SetCursorPosition( thing.Position.X + 1, thing.Position.Y + 1);
                Console.ForegroundColor = thing.Display.Color;
                Console.Write(thing.Display.Character);

                // erase old pos
                if (thing.Display.PreviousPosition.Initialized && thing.Position != thing.Display.PreviousPosition)
                {
                    Console.SetCursorPosition( thing.Display.PreviousPosition.X + 1, thing.Display.PreviousPosition.Y + 1);
                    Console.Write(' ');

                    // FIXME: Figure out a way to make this not erase other entities if they happen to be in the previous position
                }
            }

            Console.ResetColor();
        }

        private void SpawnPellet()
        {
            int x = RandomGen.Next(0, Width);
            int y = RandomGen.Next(0, Height);
            AddToWorld(new PowerPellet(x, y));
        }
    }
}