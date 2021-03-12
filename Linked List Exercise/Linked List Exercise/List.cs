using System;


namespace Linked_List_Exercise
{ 
    class LList
    {
        public Node head = new Node(null);


        public void AddFirst(int toAdd)
        {
            if (head.NextReference != null)
            {
                Node originalHeadReference = head.NextReference;
                head.NextReference = new Node(toAdd)
                {
                    NextReference = originalHeadReference
                };
            }

            else
            {
                head.NextReference = new Node(toAdd);
            }
        }

        public void AddLast(int toAdd)
        {
            Node currentNode = head;

            while (true)
            {
                if (currentNode.NextReference == null)
                {
                    currentNode.NextReference = new Node(toAdd);
                    break;
                }

                currentNode = currentNode.NextReference;
            }
        }

        public void Remove(int toRemove)
        {
            Node currentNode = head;
            Node previousNode = head;

            while (true)
            {
                if (currentNode.Data == toRemove)
                {
                    previousNode.NextReference = currentNode.NextReference; 
                    break;
                }

                previousNode = currentNode;
                currentNode = currentNode.NextReference;
            }
        }

        public void RemoveFirst()
        {
            head.NextReference = head.NextReference.NextReference;
        }

        public void RemoveLast()
        {
            Node currentNode = head;
            Node previousNode = head;

            while (true)
            {
                if (currentNode.NextReference != null)
                {
                    previousNode = currentNode;
                    currentNode = currentNode.NextReference;
                }

                else
                {
                    previousNode.NextReference = null;
                    break;
                }
            }
        }

        public void PrintAll()
        {
            Node currentNode = head;

            while (true)
            {
                currentNode = currentNode.NextReference;
                Console.Write(currentNode.Data);

                if (currentNode.NextReference == null)
                {
                    break;
                }
            }
        }
    }
}
