namespace Microsoft.Excel.InterviewC.LinkList
{
    public interface ILinkedListNode
    {
        ILinkedListNode Next { get; set; }
        int Value { get; }
    }


}
