INHERITANCE CONTINUED
-------------------------------

Your objective in the next exercise is to modify this project to do the following:

- Use the "abstract" keyword where it makes the most sense to do so (hint: there is only one "good" place to use it)

- When money is withdrawn from a Savings account, a fee of $5 should be charged (taken out of the savings account, 
but not returned to the user). If the balance is not large enough to support the fee, 
the withdrawal should not be permitted.
  
  TECHNICAL NOTE: Ensure that this works even when the Savings account is being stored as an Account, like:
  Account savings = mySavingsAccount;
  double amount = savings.WithdrawFunds(10.0); // should withdraw $10 dollars, but an additional $5 should 
  be removed as well


NEW CONCEPTS/SYNTAX
-------------------------
Quick reference to example links (also listed below in-context):
- METHOD HIDING: https://dotnetfiddle.net/Ek9Dng
- METHOD OVERRIDING: https://dotnetfiddle.net/ZAz43Z

**********************************
* Abstract (class and method)
**********************************
Ever have a base class that really shouldn't be able to exist on its own (i.e. only derived classes "make sense")?
Ever have a method all derived classes have, but there isn't really an implementation of that method that makes sense
for the base class? Abstract to the rescue!

`````````````````````
public abstract class Shape2D // This "abstract" says, "hey, never let anyone do 'new Shape2D'", 
since what would that even represent?"
{
    protected Color _color = Color.WHITE;

    public abstract double GetArea(); // This "abstract" means, "I don't have an implementation of this behavior, 
    but my derived classes all will!"

    public void SetColor(Color aColor) // You can still define methods with bodies in abstract classes!
    {
        _color = aColor;
    }
}
`````````````````````

When you write a class that derives from an abstract class with abstract methods, you MUST implement methods in that
derived class with the same signatures as the abstract ones in the base class. When you do that, you must augment
the signature in the derived class with "override". Read more in the "Method Overriding" section below.

Also note that you cannot add the "abstract" keyword to methods in non-abstract classes. 
You can't have a class that can be instantiated by itself (i.e. new MyNonAbstractClass()) 
that has a method with no implementation. If you could, what would myNonAbstractClass.AbstractMethod() even do?

Btw, the "Animal" class in the examples below is a great candidate for the "abstract" keyword. 
I just didn't put it on that class (or on the Speak() method) in order to show you 
how to use virtual/override/new with non-abstract classes.

**********************************
* Method Hiding
**********************************

Say you have a method defined in a base class (Speak(), in the following example), 
and you want it to work differently in one or more of the derived classes:

``````````````````````````
public class Animal
{
    private readonly string _commonName;

    public Animal(string name)
    {
        _commonName = name;
    }

    public void Speak()
    {
        Console.WriteLine($"The {_commonName} speaks.");
    }
}
`````````````````````````

You think, "oh cool, I'll just redefine the method in the derived class and make it work differently":

``````````````````
public class Dog : Animal
{
    public Dog() : base("Dog") {}

    public void Speak()
    {
        base.Speak();
        Console.WriteLine("Bark Bark!");
    }
}
``````````````````

First of all, this *does* compile (and kinda work). But you'll get a compiler warning:
"'Dog.Speak()' hides inherited member 'Animal.Speak()'. To make the current member override that implementation, 
add the override keyword. Otherwise add the new keyword."

It's a pretty nice warning, all things considered. But what does it mean when it says that 'Dog.Speak()' 
"hides" 'Animal.Speak()'? Well, the word 'hide' is kind of counter-intuitive, 
in my opinion. Essentially, it means that the implementation of Speak() you added to class Dog 
will ONLY ever be used when you call the method on a varaible of type Dog.

``````````````````
Dog myDog = new Dog();
myDog.Speak(); // uses Dog.Speak();

Animal animalDog = myDog; // storing in base class variable
animalDog.Speak(); // uses Animal.Speak();
````````````````````

Interesting. Well, why is that a warning? Don't people want to do that intentionally sometimes?
Yes! It's totally reasonable to want your code to act like this in certain circumstances. 
The warning is there to prevent you from *accidentally* hiding a method. 
If you want your method to work this way *intentionally*, C# has a keyword for that... "new".
When you use "new" in a method signature, you're telling the compiler (and other developers), 
"Yes, I'm hiding the method. And I did this on purpose.". 
Whether you include "new" or not, the code will behave the same, but you should use "new" to clearly state your intentions.

So re-writing "Dog" to use "new"..
``````````````````
public class Dog : Animal
{
    public Dog() : base("Dog") {}

    public new void Speak() // No compiler warning here, now that we included "new"
    {
        base.Speak();
        Console.WriteLine("Bark Bark!");
    }
}
``````````````````
You can see the METHOD HIDING example in practice here: https://dotnetfiddle.net/Ek9Dng

**********************************
* Method Overriding
**********************************

Okay, so that's cool. But what if I want my fancy new "bark bark" implementation of Speak() to get used for dogs, 
even if those dogs are stored in variables of type Animal? That is called "method overriding", and it's a two-step process.

First, if the method on the base class method you plan on overriding in your derived class is non-abstract, 
you need to add a special keyword to it: "virtual". If the method you're overriding is abstract, 
the "virtual" is kinda implied by the abstract keyword, so you can (and actually, must) skip it.

``````````````````````````
public class Animal
{
    private readonly string _commonName;

    public Animal(string name)
    {
        _commonName = name;
    }

    public virtual void Speak() // "virtual" means, "hey, my derived classes can override this method."
    {
        Console.WriteLine($"The {_commonName} speaks.");
    }
}
`````````````````````````
It's basically the base class giving permission to derived classes that they can "override" the behavior of that method, 
even when the derived object is masquerading as a base class.

The second step is to add the "override" keyword to the corresponding method in the derived class:
``````````````````
public class Dog : Animal
{
    public Dog() : base("Dog") {}

    public override void Speak() // "override" means, "use me, even if I'm being stored as a base class!"
    {
        base.Speak();
        Console.WriteLine("Bark Bark!");
    }
}
``````````````````

With both keywords in place, you'll now see the following behavior:

``````````````````
Dog myDog = new Dog();
myDog.Speak(); // uses Dog.Speak();

Animal animalDog = myDog; // storing in base class variable
animalDog.Speak(); // still uses Dog.Speak();
````````````````````
As a note, you'll use method overriding a hell of a lot more often than method hiding. I can't remember the
last time I actually did any kind of method hiding in a professional setting.

You can see this example of OVERRIDING in practice here: https://dotnetfiddle.net/ZAz43Z