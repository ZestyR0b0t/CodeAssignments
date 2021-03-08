using System;
// DO NOT USE System.Collections.Generic OR System.Collections IN HERE!!!

namespace DataStructures
{
    // Represents a simple last-in-first-out (LIFO) collection of items.
    class Stack
    {
        // Gets how many elements are on the stack.
        public int Count { get; private set; }

        // Returns the item on the top of the stack without removing it.
        public string Peek()
        {
            return null; // TODO: Implement this
        }

        // Removes and returns the object at the top of the stack.
        public string Pop()
        {
            return null; // TODO: Implement this
        }

        // Inserts the given item at the top of the Stack.
        public void Push(string item)
        {
            // TODO: Implement this
        }

        // Prints out all items in the stack, as a comma-separated list. The
        // output should also include the words "[TOP]" and "[BOTTOM]" and the beginning/end (or vice-versa)
        // to indicate the top and bottom of your stack. Which one comes first depends on how you set up
        // your stack.
        // (ex. where 4 was the last item pushed onto the stack: [BOTTOM] 1, 2, 3, 4 [TOP])
        public void PrintAll()
        {
            // TODO: Implement this
        }
    }
}
