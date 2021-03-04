using System;
using System.Collections.Generic;

namespace Linked_List_Exercise
{
    class List
    {
        private List<Node> _list;

        public List(int data)
        {
            _list = new List<Node>
            {
                new Node(data)
                {
                    Reference = 1
                }
            };
        }

        public void AddFirst(int toAdd)
        {
            foreach (Node node in _list)
            {
                node.Reference += 1;
            }
           
            _list.Insert(0, new Node(toAdd) { Reference = 1 });

            Node lastNode = _list[_list.Count - 1];
            lastNode.Reference = 0;
        }


        public void AddLast(int toAdd)
        {
            Node lastNode = _list[_list.Count - 1];
            lastNode.Reference = _list.Count + 1;

            _list.Add(new Node(toAdd) { Reference = 0 });
        }

        public void Remove(int toRemove)
        {
            int removedReference = 0;
            foreach (Node node in _list)
            {
                if (node.Data == toRemove)
                {
                    removedReference = node.Reference;
                    _list.Remove(_list[removedReference - 1]);
                }
            }

            foreach (Node node in _list)
            {
                if (node.Reference != 0 && node.Reference > removedReference)
                {
                    node.Reference -= 1;
                }
            }

            if (removedReference != 0)
            {
                Node lastNode = _list[_list.Count - 1];
                lastNode.Reference = 0;
            }
        }

        public void RemoveFirst()
        {
            if (_list.Count < 1)
            {
                throw new InvalidOperationException("The list is empty!");
            }

            _list.RemoveAt(0);

            foreach (Node node in _list)
            {
                if (node.Reference != 0)
                {
                    node.Reference -= 1;
                }
            }
        }

        public void RemoveLast()
        {
            if (_list.Count < 1)
            {
                throw new InvalidOperationException("The list is empty!");
            }

            _list.RemoveAt(_list.Count - 1);

            Node lastNode = _list[_list.Count - 1];
            lastNode.Reference = 0;
        }

        public void PrintAll()
        {
            foreach (Node node in _list)
            {
                Console.WriteLine(node.Data);
            }
        }
    }
}
