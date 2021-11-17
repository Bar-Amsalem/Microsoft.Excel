using System.Collections.Generic;

namespace Microsoft.Excel.InterviewC
{
    public class Node : INode
    {
        public Node(int value)
        {
            Value = value;
        }

        public int Value { get; }
        public INode Left { get; set; }
        public INode Right { get; set; }


    }
}
