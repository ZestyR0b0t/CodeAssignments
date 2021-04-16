using System;
using System.Collections.Generic;

namespace Sandbox
{
    class Program 
    {
        static void Main(string[] args)
        {
            RestRequester requester = new RestRequester();
            requester.MakeRequests();

            Console.ReadLine(); // Putting this here so we don't exit out of program before we get response from server.
        }
    }
}
