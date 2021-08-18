namespace DesignPatterns.Prototype
{
    public class Demon : Monster
    {
        public Demon() : base(75)
        {
            // Nothing special here.
        }

        public override Monster Clone()
        {
            var clone = new Demon();

            clone.Health = Health;

            clone.SetPosition(X, Y);

            return clone; 
        }
    }
}