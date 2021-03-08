
namespace Linked_List_Exercise
{
    class Node
    {
        public int? Data { get; set; }
        public Node Reference { get; set; } = null;

        public Node(int? data) 
        {
            Data = data;
        }
    }
}
