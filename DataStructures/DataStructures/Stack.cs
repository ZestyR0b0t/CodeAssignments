using System;


namespace DataStructures
{
    
    class Stack
    {   
        public string[] StackArray { get; private set; }
        
        public int Count { get; private set; }

        
        public string Peek()
        {
            if (Count < 1)
            {
                throw new IndexOutOfRangeException("This Stack is empty.");
            }

            return StackArray[Count + 1];
        }

        
        public string Pop()
        {
            if (Count == 0)
            {
                throw new IndexOutOfRangeException("This Queue is empty.");
            }

            string topItem = StackArray[Count + 1];

            if (Count > 1)
            {
                Count -= 1;

                string[] newArray = new string[Count];

                int index = 0;

                foreach (string i in StackArray)
                {
                    if (Array.IndexOf(StackArray, i) != Count + 1)
                    {
                        newArray[index] = i;
                        index++;
                    }
                }

                StackArray = newArray;

                return topItem;
            }

            else
            {
                StackArray[0] = null;
                Count = 0;

                return topItem;
            }
        }

        
        public void Push(string item)
        {
            if (Count == 0)
            {
                StackArray[0] = item;
                Count = 1;

                return;
            }

            Count += 1;

            string[] newArray = new string[Count];

            Array.Copy(StackArray, newArray, Count - 1);

            newArray[Count] = item;

            StackArray = newArray;
        }


        public void PrintAll()
        {
            Console.WriteLine("[TOP]");

            string[] newArray = new string[Count];
            Array.Copy(StackArray, newArray, Count);
            Array.Reverse(newArray);

            foreach (string i in newArray)
            {
                Console.Write($" {i},");
            }

            Console.WriteLine(" [BOTTOM]");
        }
    }
}
