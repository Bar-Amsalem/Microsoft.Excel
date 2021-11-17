namespace Microsoft.Excel.InterviewC.LinkList
{
    public interface ILinkedList
    {
        ILinkedListNode Head { get; }
        int Depth { get; }
        ILinkedList Add(int item);


    }


}

