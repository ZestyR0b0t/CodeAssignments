using System;

namespace DryExercise01
{
    class Program
    {
        private static ActionHandler handler = new ActionHandler();
        static void Main(string[] args)
        {
            PrintControls();
            while(true)
            {
                Console.WriteLine("** What do you do? **");
                string input = Console.ReadLine();

                Console.Clear();
                string[] inputs = input.Split(' ', 2, StringSplitOptions.TrimEntries);

                if (inputs.Length == 1)
                {
                    if (inputs[0].EqualsIgnoreCase("quit"))
                    {
                        Environment.Exit(0);
                        return;
                    }

                    if (inputs[0].EqualsIgnoreCase("controls"))
                    {
                        PrintControls();
                        continue;
                    }
                }

                if (inputs.Length < 2)
                {
                    Console.WriteLine("** Invalid input, please try again. Type 'controls' for help. **\n\n");
                    continue;
                }

                string action = inputs[0];
                string target = inputs[1];

                handler.HandleAction(action, target);
            }
        }

        private static void PrintControls()
        {
            Console.Clear();
            Console.WriteLine("**** Controls *****");
            Console.WriteLine("> \"treat <dog name>\": gives the dog with the specified name a treat");
            Console.WriteLine("> \"talk <dog name>\": talk to the dog with the specified name");
            Console.WriteLine("> \"controls\": prints this list of controls");
            Console.WriteLine("> \"quit\": quits the application");
            Console.WriteLine("*******************\n");
        }
    }
}
