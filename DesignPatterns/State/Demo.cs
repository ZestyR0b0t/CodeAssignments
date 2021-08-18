using System;

namespace DesignPatterns.State
{
    public class Demo
    {
        private static DateTime _lastUpdate;

        public static void Run()
        {
            World world = new World();
            PacMan pacMan = new PacMan(world);
            Ghost blinky = new Ghost(pacMan);


            world.AddToWorld(blinky);
            world.AddToWorld(pacMan);

            _lastUpdate = DateTime.Now; // Initialize this here, otherwise we get a crazy delta time on first update loop iteration.

            while (true)
            {
                DateTime now = DateTime.Now;
                int deltaTimeMs = (int)(now - _lastUpdate).TotalMilliseconds;
                _lastUpdate = now;

                if (Console.KeyAvailable) // This doesn't eval to true unless a key is being pressed.
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    switch (key.Key)
                    {
                        case ConsoleKey.UpArrow:
                            pacMan.Move(Direction.North);
                            break;
                        case ConsoleKey.DownArrow:
                            pacMan.Move(Direction.South);
                            break;
                        case ConsoleKey.LeftArrow:
                            pacMan.Move(Direction.West);
                            break;
                        case ConsoleKey.RightArrow:
                            pacMan.Move(Direction.East);
                            break;
                        default:
                            break;
                    }
                }

                pacMan.Update(deltaTimeMs);
                blinky.Update(deltaTimeMs);

                world.Draw();
            }
        }
    }
}