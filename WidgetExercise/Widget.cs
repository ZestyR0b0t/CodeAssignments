using System;

namespace WidgetExercise
{
    public class Widget
    {
        private readonly string _desc;             // combination of adjective and object name, ex. "slimy crystal"
        private readonly string _adjective;        // ex. "slimy"
        private readonly string _objectName;       // ex. "crystal"

        public Widget(string adj, string obj)
        {
            _desc = adj + " " + obj;               // cache combination of adjective and object name as "description".
            _adjective = adj;
            _objectName = obj;
        }

        public string GetDescription()
        {
            return _desc;
        }

        public string GetAdjective()
        {
            return _adjective;
        }

        public string GetObjectName()
        {
            return _objectName;
        }

        public void PrintWidgetDesc()
        {
            Console.WriteLine($" That {GetObjectName()} is {GetAdjective()}");
        }
    }
}