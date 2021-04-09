namespace Sandbox
{
    public class Person
    {
        private readonly string _name;
        private readonly ushort _birthYear; // Max of 65k

        public Person(string name, ushort birthYear)
        {
            _name = name;
            _birthYear = birthYear;
        }
    }
}
