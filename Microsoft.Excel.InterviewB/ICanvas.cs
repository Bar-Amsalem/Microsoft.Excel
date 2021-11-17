using Microsoft.Excel.InterviewB.Shapes;
using System.Collections.Generic;

namespace Microsoft.Excel.InterviewB
{
    public interface ICanvas : IEnumerable<IShape>
    {
        void AddShape(IShape shape);
        void RemoveShape(IShape shape);
        IShape this[int shapeId] { get; }
        void Undo();
    }





}
