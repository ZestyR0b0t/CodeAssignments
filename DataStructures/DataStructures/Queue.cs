using System;


namespace DataStructures
{
    class Queue<T>
    {
        public T[] QueueArray { get; private set; }
        public int Count { get; private set; }

        public Queue()
        {
            QueueArray = new T[1];
            Count = 0;
        }
        
        public T Peek()
        {
            if (Count == 0)
            {
                throw new IndexOutOfRangeException("This Queue is empty.");
            }

            return QueueArray[0];
        }

        
        public T Dequeue()
        {
            if (Count == 0)
            {
                throw new IndexOutOfRangeException("This Queue is empty.");
            }

            T firstItem = QueueArray[0];
            
            if (Count > 1)
            {
                Count -= 1;

                T[] newArray = new T[Count];

                for (int i = 0; i < Count; i++)
                {
                    newArray[i] = QueueArray[i + 1];
                }

                QueueArray = newArray;

                return firstItem;
            }

            else
            {
                QueueArray[0] = default(T);
                Count = 0;

                return firstItem;
            }
        }


        public void Enqueue(T item)
        {
            if (Count == 0)
            {
                QueueArray[0] = item;
                Count += 1;

                return;
            }

            else
            {
                Count += 1;

                T[] newArray = new T[Count];
                int index = 0;

                foreach (T i in QueueArray)
                {
                    newArray[index] = i;
                    index++;
                }

                newArray[Count - 1] = item;
                QueueArray = newArray;
            }
        }


        public void PrintAll()
        {
            Console.Write("[FRONT]");

            foreach (T i in QueueArray)
            {
                Console.Write($" {i},");
            }

            Console.Write(" [BACK]");
        }
    }
}
