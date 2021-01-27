 namespace InheritanceExercise01
 {
    public static class Extensions
    {
        public static bool EqualsIgnoreCase(this string a, string b)
        {
            return string.Equals(a, b, System.StringComparison.InvariantCultureIgnoreCase);
        }
    }
 }