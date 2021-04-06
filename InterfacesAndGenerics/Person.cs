using System;

namespace InterfacesAndGenerics
{
    // TODO: Add whatever methods/interface implementations you need to this class.
    public class Person
    {
        private readonly DateTime _birthday;
        private readonly string _name;

        public Person(string name, DateTime birthday)
        {
            _name = name;
            _birthday = birthday;
        }
    }
}
