using System;
using System.Collections.Generic;

namespace DryExercise01
{
    public class ActionHandler
    {
        //If you want to add a dog, add it to this list
        private readonly List<Dog> Dogs = new List<Dog>
        {
            new Dog("Fido", false),
            new Dog("Spot", false),
            new Dog("Lassie", false)
        };
        private bool _personSaidTreat; 
        private Dog _dog; 

        public void HandleAction(string action, string target)
        {
            if (InputIsValid(action, target))
            {
                bool HasTreat = _dog.HasTreat();
                if (_personSaidTreat)
                {
                    _personSaidTreat = false;
                    if (HasTreat)
                    {
                        _dog.AlreadyHasTreat();
                        return;
                    }
                    _dog.GiveATreat();
                }
                else
                {
                    if (HasTreat)
                    {
                        _dog.DogBarks();
                        return;
                    }
                    _dog.BarksForTreat();
                }
            }
        }
        public bool InputIsValid(string action, string target)
        {
            if (action.EqualsIgnoreCase("treat"))
            {
                _personSaidTreat = true;

                foreach (Dog dog in Dogs)
                if (target.EqualsIgnoreCase(dog.GetDogName()))
                {
                    _dog = dog;
                    return true; 
                }
                Console.WriteLine($"There is no dog named {target}!");
                return false;
            }

            if(action.EqualsIgnoreCase("talk"))
            {
                foreach (Dog dog in Dogs)
                if (target.EqualsIgnoreCase(dog.GetDogName()))
                {
                    _dog = dog;
                    return true; 
                }
                Console.WriteLine($"There is no dog named {target}!");
                return false;
            }
            Console.WriteLine($"You can't {action} right now.");
            return false;
        }
    }

    public class Dog
    {
        private readonly string _name;
        private bool _hasTreat;
        
        public Dog(string argName, bool argHasTreat)
        {
            _name = argName;
            _hasTreat = argHasTreat;
        }
        public string GetDogName()
        {
            return _name;
        }
        public bool HasTreat()
        {
            return _hasTreat;
        }

        public void InvalidName()
        {
            Console.WriteLine($"There is no dog named {GetDogName()}.");
        }
        public void AlreadyHasTreat()
        {
            Console.WriteLine($"{GetDogName()} already has a treat!");
        }
        public void GiveATreat()
        {
            Console.WriteLine($"You gave {GetDogName()} a treat.");
            _hasTreat = true;
        }
        public void DogBarks()
        {
            Console.WriteLine($"{GetDogName()} barks happily!");
        }
        public void BarksForTreat()
        {
            Console.WriteLine($"{GetDogName()} barks, seemingly asking for a treat.");
        }
    }
}