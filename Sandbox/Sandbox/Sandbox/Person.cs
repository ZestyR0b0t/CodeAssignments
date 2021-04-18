using System;

namespace Sandbox
{
    public class Person : IEquatable<Person>
    {
        private readonly string _name;
        private readonly ushort _birthYear; // Max of 65k

        public Person(string name, ushort birthYear)
        {
            _name = name;
            _birthYear = birthYear;
        }

        public bool Equals(Person aPerson)
        {
            if (_name != aPerson._name)
            {
                return false;
            }

            if (_birthYear != aPerson._birthYear)
            {
                return false;
            }

            return true;
        }
    }
}
