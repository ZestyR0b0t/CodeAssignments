using System;
using DesignPatterns.Core;

namespace DesignPatterns.Command
{
    public class Demo
    {
        private static ConsoleKey _upKey, _downKey, _leftKey, _rightKey;

        public static void Run()
        {
            Rebind();

            Player pc = new Player();
            Screen screen = new Screen();

            while (true)
            {
                if (Console.KeyAvailable) // This doesn't eval to true unless a key is being pressed.
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    if (key.Key == _upKey)
                    {
                        pc.MoveUp();
                    }
                    else if (key.Key == _downKey)
                    {
                        pc.MoveDown();
                    }
                    else if (key.Key == _leftKey)
                    {
                        pc.MoveLeft();
                    }
                    else if (key.Key == _rightKey)
                    {
                        pc.MoveRight();
                    }
                    else if (key.Key == ConsoleKey.R)
                    {
                        Rebind();
                    }
                    else if (key.Key == ConsoleKey.Escape)
                    {
                        Environment.Exit(0);
                    }
                }

                screen.Draw(pc);
            }
        }

        private static void Rebind()
        {
            Console.WriteLine("For each of the following directions, please press the key you'd like to bind.");
            Console.Write("Up:\t");
            _upKey = Console.ReadKey(true).Key;
            Console.WriteLine(_upKey);

            Console.Write("Down:\t");
            _downKey = Console.ReadKey(true).Key;
            Console.WriteLine(_downKey);

            Console.Write("Left:\t");
            _leftKey = Console.ReadKey(true).Key;
            Console.WriteLine(_leftKey);

            Console.Write("Right:\t");
            _rightKey = Console.ReadKey(true).Key;
            Console.WriteLine(_rightKey);
            Console.Clear();
        }
    }
}