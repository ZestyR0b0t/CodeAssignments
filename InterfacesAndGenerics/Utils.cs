using System;

namespace InterfacesAndGenerics
{
    public static class Utils
    {
        // Returns the older of the two parameters. If the parameters are equal
        // in age, just return the first one (x).
        // TODO: 'Object' type for return type and parameters is a placeholder. Make this generic (with whatever constraints you deem necessary).
        public static T GetOlder<T>(T x, T y) where T : IGetAgeInDays
        {
            if (x.GetAgeInDays() > y.GetAgeInDays())
            {
                return x;
            }

            if (x.GetAgeInDays() < y.GetAgeInDays())
            {
                return y;
            }

            return x; 
        }


        // DO NOT TOUCH
        public static void Assert(bool condition, string failMessage)
        {
            if (condition)
            {
                return;
            }

            Console.WriteLine($"ASSERTION FAILED: {failMessage}");
        }
    }
}
