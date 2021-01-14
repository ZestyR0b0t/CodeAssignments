using System;
/***
namespace DryExercise01
{
    public class ActionHandler
    {
        private bool fidoHasTreat = false;
        private bool spotHasTreat = false;
        private bool lassieHasTreat = false;

        public void HandleAction(string action, string target)
        {
            // Current valid actions:
            // "treat <dog name>": gives dog a treat, if possible.
            // "talk <dog name>": talk to dog, dog responds differently depending on whether they have a treat or not.

            if (action.EqualsIgnoreCase("treat")) // If the player is giving a treat to a dog...
            {
                // Should only be able to give a dog a treat if they don't already have one.
                // If they already have a treat, print output that says as much to the user.

                if (target.EqualsIgnoreCase("lassie"))
                {
                    if (lassieHasTreat == true)
                    {
                        Console.WriteLine("Lassie already has a treat!");
                    }
                    else
                    {
                        Console.WriteLine("You gave Lassie a treat.");
                        lassieHasTreat = true;
                    }
                }
                else if (target.EqualsIgnoreCase("spot"))
                {
                    if (spotHasTreat == true)
                    {
                        Console.WriteLine("Spot already has a treat!");
                    }
                    else
                    {
                        Console.WriteLine("You gave Spot a treat.");
                        spotHasTreat = true;
                    }
                }
                else if (target.EqualsIgnoreCase("fido"))
                {
                    if (fidoHasTreat == true)
                    {
                        Console.WriteLine("Fido already has a treat!");
                    }
                    else
                    {
                        Console.WriteLine("You gave Fido a treat.");
                        fidoHasTreat = true;
                    }
                }
                else 
                {
                    Console.WriteLine("There is no dog named " + target + " !");
                }
            }
            else if (action == "talk") // if the player is talking to the dog...
            {
                // If dog has treat, they should bark happily when talked to
                // If dog does not have a treat, they should bark in a way that kinda implies they're asking for a treat.

                if (target.EqualsIgnoreCase("lassie"))
                {
                    if (lassieHasTreat == true)
                    {
                        Console.WriteLine("Lassie barks happily!");
                    }
                    else
                    {
                        Console.WriteLine("Lassie barks, seemingly asking for a treat.");
                    }
                }
                else if (target.EqualsIgnoreCase("spot"))
                {
                    if (spotHasTreat == true)
                    {
                        Console.WriteLine("Spot barks happily!");
                    }
                    else
                    {
                        Console.WriteLine("Spot barks, seemingly asking for a treat.");
                    }
                }
                else if (target.EqualsIgnoreCase("fido"))
                {
                    if (fidoHasTreat == true)
                    {
                        Console.WriteLine("Fido barks happily!");
                    }
                    else
                    {
                        Console.WriteLine("Fido barks, seemingly asking for a treat.");
                    }
                }
                else 
                {
                    Console.WriteLine("There is no dog named " + target + " !");
                }
            }
            else
            {
                Console.WriteLine("You can't " + action + " right now.");
            }
        }
    }
}
***/