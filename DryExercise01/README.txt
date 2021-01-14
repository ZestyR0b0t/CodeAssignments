1.) Improve the existing code without changing the resultant behavior 
    ("treat" still gives dogs a treat, "talk" still results in the same type of output)!

2.) Make sure that if I want to add more dogs in the future, I don't need to change much code at all. 
    Preferably, I should only need to add a single line of code.

3.) You may not edit anything in `Program.cs` or `Extensions.cs`, 

4.) Feel free to create new classes and/or add/remove/edit anything in `ActionHandler.cs` 
    (though you need to at least keep the HandleAction(action, target) method signature the same so that it can get called in Program.Main()).



    // Current valid actions:
    // "treat <dog name>": gives dog a treat, if possible.
    // "talk <dog name>": talk to dog, dog responds differently depending on whether they have a treat or not.



    // If the player is giving a treat to a dog...
    // Should only be able to give a dog a treat if they don't already have one.
    // If they already have a treat, print output that says as much to the user.



    // if the player is talking to the dog...
    // If dog has treat, they should bark happily when talked to
    // If dog does not have a treat, they should bark in a way that kinda implies they're asking for a treat.
