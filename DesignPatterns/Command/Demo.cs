using System;

namespace DesignPatterns.Command
{
    public class Demo
    {
        private const int NumActionsPerTurn = 2;
        private static ConsoleKey _attackKey, _endTurnKey, _moveKey, _hunkerKey;

        public static void Run()
        {
            Rebind();
            Console.Clear();
            PrintBindings();

            int actionCounter = 0;
            int turnCounter = 0;
            bool requestEndTurn = true;
            while (true)
            {
                if (requestEndTurn)
                {
                    requestEndTurn = false;
                    turnCounter++;
                    actionCounter = 0;
                    Console.WriteLine("============");
                    Console.WriteLine($"Turn #{turnCounter}: BEGIN");
                }
                Console.WriteLine("--------------");
                Console.WriteLine($"Perform an action by pressing one of the bound keys. ({NumActionsPerTurn - actionCounter} actions remaining this turn)");

                ConsoleKeyInfo key = Console.ReadKey(true);

                // TODO: Add "undo" ability
                if (key.Key == ConsoleKey.R)
                {
                    Console.Clear();
                    Rebind();
                }
                else if (key.Key == ConsoleKey.Escape)
                {
                    Environment.Exit(0);
                }
                else if (key.Key == ConsoleKey.H)
                {
                    Console.Clear();
                    PrintBindings();
                }
                else if (key.Key == _endTurnKey)
                {
                    Console.WriteLine($"Ending turn #{turnCounter}");
                    requestEndTurn = true;
                }
                else if (actionCounter < NumActionsPerTurn)
                {
                    if (key.Key == _attackKey)
                    {
                        Console.WriteLine("> Attack");
                    }
                    else if (key.Key == _moveKey)
                    {
                        Console.WriteLine("> Move");
                    }
                    else if (key.Key == _hunkerKey)
                    {
                        Console.WriteLine("> Hunker Down");
                    }
                    actionCounter++;
                }
                else
                {
                    Console.WriteLine("You cannot perform any additional actions this turn.");
                }
            }

            Console.WriteLine("\nPress any key to quit.");
            Console.ReadKey();
        }

        private static void Rebind()
        {
            Console.WriteLine("For each of the following actions, please press the key you'd like to bind.");
            Console.Write("Attack:\t");
            _attackKey = Console.ReadKey().Key;
            Console.WriteLine(_attackKey);

            Console.Write("Move:\t");
            _moveKey = Console.ReadKey().Key;
            Console.WriteLine(_moveKey);

            Console.Write("Hunker:\t");
            _hunkerKey = Console.ReadKey().Key;
            Console.WriteLine(_hunkerKey);

            Console.Write("End Turn:\t");
            _endTurnKey = Console.ReadKey().Key;
            Console.WriteLine(_endTurnKey);
        }

        private static void PrintBindings()
        {
            Console.WriteLine("\n*** INPUT BINDINGS ***");
            Console.WriteLine($"Attack: {_attackKey}");
            Console.WriteLine($"Move: {_moveKey}");
            Console.WriteLine($"Hunker Down: {_hunkerKey}");
            Console.WriteLine($"End Turn: {_endTurnKey}");
            Console.WriteLine("Rebind: R");
            Console.WriteLine("Help: H");
            Console.WriteLine("Quit: Escape");
        }
    }
}