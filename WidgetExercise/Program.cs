using System;
using System.Collections.Generic;

namespace WidgetExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Widget> randomWidgets = WidgetGenerator.GetRandomWidgets();

            PrintControls();
            while(true)
            {
                Console.WriteLine("\nPlease type a command:");
                string input = Console.ReadLine();
                Console.Clear();
                HandleUserInput(input, randomWidgets);
            }
        }

        public static void HandleUserInput(string userInput, List<Widget> widgets)
        {
            switch (userInput)
            {
                case "list" or "widgets":
                    OnList(widgets);
                    break;
                case "controls" or "help":
                    PrintControls();
                    break;
                case "quit" or "exit":
                    Environment.Exit(0);
                    break;
                default:
                    string[] inputs = userInput.Split(' ', 2, StringSplitOptions.TrimEntries);
                    if (inputs[0] == "investigate")
                    {
                        OnInvestigateWidget(inputs[1], widgets);
                    }
                    else
                    {
                        Console.WriteLine($"\"{userInput}\" is not a valid command.");
                    }
                    break;
            }
        }

        public static void OnInvestigateWidget(string widgetDesc, List<Widget> widgets)
        {
            // "widgetDesc" will be the words the user typed in after the word "investigate". It may or may not match one
            // of our valid widgets.

            // "widgets" is the list of all valid widgets.

            // TODO: Add logic in here, Ryan!
        }

        public void OnInvalidWidget(string widgetDesc)
        {
            Console.WriteLine($"There is no {widgetDesc} to investigate.");
        }

        public static void OnList(List<Widget> widgets)
        {
            Console.WriteLine("**** Widgets *****");
            for (int i = 0; i < widgets.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {widgets[i].GetDescription()}");
            }
            Console.WriteLine("*******************");
        }

        private static void PrintControls()
        {
            Console.Clear();
            Console.WriteLine("**** Controls *****");
            Console.WriteLine("> \"list\": list random widgets");
            Console.WriteLine("> \"investigate <widget description>\": investigate the specified widget");
            Console.WriteLine("> \"controls\": prints this list of controls");
            Console.WriteLine("> \"quit\": quits the application");
            Console.WriteLine("*******************");
        }
    }
}
