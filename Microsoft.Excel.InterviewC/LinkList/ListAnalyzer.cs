namespace Microsoft.Excel.InterviewC.LinkList
{
    public static class ListAnalyzer
    {
        public static ILinkedListNode GetCommonTail(ILinkedList l1, ILinkedList l2)
        {
            var l1Start = l1.Head;
            var l2Start = l2.Head;

            for (int i = 0; i < (l1.Depth - l2.Depth); i++)
                l1Start = l1Start.Next;

            for (int i = 0; i < (l2.Depth - l1.Depth); i++)
                l2Start = l2Start.Next;

            var tail = l1Start;
            while (l1Start != null)
            {
                if (l1Start.Value != l2Start.Value)
                {
                    tail = l1Start.Next;
                }
                l1Start = l1Start.Next;
                l2Start = l2Start.Next;
            }
            return tail;
        }
    }

}
