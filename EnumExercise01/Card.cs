namespace EnumExercise01
{
    public class Card
    {
        public enum Ranks
        {
            Two,
            Three,
            Four, 
            Five, 
            Six,
            Seven,
            Eight,
            Nine,
            Ten,
            Jack,
            Queen,
            King,
            Ace
        }
        public enum Suits
        {
            Clubs,
            Diamonds,
            Hearts,
            Spades
        }
        private readonly Ranks _rank;
        private readonly Suits _suit;

        public Card(Ranks rank, Suits suit)
        {
            _rank = rank;
            _suit = suit;
        }
        public Ranks GetRank()
        {
            return _rank; 
        }
        public Suits GetSuit()
        {
            return _suit; 
        }
    }
}

        // TODO: Fill out this class!

        // TODO: Add enums for rank and suit! You can define enums right in this class, if you want them to be "paired" (associated) with the class itself.
        //       When you define an enum within another class, you need to qualify the name of the enum with the outer class name. So if I define an "Action" class,
        //       and I define a "Type" enum within that class, if I want to refer to that enum outside of the "Action" class, I would need to refer to it as "Action.Type".

        // Valid Ranks: Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace
        // Valid Suits: Clubs, Diamonds, Hearts, Spades