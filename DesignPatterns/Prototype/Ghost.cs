namespace DesignPatterns.Prototype
{
    public class Ghost : Monster
    {
        private readonly int _spellPower;

        public Ghost(int spellPower) : base(50)
        {
            _spellPower = spellPower;
        }
    }
}