using System.Collections.Generic;

namespace Microsoft.Excel.InterviewC
{

    public interface INode
    {
        int Value { get; }
        INode Right { get; set; }
        INode Left { get; set; }
    }

}

