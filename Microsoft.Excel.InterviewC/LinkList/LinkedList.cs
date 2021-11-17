using System.Text;

namespace Microsoft.Excel.InterviewC.LinkList
{
    public class LinkedList : ILinkedList
    {
        public ILinkedListNode Head { get; set; }
        public int Depth { get; private set; } = 0;

        public ILinkedList Add(int item)
        {
            if (Head == null)
            {
                Head = new LinkedListNode { Value = item };
            }
            else
            {
                ILinkedListNode last = Head;
                while (last.Next != null)
                    last = last.Next;
                last.Next = new LinkedListNode { Value = item };
            }
            Depth++;
            return this;

        }

        public override string ToString()
        {
            if (Head != null)
                return Head.ToString();
            else
                return string.Empty;
        }

    }


}

