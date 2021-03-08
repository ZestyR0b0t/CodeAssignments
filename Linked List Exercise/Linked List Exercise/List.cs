using System;


namespace Linked_List_Exercise
{ 
    class LList
    {
        public Node head = new Node(null);


        public void AddFirst(int toAdd)
        {
            if (head.Reference != null)
            {
                Node originalHeadReference = head.Reference;
                head.Reference = new Node(toAdd)
                {
                    Reference = originalHeadReference
                };
            }

            else
            {
                head.Reference = new Node(toAdd);
            }
        }

        public void AddLast(int toAdd)
        {
            Node currentNode = head;

            while (true)
            {
                if (currentNode.Reference == null)
                {
                    currentNode.Reference = new Node(toAdd);
                    break;
                }

                currentNode = currentNode.Reference;
            }
        }

        public void Remove(int toRemove)
        {
            Node currentNode = head;
            Node previousNode = head;

            while (true)
            {
                if (currentNode.Data == toRemove && currentNode.Reference != null)
                {
                    previousNode.Reference = currentNode.Reference;
                    break;
                }

                if (currentNode.Data == toRemove && currentNode.Reference == null)
                {
                    previousNode.Reference = null;
                    break;
                }

                previousNode = currentNode;
                currentNode = currentNode.Reference;
            }
        }

        public void RemoveFirst()
        {
            head.Reference = head.Reference.Reference;
        }

        public void RemoveLast()
        {
            Node currentNode = head;
            Node previousNode = head;

            while (true)
            {
                if (currentNode.Reference != null)
                {
                    previousNode = currentNode;
                    currentNode = currentNode.Reference;
                }

                else
                {
                    previousNode.Reference = null;
                    break;
                }
            }
        }

        public void PrintAll()
        {
            Node currentNode = head;

            while (true)
            {
                currentNode = currentNode.Reference;
                Console.Write(currentNode.Data);

                if (currentNode.Reference == null)
                {
                    break;
                }
            }
        }
    }
}
