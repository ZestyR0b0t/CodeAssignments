using System;


namespace DataStructures
{
    class Queue
    {
        public string[] QueueArray { get; private set; }
        public int Count { get; private set; }

        public Queue()
        {
            QueueArray = new string[1];
            Count = 0;
        }

        
        public string Peek()
        {
            if (Count == 0)
            {
                throw new IndexOutOfRangeException("This Queue is empty.");
            }

            return QueueArray[0];
        }

        
        public string Dequeue()
        {
            if (Count == 0)
            {
                throw new IndexOutOfRangeException("This Queue is empty.");
            }

            string firstItem = QueueArray[0];
            
            if (Count > 1)
            {
                Count -= 1;

                string[] newArray = new string[Count];

                int index = 0;

                foreach (string i in QueueArray)
                {
                    if (Array.IndexOf(QueueArray, i) != 0)
                    {
                        newArray[index] = i;
                        index++;
                    }
                }

                QueueArray = newArray;

                return firstItem;
            }

            else
            {
                QueueArray[0] = null;
                Count = 0;

                return firstItem;
            }
        }


        public void Enqueue(string item)
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

                string[] newArray = new string[Count];
                int index = 0;

                foreach (string i in QueueArray)
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

            foreach (string i in QueueArray)
            {
                Console.Write($" {i},");
            }

            Console.Write(" [BACK]");
        }
    }
}
