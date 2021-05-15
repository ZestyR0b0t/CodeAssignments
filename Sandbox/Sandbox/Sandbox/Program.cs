using System;
using System.Collections.Generic;

namespace Sandbox
{
    class Program 
    {
        static void Main(string[] args)
        {
            RestRequesterer requesterer = new RestRequesterer();
            requesterer.GetCreatureTypes();

            Console.ReadLine(); // Putting this here so we don't exit out of program before we get response from server.
        }
    }
}
