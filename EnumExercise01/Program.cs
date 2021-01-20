using System;

namespace EnumExercise01
{
    class Program
    {
        // DO NOT TOUCH THIS METHOD
        static void Main(string[] args)
        {
            while(true)
            {
                Console.WriteLine("** Type a card name. Ex: \"queen of hearts\" **");
                string input = Console.ReadLine().ToLowerInvariant();

                string[] inputs = input.Split(" of ", 2, StringSplitOptions.TrimEntries);

                if (inputs.Length < 2)
                {
                    if (inputs.Length == 1 && inputs[0] == "quit")
                    {
                        Environment.Exit(0);
                        return;
                    }

                    Console.WriteLine("** Not enough parameters. Please try again. **\n\n");
                    continue;
                }

                string cardRank = inputs[0];
                string cardSuit = inputs[1];

                ParseInput(cardRank, cardSuit);
            }
        }

        static void ParseInput(string inputRank, string inputSuit)
        {
            // TODO: If rank is invalid, print "** X is not a valid rank **", where "X" is the invalid rank the user provided.
            // TODO: If suit is invalid, print "** X is not a valid suit **", where "X" is the invalid suit the user provided.

            // TODO: If the suit and rank are valid, create a "Card" object with that rank and suit, then uncomment the line below. Add the necessary "Get" methods to the card class.
            //Console.WriteLine($"** Rank: {card.GetRank()} | Suit: {card.GetSuit()}**\n\n");

            // IMPORTANT NOTES!!!! (READ THESE BEFORE WRITING ANY CODE)
            // - You can pass an enum value directly into "Console.WriteLine" or a formatted string (the kind with ${}), and it will auto-convert to a string. No need to manually convert to string.
            // - If you have a string, and you want to parse it into an enum value, you can use the method Enum.TryParse<EnumType>(input, ignoreCase, out result). The syntax is weird, so
            //   here's a snippet link that shows how how to use it: https://dotnetfiddle.net/O4EhwA
            //   I'll explain that weird syntax to you in-person at some point. Here's the official documentation if you'd like more info: https://docs.microsoft.com/en-us/dotnet/api/system.enum.tryparse?view=net-5.0#System_Enum_TryParse__1_System_String_System_Boolean___0__
        }
    }
}
