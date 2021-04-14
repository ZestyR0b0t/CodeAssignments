using System;


namespace Linked_List_Exercise
{ 
    class LList
    {
        private Node _head = null;

        public void AddFirst(int toAdd)
        {
            if (_head == null)
            {
                _head = new Node(toAdd);
                return;
            }

            Node originalHeadReference = _head;
            _head = new Node(toAdd)
            {
                NextReference = originalHeadReference
            };
        }

        public void AddLast(int toAdd)
        {
            if (_head == null)
            {
                _head = new Node(toAdd);
                return;
            }

            Node currentNode = _head;

            while(currentNode != null)
            {
                if (currentNode.NextReference == null)
                {
                    currentNode.NextReference = new Node(toAdd);
                    break;
                }

                currentNode = currentNode.NextReference;
            } 
        }

        public void RemoveFirstInstanceOf(int toRemove)
        {
            if (_head == null)
            {
                return;
            }

            Node currentNode = _head;
            Node previousNode = _head;

            while (currentNode != null)
            {
                if (currentNode.Data == toRemove)
                {
                    if (previousNode == currentNode)
                    {
                        // we're at the head... special case
                        _head = currentNode.NextReference;
                    }
                    else
                    {
                        previousNode.NextReference = currentNode.NextReference;
                    }

                    break;
                }

                previousNode = currentNode;
                currentNode = currentNode.NextReference;
            }
        }

        public void RemoveFirst()
        {
            if (_head == null)
            {
                return;
            }

            _head = _head.NextReference;
        }

        public void RemoveLast()
        {
            Node currentNode = _head;
            Node previousNode = _head;

            while (currentNode != null)
            {
                if (currentNode.NextReference == null)
                {
                    if (previousNode == currentNode)
                    {
                        // we're at the head... special case
                        _head = null;
                    }
                    else
                    {
                        previousNode.NextReference = null;
                    }

                    break;
                }
                
                previousNode = currentNode;
                currentNode = currentNode.NextReference;
            }
        }

        public void PrintAll()
        {
            Node currentNode = _head;

            while (currentNode != null)
            {
                Console.Write(currentNode.Data);
                currentNode = currentNode.NextReference;
            }
        }
    }
}
