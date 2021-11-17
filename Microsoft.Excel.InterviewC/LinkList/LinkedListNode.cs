using System.Text;

namespace Microsoft.Excel.InterviewC.LinkList
{
    public class LinkedListNode : ILinkedListNode
    {
        public ILinkedListNode Next { get; set; }
        public int Value { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(Value);
            var current = Next;
            while (current != null)
            {
                sb.Append(',');
                sb.Append(current.Value);
                current = current.Next;
            }
            return sb.ToString();

        }
    }

}


