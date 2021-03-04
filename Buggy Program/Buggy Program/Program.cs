using System;

namespace Buggy_Program
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a string:");
            string word = Console.ReadLine();
            
            Console.WriteLine("\nEnter a single character:");
            string characterToFind = Console.ReadLine().Substring(0);
            
            int charCount = 0;
            string currentChar;
            for (int i = 0; i < word.Length; i++)
            {
                currentChar = word.Substring(i);
                
	            if (currentChar == characterToFind)
                {
                    charCount++;
                }
            }
            
            Console.WriteLine($"\'{characterToFind}\' appears {charCount} times.");
            return;
        }
    }
}
