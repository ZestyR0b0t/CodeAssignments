using System;

namespace InterfacesAndGenerics
{
    // TODO: Add whatever methods/interface implementations you need to this class.
    public class Document
    {
        private readonly string _fileName;
        private readonly DateTime _createdTime;

        public Document(string fileName, DateTime createdTime)
        {
            _fileName = fileName;
            _createdTime = createdTime;
        }
    }
}
