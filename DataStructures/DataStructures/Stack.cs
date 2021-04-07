using System;


namespace DataStructures
{
    class Stack<T>
    {
        public T[] StackArray { get; private set; } = new T[1];
        
        public int Count { get; private set; }

        
        public T Peek()
        {
            if (Count < 1)
            {
                throw new IndexOutOfRangeException("This Stack is empty.");
            }

            return StackArray[Count - 1];
        }

        
        public T Pop()
        {
            if (Count < 1)
            {
                throw new IndexOutOfRangeException("This Stack is empty.");
            }

            T topItem = StackArray[Count - 1];

            if (Count > 1)
            {
                Count -= 1;

                T[] newArray = new T[Count];

                for (int i = 0; i < Count; i++)
                {
                    newArray[i] = StackArray[i];
                }

                StackArray = newArray;

                return topItem;
            }

            else
            {
                StackArray[0] = default(T);
                Count = 0;

                return topItem;
            }
        }

        
        public void Push(T item)
        {
            if (Count == 0)
            {
                StackArray[0] = item;
                Count = 1;

                return;
            }

            Count += 1;

            T[] newArray = new T[Count];

            for (int i = 0; i < Count - 1; i++)
            {
                newArray[i] = StackArray[i];
            }

            newArray[Count - 1] = item;

            StackArray = newArray;
        }


        public void PrintAll()
        {
            Console.WriteLine("[TOP] ");

            for (int i = Count - 1; i >= 0; i--)
            {
                Console.WriteLine($"{StackArray[i]}, ");
            }

            Console.WriteLine("[BOTTOM]");
        }
    }
}
