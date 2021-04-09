using System;

namespace InterfacesAndGenerics 
{
    // TODO: Add whatever methods/interface implementations you need to this class.
    public class Document : IGetAgeInDays
    {
        private readonly string _fileName;
        private readonly DateTime _createdTime;

        public Document(string fileName, DateTime createdTime)
        {
            _fileName = fileName;
            _createdTime = createdTime;
        }

        public int GetAgeInDays()
        {
            DateTime rightNow = DateTime.Now;

            TimeSpan totalAge = rightNow.Subtract(_createdTime);

            return totalAge.Days;
        }

    }
}
