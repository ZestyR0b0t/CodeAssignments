INTRODUCTION TO INHERITANCE!
--------------------------------

You've been hired by a bank to write a virtual banking application for them. To start, they want the app to support both savings accounts and checking accounts.
Here are the properties and behavior of each account type:
CHECKING ACCOUNT:
- Account owner (string)
- Account number (string)
- Balance (double)
- Ability to specify an initial deposit upon creation
- Ability to withdraw funds
- Ability to deposit funds
- Ability to view current balance (just a "get" method)
- Ability to write checks

SAVINGS ACCOUNT:
- Account owner (string)
- Account number (string)
- Balance (double)
- Ability to specify an initial deposit upon creation
- Ability to withdraw funds
- Ability to deposit funds
- Ability to view current balance (just a "get" method)
- Interest Rate (this can, and usually will be, a fractional value -- use a "double")
- Ability to accrue interest annually

Construct a class hierarchy for these account types, including properties and behaviors. Some properties and beahviors can be inherited! No actual app required yet.

NOTES:
- The interest accrual can just be a method. Assume that the method will be called annually.
- Not all savings accounts will have the same interest rate. Allow that to be specified when the account is created.
- Not all accounts will have the same account number or owner. Allow those to be specified when the account is created.
- "Writing a check" just means creating a "Check" object for the appropriate amount and giving that to whoever asked for it. No money is withdrawn. 
  "Check" class is already written for you. No routing numbers at this bank, apparently... they just expose account numbers on their checks lol.
- No need to write code for cashing checks.
- For any value that represents an amount of money, use the "double" type


SYNTAX REMINDERS:

*** Inheritance ***
For class Dog to inherit (or "be derived from") class Animal, you would write the following when defining class Dog:

public class Dog : Animal
{
    // class definition
}

*** Access modifiers ***
- "private" members can only be accessed by the "current" class -- not any classes derived from the current class, or any base classes from which the current class was derived.
- "protected" members can be accessed by the "current" class AND by classes derived from the current class.
- "public" members can be accessed by everyone

*** How to call a base class's constructor from a derived class's constructor ***

// base class
public class Animal
{
    public Animal(string speciesName)
    {
        // stuff happens in here
    }
}

// derived class
public class Dog : Animal
{
    public Dog() : base("Canis Familiaris") // This calls the Animal constructor, and passes "Canis Familiaris" in as the parameter. The word "base" is a C# keyword and is not just some variable name.
    {
        // stuff happens in here
    }
}